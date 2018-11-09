using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Category_Attr_RelatedDAL
    {
        /// <summary>
        ///表名
        /// <summary>
        private static string TableName = "Category_Attr_Related";
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
        public static int Add(long categoryID, long attrID)
        {
            SqlParameter[] pramsAdd =
            {
				DALUtil.MakeInParam("@categoryID",SqlDbType.BigInt,4,categoryID), 
                DALUtil.MakeInParam("@attrID",SqlDbType.BigInt,4,attrID),  
			};
            return DBCommon.DBHelper.Add2(ConnString, TableName, pramsAdd);
        }


        #endregion

        //#region 修改
        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="pramsModify">修改参数集合</param>
        ///// <param name="pramsWhere">条件集合</param>
        ///// <returns>成功返回影响行数,失败返回0</returns>
        //public static int Modify(long categoryID, string name, long parentID, int level, bool isLeaf)
        //{
        //    SqlParameter[] pramsModify =
        //    {
        //        DALUtil.MakeInParam("@categoryID",SqlDbType.Int,4,categoryID),
        //        DALUtil.MakeInParam("@name",SqlDbType.NVarChar,100,name),
        //        DALUtil.MakeInParam("@parentID",SqlDbType.Int,4,parentID),
        //        DALUtil.MakeInParam("@level",SqlDbType.Int,4,level),
        //        DALUtil.MakeInParam("@isLeaf",SqlDbType.Int,4,(isLeaf==true?1:0)),
                
        //    };
        //    SqlParameter[] pramsWhere =
        //                    {
        //                        DALUtil.MakeInParam("@categoryID",SqlDbType.BigInt,4,categoryID)
        //                     };
        //    return DBCommon.DBHelper.Modify(ConnString, TableName, pramsModify, pramsWhere);
        //}

        ///// <summary>
        ///// 修改
        ///// </summary>
        ///// <param name="pramsModify">修改参数集合</param>
        ///// <param name="id">ID</param>
        ///// <returns>成功返回影响行数,失败返回0</returns>
        //public static int Modify(SqlParameter[] pramsModify, int id)
        //{
        //    SqlParameter[] pramsWhere =
        //    {
        //        DALUtil.MakeInParam("@ID",SqlDbType.Int,4,id)
        //    };
        //    return DBCommon.DBHelper.Modify(ConnString, TableName, pramsModify, pramsWhere);
        //}

        //#endregion

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
