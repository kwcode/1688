using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DBCommon
{
    public class KuParameter
    {
        public SqlParameter[] param { get; set; }
        public string fuhao { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }
        public static string a()
        {
            Dictionary<object, object> objList = new Dictionary<object, object>();
            objList.Add("", "");
            string sqlstr = "";
            return "";
        }
    }
}
