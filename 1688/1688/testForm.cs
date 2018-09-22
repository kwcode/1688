using Model.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1688
{
    public partial class testForm : Form
    {
        public testForm()
        {
            InitializeComponent();
        }
        Common.APIClient apiClient = new Common.APIClient();
        private void btn查询类目_Click(object sender, EventArgs e)
        {

            //获取所有一级分类列表
            //CategoryResult categoryList = apiClient.GetCategoryID(0);
            //获取【日用百货】和二级分类列表
            //CategoryResult category1 = apiClient.GetCategoryID(15);
            //获取【酒店用品】和三级分类列表
            //CategoryResult category2 = apiClient.GetCategoryID(1045268);
            //获取【酒店指示牌】和四级级分类列表
            CategoryResult category3 = apiClient.GetCategoryID(1045277);
            //四级--没有四类 1688上的四类为【产品类别 下的选项】
            //CategoryResult category4 = apiClient.GetCategoryID(0);

        }

        private void btn获取类目属性_Click(object sender, EventArgs e)
        {
            //获取【酒店指示牌】 下的属性(产品类别\品牌\是否进口\材质)
            CategoryResult attributeInfo = apiClient.GetAttributeInfo(1045277);

            //属性可选的属性值信息
            AttributeValueInfoEntity[] attributeValueInfoEntity = attributeInfo.attributes[0].attrValues;
        }
    }
}
