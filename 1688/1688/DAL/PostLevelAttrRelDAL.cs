using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PostLevelAttrRelDAL
    {

        /// <summary>
        ///表名
        /// <summary>
        private static string TableName = "PostLevelAttrRel";
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
        public static int Add(long fid, long subID, int attrType)
        {
            SqlParameter[] pramsAdd =
            {
				DALUtil.MakeInParam("@fid",SqlDbType.BigInt,4,fid), 
                DALUtil.MakeInParam("@subID",SqlDbType.BigInt,4,subID),  
                DALUtil.MakeInParam("@attrType",SqlDbType.Int,4,attrType),  
			};
            return DBCommon.DBHelper.Add2(ConnString, TableName, pramsAdd);
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
