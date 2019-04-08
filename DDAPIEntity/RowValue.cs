using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDAPIEntity
{
    public class RowValue
    {
        /// <summary>
        /// 物品名称
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 笔记本
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 物品名称
        /// </summary>
        public string key { get; set; }
    }


    public class LsRowValue
    {
        /// <summary>
        /// RowValue
        /// </summary>
        public List<RowValue> rowValue { get; set; }
    }
}
