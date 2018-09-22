using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBCommon
{
    [Serializable]
    public class LogException : Exception
    {
        public LogException(string message)
            : base(message )
        {
            //保存文件日志
            Logs.write("DBCommon-Error", message);
        }
    }
}
