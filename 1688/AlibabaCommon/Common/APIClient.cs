using com.alibaba.openapi.client;
using com.alibaba.openapi.client.http;
using com.alibaba.openapi.client.policy;
using Model;
using Model.Product;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// SDK封装的 方法
    /// </summary>
    public class APIClient
    {
        private ClientPolicy clientPolicy;
        public APIClient()
        {
            clientPolicy = new ClientPolicy();
            clientPolicy.AppKey = ConfigurationManager.AppSettings["AppKey"];
            clientPolicy.SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            clientPolicy.ServerHost = ConfigurationManager.AppSettings["ServerHost"];
        }
        public APIClient(string appKey, string secretKey, string serverHost = "gw.open.1688.com")
        {
            clientPolicy = new ClientPolicy();
            clientPolicy.AppKey = appKey; //测试上的账号
            clientPolicy.SecretKey = secretKey;
            clientPolicy.ServerHost = serverHost;

        }

        private T Send<T>(Request request, RequestPolicy policy)
        {
            HttpClient httpClient = new HttpClient(clientPolicy);
            string jsonResult = httpClient.GetRequestResult(request, policy);
            T t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonResult);
            return t;
        }

        #region 获取类目
        /// <summary>
        /// 类目信息
        ///Name=com.alibaba.product
        ///NamespaceValue= alibaba.category.get 
        /// </summary>
        /// <param name="categoryID">类目id,必须大于等于0， 如果为0，则查询所有一级类目</param>
        /// <returns></returns>
        public ApiResult GetCategoryID(long categoryID = 0)
        {
            APIId apiId = new APIId();
            apiId.Name = "alibaba.category.get";
            apiId.NamespaceValue = "com.alibaba.product";
            apiId.Version = 1;

            Request request = new Request();
            request.ApiId = apiId;

            request.AddtionalParams["categoryID"] = categoryID;
            request.AddtionalParams["webSite"] = 1688;
            RequestPolicy oauthPolicy = new RequestPolicy();
            oauthPolicy.HttpMethod = "GET";
            oauthPolicy.UseHttps = true;

            return Send<ApiResult>(request, oauthPolicy);

        }
        #endregion

        #region 获取属性
        public ApiResult GetAttributeInfo(long categoryID = 0)
        {
            APIId apiId = new APIId();
            apiId.Name = "alibaba.category.attribute.get";
            apiId.NamespaceValue = "com.alibaba.product";
            apiId.Version = 1;

            Request request = new Request();
            request.ApiId = apiId;

            request.AddtionalParams["categoryID"] = categoryID;
            request.AddtionalParams["webSite"] = 1688;
            RequestPolicy oauthPolicy = new RequestPolicy();
            oauthPolicy.HttpMethod = "GET";
            oauthPolicy.UseHttps = true;

            return Send<ApiResult>(request, oauthPolicy);
        }
        #endregion
    }
}
