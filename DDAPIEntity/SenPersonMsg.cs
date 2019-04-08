using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAPIEntity
{
    public class SenPersonMsg
    {
        public string agent_id { get; set; }
        public string userid_list { get; set; }

        public Msg msg { get; set; }

    }

    /// <summary>
    ///  发送消息实体类
    /// </summary>
    public class Msg
    {
        /// <summary>
        /// text
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// Text
        /// </summary>
        public Text text { get; set; }
    }
    public class Text
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        public string content { get; set; }
    }

}
