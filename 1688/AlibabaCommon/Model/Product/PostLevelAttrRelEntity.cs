using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    public class PostLevelAttrRelEntity
    {
        /// <summary>
        /// 属性id
        /// </summary>
        public int fid { get; set; }
        /// <summary>
        /// 子关联属性
        /// </summary>
        public int[] subFids { get; set; }
        /// <summary>
        /// 0和空都为现货属性层级关系，1为加工属性层级关系，后面其它的可加
        /// </summary>
        public int attrType { get; set; }
    }
}
