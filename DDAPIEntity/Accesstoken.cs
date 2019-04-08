using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAPIEntity
{
    /// <summary>
    /// 获取token
    /// </summary>
   public class Accesstoken
    {
        /// <summary>
        /// 回执编码
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 回执信息
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        /// token值
        /// </summary>
        public string access_token { get; set; }
    }
}
