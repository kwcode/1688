using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileHelper
    {
        #region 记录值
        /// <summary>
        /// 写记录 统一保存在RC目录下
        /// 不追加 每次写新值
        /// </summary>
        /// <param name="fileName">文件名 不含.txt</param>
        /// <param name="obj">记录值</param>
        public static void Write(string fileName, object obj)
        {
            string logPath = AppDomain.CurrentDomain.BaseDirectory + "RC";
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            logPath += "\\" + fileName + ".txt";
            StreamWriter mySw = new StreamWriter(logPath, false);
            mySw.Write(obj);
            mySw.Close();
        }
        #endregion

        #region 读取值
        public static string Read(string fileName)
        {
            try
            {
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "RC";
                if (!Directory.Exists(logPath))
                {
                    Directory.CreateDirectory(logPath);
                }
                logPath += "\\" + fileName + ".txt";
                StreamReader sr = new StreamReader(logPath, false);
                string reslut = sr.ReadToEnd();
                sr.Close();
                return reslut;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
