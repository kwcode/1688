﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1688
{
   public class Global
    {
        /// <summary>
        ///   UI界面方法使用的主程序的UI主线程同步器
        /// </summary>
        public static SynchronizationContext SysContext { get { return _SysContext; } set { _SysContext = value; } }
        private static SynchronizationContext _SysContext;
    }
}
