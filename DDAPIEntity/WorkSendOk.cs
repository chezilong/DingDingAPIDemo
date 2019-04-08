using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAPIEntity
{
    /// <summary>
    /// 查询工作通知消息的发送结果
    /// </summary>
    public class WorkSendOk
    {
        /// <summary>
        /// Errcode
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// Send_result
        /// </summary>
        public Send_result send_result { get; set; }
        /// <summary>
        /// 11gigq4keqw97
        /// </summary>
        public string request_id { get; set; }
    }

    public class Send_result
    {
        /// <summary>
        /// Failed_user_id_list
        /// </summary>
        public List<string> failed_user_id_list { get; set; }
        /// <summary>
        /// Invalid_dept_id_list
        /// </summary>
        public List<string> invalid_dept_id_list { get; set; }
        /// <summary>
        /// Invalid_user_id_list
        /// </summary>
        public List<string> invalid_user_id_list { get; set; }
        /// <summary>
        /// Read_user_id_list
        /// </summary>
        public List<string> read_user_id_list { get; set; }
        /// <summary>
        /// Unread_user_id_list
        /// </summary>
        public List<string> unread_user_id_list { get; set; }
    }


}
