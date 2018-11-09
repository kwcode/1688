using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model.Product
{
    public class ApiResult
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
        /// <summary>
        /// 级联信息字符串，可强转成map。冒号前为属性id，冒号后面为属性值id >表示层级关系。某些类目由于层级属性太多，该字段可能为空，需要通过调用“获取类目属性层级级联信息”接口获取
        /// {"1811:3289490":"20602,2917380,7001","100000691:46874>7108:21958":"8243"}
        /// </summary>
        public Dictionary<string,string>  attributeLevelMapStr { get; set; }
    }

    public class Attributelevelmapstr
    {

    }

}
