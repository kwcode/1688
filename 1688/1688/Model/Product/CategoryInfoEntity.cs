using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    public class CategoryInfoEntity
    {
        /// <summary>
        /// 类目ID
        /// </summary>
        public long categoryID { get; set; }
        /// <summary>
        /// 类目名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 类目英文名称，1688无此内容
        /// </summary>
        public string enName { get; set; }
        /// <summary>
        /// 类目层级，1688无此内容
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 是否叶子类目（只有叶子类目才能发布商品）
        /// </summary>
        public bool isLeaf { get; set; }
        /// <summary>
        /// 父类目ID数组,1688只返回一个父id
        /// </summary>
        public long[] parentIDs { get; set; }
        /// <summary>
        /// 子类目ID数组，1688无此内容
        /// </summary>
        public long[] childIDs { get; set; }
    }
}
