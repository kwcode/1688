using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Model;
using Model.Product;
namespace DAL
{
    /// <summary>
    ///    工具 :TCode
    /// 创建日期:2017-09-30 20:32
    /// </summary>
    public class AttributeInfoDAL
    {
        /// <summary>
        ///表名
        /// <summary>
        private static string TableName = "AttributeInfo";
        /// <summary>
        ///数据库连接字符串
        /// <summary>
        private static string ConnString = DALUtil.ConnString_Ku_Common;

        #region TCode生成的 方法

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="attrID">属性id</param>
        /// <param name="name">名称</param>
        /// <param name="required">是否必填属性</param>
        /// <param name="units">该属性的单位</param>
        /// <param name="inputType">输入类型</param>
        /// <param name="parentAttrID">父属性ID</param>
        /// <param name="parentAttrValueID">父属性值ID</param>
        /// <param name="aspect">产品属性</param>
        /// <param name="isSKUAttribute">该属性能否当成SKU属性</param>
        /// <returns></returns>
        public static int Add(long attrID, string name, int required, string units, string inputType, string parentAttrID, string parentAttrValueID, string aspect, int isSKUAttribute)
        {

            SqlParameter[] pramsAdd =
			{
				DAL.DALUtil.MakeInParam("@CreateTS",System.Data.SqlDbType.DateTime,8,DateTime.Now),
				DAL.DALUtil.MakeInParam("@attrID",System.Data.SqlDbType.Int,4,attrID),
				DAL.DALUtil.MakeInParam("@name",System.Data.SqlDbType.NVarChar,100,name),
				DAL.DALUtil.MakeInParam("@required",System.Data.SqlDbType.Int,4, required),
				DAL.DALUtil.MakeInParam("@units",System.Data.SqlDbType.NVarChar,100, units),
				DAL.DALUtil.MakeInParam("@inputType",System.Data.SqlDbType.NVarChar,100, inputType),
				DAL.DALUtil.MakeInParam("@parentAttrID",System.Data.SqlDbType.NVarChar,100, parentAttrID),
				DAL.DALUtil.MakeInParam("@parentAttrValueID",System.Data.SqlDbType.NVarChar,100, parentAttrValueID),
				DAL.DALUtil.MakeInParam("@aspect",System.Data.SqlDbType.NVarChar,100, aspect),
				DAL.DALUtil.MakeInParam("@isSKUAttribute",System.Data.SqlDbType.Int,4, isSKUAttribute),
			};

            return DBCommon.DBHelper.Add(ConnString, TableName, pramsAdd);
        }


        #endregion

        #region 检测是否存在
        public static bool IsExist(long attrID)
        {
            SqlParameter[] pramsWhere =
			{
				DAL.DALUtil.MakeInParam("@attrID",System.Data.SqlDbType.Int,4,attrID),
			};
            int count = DALUtil.ConvertToInt32(DBCommon.DBHelper.GetSingle(ConnString, TableName, "Count(0)", pramsWhere));
            return count > 0;
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
        public static AttributeInfoEntity Get1(string SelectIF, SqlParameter[] pramsWhere, string OrderName = "")
        {
            DataTable dt = DBCommon.DBHelper.GetDataTable1(ConnString, TableName, SelectIF, pramsWhere, OrderName);
            return DALUtil.ConvertDataTableToEntity<AttributeInfoEntity>(dt);
        }
        #endregion

        #region 获取自定义参数数据
        /// <summary>
        /// 获取自定义参数数据
        /// </summary>
        /// <param name="ID">ID</param>
        /// <param name="SelectIF">查询字段</param>
        public static AttributeInfoEntity Get_99(int ID, string SelectIF)
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
        public static List<AttributeInfoEntity> GetList(string SelectIF, SqlParameter[] pramsWhere, string OrderName = "")
        {
            DataTable dt = DBCommon.DBHelper.GetDataTable2(ConnString, TableName, SelectIF, pramsWhere, OrderName);
            return DALUtil.ConvertDataTableToEntityList<AttributeInfoEntity>(dt);
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
        public static List<AttributeInfoEntity> GetPageList(int PageIndex, int PageSize, string SelectIF, string OrderName, string strWhere, List<object> valuesList)
        {
            DataTable dt = DBCommon.DBHelper.GetDataTablePage(ConnString, TableName, SelectIF, PageIndex, PageSize, OrderName, strWhere, valuesList.ToArray());
            return DALUtil.ConvertDataTableToEntityList<AttributeInfoEntity>(dt);
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

