
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    /// <summary>
    /// 类目属性信息
    /// </summary>
    public class AttributeInfoEntity
    {
        /// <summary>
        /// 属性id
        /// </summary>
        public long attrID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 是否必填属性
        /// </summary>
        public bool required { get; set; }
        /// <summary>
        /// 该属性的单位
        /// </summary>
        public string[] units { get; set; }
        /// <summary>
        /// 该属性能否当成SKU属性
        /// </summary>
        public bool isSKUAttribute { get; set; }
        /// <summary>
        /// 属性可选的属性值
        /// </summary>
        public AttributeValueInfoEntity[] attrValues { get; set; }
        /// <summary>
        /// 输入类型。 下拉框:1, 多选框:2 单选框:3, 文本输入框:0, 数字输入框:-1, 下拉框列表:4, 日期：5
        /// </summary>
        public string inputType { get; set; }
        /// <summary>
        /// 用成SKU属性时，是否支持自定义属性值名称，1688不返回该信息
        /// </summary>
        public bool isSupportCustomizeValue { get; set; }
        /// <summary>
        /// 用成SKU属性时，是否支持自定义图片展示，1688不返回该信息
        /// </summary>
        public bool isSupportCustomizeImage { get; set; }
        /// <summary>
        /// 英文名称，1688无此属性
        /// </summary>
        public string enName { get; set; }
        /// <summary>
        /// 父属性ID，如果此值为空或零，则表示此属性为一级属性
        /// </summary>
        public string parentAttrID { get; set; }
        /// <summary>
        /// 父属性值ID，如果此值为空或零，则表示此属性为一级属性
        /// </summary>
        public string parentAttrValueID { get; set; }
        /// <summary>
        /// 产品属性:0, 交易属性:3, spu匹配属性:5
        /// </summary>
        public string aspect { get; set; }

    }
}
