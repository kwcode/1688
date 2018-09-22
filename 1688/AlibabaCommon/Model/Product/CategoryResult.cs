using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    public class CategoryResult
    {
        /// <summary>
        /// 类目列表
        /// </summary>
        public CategoryInfoEntity[] categoryInfo { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string errorMsg { get; set; }
        /// <summary>
        /// 类目属性信息
        /// </summary>
        public AttributeInfoEntity[] attributes { get; set; }
        /// <summary>
        /// 类目属性级联关系，只有1688业务返回返回该字段
        /// </summary>
        public PostLevelAttrRelEntity[] levelAttrRelList { get; set; }
    }



}
