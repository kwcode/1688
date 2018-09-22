using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    /// <summary>
    /// 属性可选的属性值信息
    /// </summary>
    public class AttributeValueInfoEntity
    {
        /// <summary>
        /// 属性值id
        /// </summary>
        public long attrValueID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string enName { get; set; }
        /// <summary>
        /// 该属性值的子属性id
        /// </summary>
        public long[] childAttrs { get; set; }
        /// <summary>
        /// 是否SKU属性值
        /// </summary>
        public bool isSKU { get; set; }
    }
}
