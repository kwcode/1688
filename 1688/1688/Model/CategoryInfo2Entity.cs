using System;
using System.Collections.Generic;
using System.Text;
namespace Model
{
    /// <summary>
    /// 实体：CategoryInfo2Entity
    /// 创建工具 :TCode
    /// 生成时间:2017-09-07 21:00
    /// </summary>
    public class CategoryInfo2Entity
    {
        #region 原始字段

        public DateTime CreateTS { get; set; }
        public int categoryID { get; set; }
        public string name { get; set; }
        public int parentID { get; set; }
        public int level { get; set; }

        #endregion

    }
}

