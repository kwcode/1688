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

        private void DoThreadTask()
        {
            int apiCount = 0;
            KeyEntity keyEntity = keyList.Dequeue();
            APIClient apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);

            #region 调用API获取所有一级类目 检测 返回需要新增的一类ID集合

            CategoryResult category1List = apiClient.GetCategoryID(0);
            long[] category1_IDs = category1List.categoryInfo[0].childIDs;
            apiCount++;
            List<long> needAddList = new List<long>();
            foreach (long item in category1_IDs)
            {
                int cont = DAL.CategoryInfoDAL.GetSingle("count(0)", "categoryID={0}", item);
                if (cont <= 0)
                {
                    needAddList.Add(item);
                }
            }
            #endregion

            List<CategoryInfoEntity> list = DAL.CategoryInfoDAL.GetList("*", 2, "categoryID");
            int index = 0;

            foreach (long categoryID in needAddList)
            {
                try
                {
                    CategoryResult resultCategory1 = apiClient.GetCategoryID(categoryID);
                    index++;
                    long[] array = resultCategory1.categoryInfo[0].childIDs;
                    if (array != null && array.Length > 0)
                    {
                        foreach (long item in array)
                        {
                            try
                            {
                                CategoryResult resultCategory = apiClient.GetCategoryID(item);
                                index++;
                                if (!string.IsNullOrEmpty(resultCategory.errorMsg))
                                {

                                }
                                //long categoryID = resultCategory.categoryInfo[0].categoryID;
                                string name = resultCategory.categoryInfo[0].name;
                                int level = 3;
                                long parentID = resultCategory.categoryInfo[0].parentIDs[0];// itemEntity.categoryID;

                                if (index >= 4900)
                                {

                                }
                                //导入一类
                                int cont = DAL.CategoryInfoDAL.GetSingle("count(0)", "categoryID={0}", categoryID);
                                if (cont == 0)
                                {
                                    DAL.CategoryInfoDAL.Add(categoryID, name, parentID, level);
                                    //msg(itemEntity.name + "->【3级】" + name);

                                    GO(resultCategory.categoryInfo[0].childIDs, categoryID, name);
                                }
                                else
                                {
                                    //msg("存在" + itemEntity.name + "->【3级】" + name);
                                }
                            }
                            catch (Exception)
                            {
                                index = 0;
                                apiClient = new Common.APIClient("8746098", "0QYAZkXsM8");
                                continue;
                                throw;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }


        public void GO(long[] array, long parentID, string pName)
        {
            Common.APIClient apiClient = new Common.APIClient();
            if (array != null && array.Length > 0)
            {
                foreach (long item in array)
                {
                    try
                    {
                        CategoryResult resultCategory = apiClient.GetCategoryID(item);
                        long categoryID = resultCategory.categoryInfo[0].categoryID;
                        string name = resultCategory.categoryInfo[0].name;
                        int level = 4;
                        DAL.CategoryInfoDAL.Add(categoryID, name, parentID, level);
                        msg(pName + "->【4级】" + name);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
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

            int apiCount = 0;
            KeyEntity keyEntity = keyList.Dequeue();
            APIClient apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
            string recordFileName = "AttributeTask_Page";
            while (true)
            {
                int pageIndex = 1;
                string record = DAL.FileHelper.Read(recordFileName);
                if (!string.IsNullOrWhiteSpace(record))
                {
                    pageIndex = Convert.ToInt32(record);
                }
                List<CategoryInfoEntity> list = DAL.CategoryInfoDAL.GetPageList(pageIndex, 1, "*", "ID", "level=3");
                if (list == null || list.Count <= 0)
                {
                    break;
                }
                CategoryInfoEntity entity = list[0];

                try
                {
                    CategoryResult attributeInfo = apiClient.GetAttributeInfo(entity.categoryID);
                    apiCount++;
                    if (attributeInfo.errorMsg == "不能找到类目信息")
                    {
                        msg(entity.name + "---" + attributeInfo.errorMsg);
                        pageIndex++;
                        DAL.FileHelper.Write(recordFileName, pageIndex);
                        continue;

                    }
                    else if (attributeInfo.errorMsg != null)
                    {
                        msg(attributeInfo.errorMsg);
                        Thread.Sleep(10000000);
                        continue;
                    }

                    if (apiCount > keyEntity.ApiCount)//超过最大调用次数
                    {
                        msg("正在切换账号...");
                        Thread.Sleep(10000);
                        keyEntity = keyList.Dequeue();
                        apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
                        apiCount = 0;
                        continue;
                    }
                    //类目属性信息 列表
                    AttributeInfoEntity[] attributes = attributeInfo.attributes;
                    if (attributes.Length > 0)
                    {
                        foreach (AttributeInfoEntity item in attributes)
                        {
                            //增加 类目属性信息
                            if (!DAL.AttributeInfoDAL.IsExist(item.attrID))
                            {
                                string units = string.Empty;
                                if (item.units != null && item.units.Length > 0)
                                {
                                    units = string.Join(",", item.units);
                                }

                                int row_Add = DAL.AttributeInfoDAL.Add(item.attrID, item.name, Convert.ToInt32(item.required), units, item.inputType, item.parentAttrID, item.parentAttrValueID, item.aspect, Convert.ToInt32(item.isSKUAttribute));
                                msg("******增加属性" + item.name);
                            }
                            //增加类目属性对应的 选项
                            AttributeValueInfoEntity[] attributeValueInfoEntity = item.attrValues;
                            if (attributeValueInfoEntity.Length > 0)
                            {
                                foreach (AttributeValueInfoEntity itemValue in attributeValueInfoEntity)
                                {
                                    if (!DAL.AttributeValueInfoDAL.IsExist(itemValue.attrValueID))
                                    {
                                        int row_Add2 = DAL.AttributeValueInfoDAL.Add(itemValue.attrValueID, itemValue.name, itemValue.enName, Convert.ToInt32(itemValue.isSKU));
                                        msg("#####增加选项:" + itemValue.name);
                                    }
                                }
                            }
                        }
                    }
                    pageIndex++;
                    DAL.FileHelper.Write(recordFileName, pageIndex);

                    msg(entity.name + "执行完毕--------------");
                    Thread.Sleep(1000);

                }
                catch (Exception ex)
                {
                    msg(ex.ToString());
                    msg("正在切换账号...");
                    Thread.Sleep(10000);
                    keyEntity = keyList.Dequeue();
                    apiClient = new Common.APIClient(keyEntity.AppKey, keyEntity.SecretKey);
                    apiCount = 0;
                    continue;
                }
            }

            msg("执行完毕");

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
