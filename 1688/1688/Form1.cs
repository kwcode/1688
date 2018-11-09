using com.alibaba.openapi.client;
using com.alibaba.openapi.client.entity;
using com.alibaba.openapi.client.http;
using com.alibaba.openapi.client.policy;
using Common;
using DAL;
using Model;
using Model.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _1688
{
    public partial class Form1 : Form
    {
        //https://open.1688.com/apps/appServiceList.htm?spm=a260s.8209140.sidebar.5.ql9kmS 获取key
        public Form1()
        {
            Global.SysContext = System.Threading.SynchronizationContext.Current;
            InitializeComponent();
        }
        Queue<KeyEntity> keyList = KeyDAL.GetList();

        #region 采集所有类目
        private void btnGategory_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(DoThreadTask);
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private APIClient apiClient;
        private void DoThreadTask()
        {
            KeyEntity keyEntity = keyList.Dequeue();
            apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
            GoChildGategory(0, 0);
            msg("执行完毕");
        }
        /// <summary>
        /// 执行下级分类
        /// </summary>
        private void GoChildGategory(long pid, int level)
        {
            try
            {

                ApiResult entity = apiClient.GetCategoryID(pid);
                Thread.Sleep(300);
                if (entity == null)
                {
                    KeyEntity keyEntity = keyList.Dequeue();
                    apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
                    entity = apiClient.GetCategoryID(pid);
                }
                CategoryInfoEntity categoryInfo_1688 = entity.categoryInfo[0];
                if (categoryInfo_1688 != null)
                {
                    if (categoryInfo_1688.categoryID > 0)
                    {
                        long parentID = categoryInfo_1688.parentIDs[0];
                        #region 保存到数据库

                        SqlParameter[] pramsWhere =
			                {
				                DALUtil.MakeInParam("@categoryID",SqlDbType.Int,4,categoryInfo_1688.categoryID)
			                 };
                        CategoryInfoEntity categoryEntity = DAL.CategoryInfoDAL.Get1("categoryID", pramsWhere);
                        if (categoryEntity != null && categoryEntity.categoryID > 0)
                        {
                            DAL.CategoryInfoDAL.Modify(categoryInfo_1688.categoryID, categoryInfo_1688.name, parentID, level, categoryInfo_1688.isLeaf);
                            msg("存在===" + categoryInfo_1688.name + "->【" + level + "级】" + categoryInfo_1688.name);
                        }
                        else
                        {
                            DAL.CategoryInfoDAL.Add(categoryInfo_1688.categoryID, categoryInfo_1688.name, parentID, level, categoryInfo_1688.isLeaf);
                            msg("已添加===" + "->【" + level + "级】" + categoryInfo_1688.name);
                        }
                        #endregion
                    }

                    //执行子级查询
                    ChildCategorysEntity[] childCategorys = categoryInfo_1688.childCategorys;
                    if (childCategorys != null && childCategorys.Length > 0)
                    {
                        if (childCategorys != null && childCategorys.Length > 0)
                        {
                            foreach (ChildCategorysEntity item in childCategorys)
                            {
                                GoChildGategory(item.id, level + 1);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                KeyEntity keyEntity = keyList.Dequeue();
                if (keyEntity != null)
                {
                    apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
                    GoChildGategory(pid, level);
                }
                else
                {
                    msg("-----------没有可用账号");
                }

            }
        }

        #endregion

        #region 采集类目下面的属性和选项
        private void btnAttributeInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Thread thread = new Thread(DoAttributeTask);
                thread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void DoAttributeTask()
        {

            //循环类目 获取对应的属性 
            KeyEntity keyEntity = keyList.Dequeue();
            apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
            //GoChildGategory(0, 0);
            //msg("执行完毕");

            while (true)
            {
                List<CategoryInfoEntity> list = DAL.CategoryInfoDAL.GetList_9();
                if (list == null || list.Count <= 0)
                {
                    break;
                }
                foreach (CategoryInfoEntity item in list)
                {
                    GoAttribute(item.categoryID);
                    DAL.CategoryInfoDAL.Modify_Process(item.ID);
                }
            }
            msg("执行完毕");

        }

        private void GoAttribute(long categoryID)
        {
            try
            {
                ApiResult attributeInfo = apiClient.GetAttributeInfo(categoryID);
                Thread.Sleep(200);
                if (attributeInfo != null)
                {
                    #region 属性

                    AttributeInfoEntity[] attributes = attributeInfo.attributes;

                    if (attributes.Length > 0)
                    {
                        int index = 0;
                        foreach (AttributeInfoEntity item in attributes)
                        {
                            //try
                            //{
                            index++;

                            #region 类目下的属性

                            string units = string.Empty;
                            if (item.units != null && item.units.Length > 0)
                            {
                                units = string.Join(",", item.units);
                            }

                            AttributeInfoEntity attrEntity = DAL.AttributeInfoDAL.Get_98(item.attrID, "attrID");
                            if (attrEntity != null && attrEntity.attrID > 0)
                            {
                                //int row_Mod = DAL.AttributeInfoDAL.Modify(categoryID, item.attrID, item.name, Convert.ToInt32(item.required), units, item.inputType, item.parentAttrID, item.parentAttrValueID, item.aspect, Convert.ToInt32(item.isSKUAttribute));
                                //msg("******修改属性" + item.name);
                            }
                            else
                            {
                                int row_Add = DAL.AttributeInfoDAL.Add(categoryID, item.attrID, item.name, Convert.ToInt32(item.required), units, item.inputType, item.parentAttrID, item.parentAttrValueID, item.aspect, Convert.ToInt32(item.isSKUAttribute));
                                msg("******属性-增加" + item.name);
                            }
                            #endregion

                            #region 类目与属性关联中间表
                            int count = Category_Attr_RelatedDAL.GetSingle("count(0)", "  categoryID={0} AND attrID={1} ", categoryID, item.attrID);
                            if (count == 0)
                            {
                                Category_Attr_RelatedDAL.Add(categoryID, item.attrID);
                                msg("******关联-增加====" + item.name);
                            }
                            #endregion

                            #region 增加类目属性对应的 选项
                            AttributeValueInfoEntity[] attrValueList = item.attrValues;
                            if (attrValueList.Length > 0)
                            {
                                foreach (AttributeValueInfoEntity itemValue in attrValueList)
                                {
                                    AttributeValueInfoEntity attrValueEntity = DAL.AttributeValueInfoDAL.Get_98(itemValue.attrValueID, "attrValueID");
                                    if (attrValueEntity != null && attrValueEntity.attrValueID > 0)
                                    {
                                        //int row_Mod2 = DAL.AttributeValueInfoDAL.Modify(itemValue.attrValueID, itemValue.name, itemValue.enName, Convert.ToInt32(itemValue.isSKU));
                                        //msg("#####修改选项:" + itemValue.name);
                                    }
                                    else
                                    {
                                        int row_Add2 = DAL.AttributeValueInfoDAL.Add(itemValue.attrValueID, itemValue.name, itemValue.enName, Convert.ToInt32(itemValue.isSKU));
                                        msg("#####选项-增加:" + itemValue.name);
                                    }
                                }
                            }
                            #endregion


                            //}
                            //catch (Exception ex)
                            //{

                            //}

                        }
                    }

                    #endregion

                    #region 属性子级关联
                    PostLevelAttrRelEntity[] levelAttrRelList = attributeInfo.levelAttrRelList;
                    if (levelAttrRelList != null && levelAttrRelList.Length > 0)
                    {
                        foreach (PostLevelAttrRelEntity itemAttrRel in levelAttrRelList)
                        {
                            if (itemAttrRel.subFids != null && itemAttrRel.subFids.Length > 0)
                            { 
                                foreach (int subID in itemAttrRel.subFids)
                                {
                                    int count = PostLevelAttrRelDAL.GetSingle("count(0)", "  fid={0} AND subID={1} ", itemAttrRel.fid, subID);
                                    if (count == 0)
                                    {
                                        PostLevelAttrRelDAL.Add(itemAttrRel.fid, subID, itemAttrRel.attrType);
                                        msg("******属性子级关联-增加====" + itemAttrRel.fid);
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }

            }
            catch (Exception)
            {

                KeyEntity keyEntity = keyList.Dequeue();
                if (keyEntity != null)
                {
                    apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
                    GoAttribute(categoryID);
                }
                else
                {
                    msg("-----------没有可用账号");
                }
            }

        }
        #endregion

        //private void btnImportCategory_Click(object sender, EventArgs e)
        //{
        //    Common.APIClient apiClient = new Common.APIClient();
        //    CategoryResult result = apiClient.GetCategoryID(130823000);
        //    foreach (long item in result.categoryInfo[0].childIDs)
        //    {
        //        try
        //        {

        //            CategoryResult resultCategory = apiClient.GetCategoryID(item);
        //            long categoryID = resultCategory.categoryInfo[0].categoryID;
        //            string name = resultCategory.categoryInfo[0].name;
        //            int level = resultCategory.categoryInfo[0].level;
        //            long parentID = 0;
        //            if (resultCategory.categoryInfo[0].parentIDs != null)
        //            {
        //                parentID = resultCategory.categoryInfo[0].parentIDs[0];
        //            }

        //            //导入一类
        //            //DAL.CategoryInfoDAL.Add(categoryID, name, parentID, level);
        //        }
        //        catch (Exception ex)
        //        {

        //            throw;
        //        }
        //    }
        //}

        //private void btnImportCategory2_Click(object sender, EventArgs e)
        //{
        //    Thread thread = new Thread(DoThreadTask);
        //    thread.Start();
        //}

        #region 多线程 输出
        public void msg(object obj)
        {
            try
            {
                string message = txtOutputMsg.Text;
                if (message.Length > 50000)
                {
                    message = "";
                }
                this.Invoke(new Action(() =>
                {
                    txtOutputMsg.Text = message + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + obj.ToString() + "\r\n";
                    txtOutputMsg.SelectionStart = message.Length;
                    txtOutputMsg.ScrollToCaret();
                }));
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
