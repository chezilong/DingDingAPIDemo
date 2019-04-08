using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAPIEntity
{
    public class Form_component_values
    {
        /// <summary>
        /// 物品用途
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 日常办公
        /// </summary>
        public string value { get; set; }
    }

    public class Operation_records
    {
        /// <summary>
        /// 2019-04-04 15:06:19
        /// </summary>
        public DateTime date { get; set; }
        /// <summary>
        /// NONE
        /// </summary>
        public string operation_result { get; set; }
        /// <summary>
        /// START_PROCESS_INSTANCE
        /// </summary>
        public string operation_type { get; set; }
        /// <summary>
        /// 030823612936043823
        /// </summary>
        public string userid { get; set; }
    }

    public class Tasks
    {
        /// <summary>
        /// 2019-04-04 15:06:19
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 2019-04-04 15:06:58
        /// </summary>
        public DateTime finish_time { get; set; }
        /// <summary>
        /// AGREE
        /// </summary>
        public string task_result { get; set; }
        /// <summary>
        /// COMPLETED
        /// </summary>
        public string task_status { get; set; }
        /// <summary>
        /// 61064977641
        /// </summary>
        public string taskid { get; set; }
        /// <summary>
        /// 030823612936043823
        /// </summary>
        public string userid { get; set; }
    }

    public class Process_instance
    {
        /// <summary>
        /// Attached_process_instance_ids
        /// </summary>
        public List<string> attached_process_instance_ids { get; set; }
        /// <summary>
        /// NONE
        /// </summary>
        public string biz_action { get; set; }
        /// <summary>
        /// 201904041506000190133
        /// </summary>
        public string business_id { get; set; }
        /// <summary>
        /// 2019-04-04 15:06:19
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 2019-04-04 15:06:58
        /// </summary>
        public DateTime finish_time { get; set; }
        /// <summary>
        /// Form_component_values
        /// </summary>
        public List<Form_component_values> form_component_values { get; set; }
        /// <summary>
        /// Operation_records
        /// </summary>
        public List<Operation_records> operation_records { get; set; }
        /// <summary>
        /// 110016929
        /// </summary>
        public string originator_dept_id { get; set; }
        /// <summary>
        /// 技术
        /// </summary>
        public string originator_dept_name { get; set; }
        /// <summary>
        /// 030823612936043823
        /// </summary>
        public string originator_userid { get; set; }
        /// <summary>
        /// agree
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// COMPLETED
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Tasks
        /// </summary>
        public List<Tasks> tasks { get; set; }
        /// <summary>
        /// 车子龙提交的物品领用
        /// </summary>
        public string title { get; set; }
    }

    public class ProcessDetail
    {
        /// <summary>
        /// Errcode
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// Process_instance
        /// </summary>
        public Process_instance process_instance { get; set; }
        /// <summary>
        /// 7wuy5urn0gj2
        /// </summary>
        public string request_id { get; set; }
    }

}
