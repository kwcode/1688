using com.alibaba.openapi.client;
using com.alibaba.openapi.client.entity;
using com.alibaba.openapi.client.http;
using com.alibaba.openapi.client.policy;
 
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _1688
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //https://open.1688.com/apps/appServiceList.htm?spm=a260s.8209140.sidebar.5.ql9kmS 获取key
        private void btnGategory_Click(object sender, EventArgs e)
        {
            try
            {
                ClientPolicy clientPolicy = new ClientPolicy();
                //clientPolicy.AppKey = "5764156"; 开文的账号
                //clientPolicy.SecretKey = "Eit0Po6IAe8";
                clientPolicy.AppKey = "7406027"; //测试上的账号
                clientPolicy.SecretKey = "cXrmA5hdPtU";
                clientPolicy.ServerHost = "gw.open.1688.com";

                //SyncAPIClient apiClient = new SyncAPIClient(clientPolicy);
                //AlibabaCategoryGetResult obj = apiClient.GetCategoryID();

                Common.APIClient apiClient = new Common.APIClient();
                //apiClient.GetCategoryID();
                apiClient.GetCategoryID(1);
                apiClient.GetCategoryID(1033742);
                
                apiClient.GetAttributeInfo(1033742);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
