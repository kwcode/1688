using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Model.Product
{
    public class AttributeInfoEntity
    {
        public string name { get; set; }
        //        attrID	Long	否	属性id	
        //name	String	否	名称	
        //required	Boolean	否	是否必填属性	
        //units	String[]	否	该属性的单位	
        //isSKUAttribute	Boolean	否	该属性能否当成SKU属性	
        //attrValues	alibaba.category.AttributeValueInfo[]	否	属性可选的属性值	
        //inputType	String	否	输入类型。 下拉框:1, 多选框:2 单选框:3, 文本输入框:0, 数字输入框:-1, 下拉框列表:4, 日期：5	
        //isSupportCustomizeValue	Boolean	否	用成SKU属性时，是否支持自定义属性值名称，1688不返回该信息	
        //isSupportCustomizeImage	Boolean	否	用成SKU属性时，是否支持自定义图片展示，1688不返回该信息	
        //enName	String	否	英文名称，1688无此属性	
        //parentAttrID	String	否	父属性ID，如果此值为空或零，则表示此属性为一级属性	
        //parentAttrValueID	String	否	父属性值ID，如果此值为空或零，则表示此属性为一级属性	
        //aspect	String	否	产品属性:0, 交易属性:3, spu匹配属性:5
    }
}
