﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Model;
namespace DAL
{
    /// <summary>
    ///    工具 :TCode
    /// 创建日期:2017-09-07 21:00
    /// </summary>
    public class CategoryInfo2DAL
    {
        /// <summary>
        ///表名
        /// <summary>
        private static string TableName = "CategoryInfo2";
        /// <summary>
        ///数据库连接字符串
        /// <summary>
        private static string ConnString = DALUtil.ConnString_1688;

        #region TCode生成的 方法

        #region 新增
        /// <summary>
        ///新增
        /// <summary>
        /// <param name="pramsAdd">参数</param>
        /// <returns>成功返回自增ID</returns>
        public static int Add(long categoryID, string name, long parentID, int level)
        {
            SqlParameter[] pramsAdd =
            {
				DALUtil.MakeInParam("@categoryID",SqlDbType.Int,4,categoryID),
                DALUtil.MakeInParam("@name",SqlDbType.NVarChar,100,name),
                DALUtil.MakeInParam("@parentID",SqlDbType.Int,4,parentID),
                DALUtil.MakeInParam("@level",SqlDbType.Int,4,level),
			};
            return DBCommon.DBHelper.Add2(ConnString, TableName, pramsAdd);
        }


        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pramsModify">修改参数集合</param>
        /// <param name="pramsWhere">条件集合</param>
        /// <returns>成功返回影响行数,失败返回0</returns>
        public static int Modify(SqlParameter[] pramsModify, SqlParameter[] pramsWhere)
        {
            return DBCommon.DBHelper.Modify(ConnString, TableName, pramsModify, pramsWhere);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pramsModify">修改参数集合</param>
        /// <param name="id">ID</param>
        /// <returns>成功返回影响行数,失败返回0</returns>
        public static int Modify(SqlParameter[] pramsModify, int id)
        {
            SqlParameter[] pramsWhere =
			{
				DALUtil.MakeInParam("@ID",SqlDbType.Int,4,id)
			};
            return DBCommon.DBHelper.Modify(ConnString, TableName, pramsModify, pramsWhere);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pramsWhere">条件集合</param>
        /// <returns>成功返回影响行数,失败返回0</returns>
        public static int Delete(SqlParameter[] pramsWhere)
        {
            return DBCommon.DBHelper.Delete(ConnString, TableName, pramsWhere);
        }
        #endregion

        #region 根据删除ID
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>成功返回影响行数,失败返回0</returns>
        public static int Delete_1(int ID)
        {
            SqlParameter[] pramsWhere =
			{
				DALUtil.MakeInParam("@ID",SqlDbType.Int,4,ID)
			 };
            return DBCommon.DBHelper.Delete(ConnString, TableName, pramsWhere);
        }
        #endregion

        #region 获取一条数据
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="SelectIF">需要查询的字段</param>
        /// <param name="pramsWhere">条件集合</param>
        public static CategoryInfo2Entity Get1(string SelectIF, SqlParameter[] pramsWhere, string OrderName = "")
        {
            DataTable dt = DBCommon.DBHelper.GetDataTable1(ConnString, TableName, SelectIF, pramsWhere, OrderName);
            return DALUtil.ConvertDataTableToEntity<CategoryInfo2Entity>(dt);
        }
        #endregion

        #region 获取自定义参数数据
        /// <summary>
        /// 获取自定义参数数据
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="SelectIF">查询字段</param>
        public static CategoryInfo2Entity Get_99(int ID, string SelectIF)
        {
            try
            {
                //参数Where条件
                SqlParameter[] pramsWhere =
				{
					DALUtil.MakeInParam("@ID", SqlDbType.Int, 4, ID)
				};
                return Get1(SelectIF, pramsWhere);
            }
            catch { return null; }
        }
        #endregion

        #region 获取集合
        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="SelectIF">需要查询的字段</param>
        /// <param name="pramsWhere">条件集合</param>
        /// <param name="OrderName">排序无需带Order by</param>
        public static List<CategoryInfo2Entity> GetList(string SelectIF, SqlParameter[] pramsWhere, string OrderName = "")
        {
            DataTable dt = DBCommon.DBHelper.GetDataTable2(ConnString, TableName, SelectIF, pramsWhere, OrderName);
            return DALUtil.ConvertDataTableToEntityList<CategoryInfo2Entity>(dt);
        }
        #endregion

        #region 分页获取数据
        /// <summary>
        /// 分页获取数据
        ///条件如：a=1 and b=2
        /// </summary>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">数量</param>
        /// <param name="SelectIF">查询字段</param>
        /// <param name="OrderName">排序值</param>
        /// <param name="strWhere">条件(a=1 and b=2)</param>
        /// <param name="values">条件对应值</param>
        public static List<CategoryInfo2Entity> GetPageList(int PageIndex, int PageSize, string SelectIF, string OrderName, string strWhere, List<object> valuesList)
        {
            DataTable dt = DBCommon.DBHelper.GetDataTablePage(ConnString, TableName, SelectIF, PageIndex, PageSize, OrderName, strWhere, valuesList.ToArray());
            return DALUtil.ConvertDataTableToEntityList<CategoryInfo2Entity>(dt);
        }

        /// <summary>
        /// 获取数据总数量
        /// 条件：a=1 and b=2
        /// </summary>
        /// <param name="strWhere">条件(a=1 and b=2)</param>
        /// <param name="valuesList">条件集合值</param>
        public static int GetRecordCount(string strWhere, List<object> valuesList)
        {
            string SelectIF = " count(1) ";
            object obj = DBCommon.DBHelper.GetSingle(ConnString, TableName, SelectIF, strWhere, valuesList.ToArray());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return DALUtil.ConvertToInt32(obj);
            }
        }
        #endregion

        #region 获取一个数据
        /// <summary>
        /// 获取一个数据[判断是否存在,获取最大值]
        /// 条件 :a=1
        /// </summary>
        /// <param name="SelectIF">查询数据</param>
        /// <param name="sqlWhere">条件 a=1</param>
        /// <param name="values">值</param>
        /// <returns>返回数据</returns>
        public static int GetSingle(string SelectIF, string sqlWhere, params object[] values)
        {
            object obj = DBCommon.DBHelper.GetSingle(ConnString, TableName, SelectIF, sqlWhere, values);
            return DALUtil.ConvertToInt32(obj);
        }

        #endregion


        #endregion

    }
}

