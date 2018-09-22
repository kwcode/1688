using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 秘钥管理 
    ///获取key地址 https://open.1688.com/apps/appServiceList.htm?spm=a260s.8209140.sidebar.5.ql9kmS
    ///剩余量 https://open.1688.com/datas/invokeLimit.htm?spm=a260s.8209128.sidebar.13.zk8xBD
    /// </summary>
    public class KeyDAL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Queue<KeyEntity> GetList()
        {
            Queue<KeyEntity> list = new Queue<KeyEntity>();
            list.Enqueue(new KeyEntity() { AppKey = "3116564", SecretKey = "Iz4wJk0Mwyd", ApiCount = 5000000 });
            list.Enqueue(new KeyEntity() { AppKey = "4570837", SecretKey = "iPrvCQZnB4k", ApiCount = 5000000 });
            list.Enqueue(new KeyEntity() { AppKey = "3116564", SecretKey = "Iz4wJk0Mwyd", ApiCount = 5000000 });
            list.Enqueue(new KeyEntity() { AppKey = "4679370", SecretKey = "9re4n98PrceT", ApiCount = 5000000 });
            list.Enqueue(new KeyEntity() { AppKey = "4252631", SecretKey = "PuQwMpQn0D03", ApiCount = 5000000 });

            list.Enqueue(new KeyEntity() { AppKey = "7582189", SecretKey = "0MjPf1rpzOVa", ApiCount = 250000 });

            list.Enqueue(new KeyEntity() { AppKey = "3642023", SecretKey = "y4H7mAFA5UY", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "8746098", SecretKey = "0QYAZkXsM8", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "6734689", SecretKey = "CdBGL3CVPy", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "3125324", SecretKey = "UpMq1oQqC7", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "2708583", SecretKey = "QlQiBH0h3JTi", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "6332273", SecretKey = "UhqDbdpTFSf", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "9003637", SecretKey = "Zl9xOrnuP5W", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "7717072", SecretKey = "WcoolSkjZF", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "7406027", SecretKey = "cXrmA5hdPtU", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "2536885", SecretKey = "mIF0ObVLcSe", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "9108590", SecretKey = "4wm5vbJZEGG", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "2919028", SecretKey = "b6MSDvFJZjw", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "7582189", SecretKey = "0MjPf1rpzOV", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "5756290", SecretKey = "pWRa5KUTn3c", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "4616815", SecretKey = "88MyYu3IDm", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "5621879", SecretKey = "7Ogv0UQJg4", ApiCount = 5000 });
            list.Enqueue(new KeyEntity() { AppKey = "", SecretKey = "", ApiCount = 5000 });
            return list;

            //4659502  ggpAyVfh6Al
            //2465834  vU7JB9jo4x
            //6156661  WP9YY8AzzT
            //6408233  u1ZK3qh3B7o
            //8337862  5MT6UcaybV
            //5374467  mdjcGVweGnR
            //2178257  SsH2Y26GFpC
            //4452515  MbOtBrDtokt7
            //2405437  hgV6yYPsvnGv
            //3578988  MvK1H6xuWbhI
            //5439794  9rxXBldB73n
            //3815618  ePJHU9PaYsAV
            //6384825  yAvqXz18StP
            //2220925  sw7cKMhgL29
            //3958092  M1MA3kBnTP
            //1594277  6MDDtDVKRFV
            //5112815  M3W7JOkZ5i
            //7199959  yVmyqZgqcdtW
            //5732342  FYq3gMEUTn2
            //8800025  UjmYHU2ejT


        }
    }

    public class KeyEntity
    {
        /// <summary>
        /// 3642023
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// y4H7mAFA5UY
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 调用次数
        /// </summary>
        public int ApiCount { get; set; }
    }
}
