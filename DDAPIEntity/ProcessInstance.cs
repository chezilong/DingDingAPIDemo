using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAPIEntity
{
    /// <summary>
    /// 获取批量审批实例
    /// </summary>
    public class ProcessInstance
    {
        /// <summary>
        /// 结果信息
        /// </summary>
        public Result result { get; set; }
        /// <summary>
        /// 回执编码
        /// </summary>
        public int errcode { get; set; }
        /// <summary>
        /// 回执信息
        /// </summary>
        public string errmsg { get; set; }
    }

    /// <summary>
    /// 结果
    /// </summary>
    public class Result
    {
        /// <summary>
        /// 审批实例ID集合
        /// </summary>
        public List<string> list { get; set; }
        /// <summary>
        /// 表示下次查询的游标，当返回结果没有该字段时表示没有更多数据了
        /// </summary>
        public int next_cursor { get; set; }
    }

}
