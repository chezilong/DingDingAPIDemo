using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDAPIEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestDingDingApiPost
{
    public class DDAPI
    {

        private string strUrl;
        public string StrUrl
        {
            get { return strUrl; }
            set { strUrl = value; }
        }

        private string strJson;

        public string StrJson
        {
            get { return strJson; }
            set { strJson = value; }
        }


        /// <summary>
        /// 第一步 获取应用 access_token 命令
        ///https://oapi.dingtalk.com/gettoken?appkey=key&appsecret=secret 
        ///参数  appkey 新建应用详情信息中 / appsecret 新建应用详情信息中
        /// </summary>
        /// <returns>返回Token</returns>
        public string GetAcessTocken()
        {
            this.strUrl = "https://oapi.dingtalk.com/gettoken?appkey=ding4ccjs1xmnstxnsp5&appsecret=N_88-DQStvjoDUPWoLJrVW5xdETkcU-BtqyICWmDWqcxPP4i6jQuXEEJL3hxgA_x ";
            this.strJson = HttpMethod.HttpGet(this.strUrl, string.Empty);
            Accesstoken _accesstoken = JsonHelper.FromJson<Accesstoken>(this.strJson);
            return _accesstoken.access_token;
        }



        /// <summary>
        /// 第二部 获取货物领取下的所有审批实例
        /// https://oapi.dingtalk.com/topapi/processinstance/listids?access_token=ACCESS_TOKEN
        /// 参数 access_token  第一步中的结果值  process_code  审批中的单个实例的url中的 process_code
        /// start_time 开始时间。Unix时间戳
        /// </summary>
        /// <param name="token">获取的token</param>
        /// <returns>审批实例的ID集合</returns>
        public ProcessInstance GetProsListId(string token)
        {
            //正式使用取值当前时间减去一分钟
            //目前测试取值当前时间减去一月
            //C#获取Unix时间戳
            double start_time = (DateTime.Now.AddMonths(-1).ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            double end_time = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            string process_code = "PROC-62C79C4D-EF1D-49AE-AA54-8E950ABA951E";
            this.strUrl = "https://oapi.dingtalk.com/topapi/processinstance/listids?access_token=" + token + "&process_code=" + process_code + "&start_time=" + start_time;
            this.strJson = HttpMethod.HttpGet(this.strUrl, string.Empty);
            ProcessInstance _processInstance = JsonHelper.FromJson<ProcessInstance>(this.strJson);
            return _processInstance;
        }

        /// <summary>
        /// 获取单个审批实例 
        /// https://oapi.dingtalk.com/topapi/processinstance/get?access_token=ACCESS_TOKEN
        /// 参数 process_instance_id 第二步中结果 list 审批实例id列表
        /// </summary>
        /// <param name="token">Token</param>
        /// <param name="process_instance_id">单个实例ID号</param>
        /// <returns></returns>
        public ProcessDetail GetProsDetial(string token, string process_instance_id)
        {
            this.strUrl = "https://oapi.dingtalk.com/topapi/processinstance/get?access_token=" + token + "&process_instance_id=" + process_instance_id;
            this.strJson = HttpMethod.HttpGet(this.strUrl, string.Empty);

            ProcessDetail _processDetail = JsonHelper.FromJson<ProcessDetail>(this.strJson);
            return _processDetail;
        }


        //第四步 工作消息通知 
        //https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2?access_token=ACCESS_TOKEN
        //参数 agent_id 应用agentId ，userid_list 第三步  originator_userid  errcode=0 审批通过
        public WorkMsgReturn DoPostPerson(string token, ProcessDetail _processDetail)
        {
            Text _text = new Text() { content = string.Empty };

            List<Form_component_values> _lsComp = _processDetail.process_instance.form_component_values;
            List<LsRowValue> rowValues = new List<LsRowValue>();
            foreach (var item in _lsComp)
            {
                if (item.name.Contains("物品明细"))
                {
                    rowValues = JsonHelper.FromJson<List<LsRowValue>>(item.value);
                    foreach (var itemRowDetial in rowValues)
                    {
                        foreach (var itemDetail in itemRowDetial.rowValue)
                        {
                            if (itemDetail.label == "物品名称")
                            {
                                _text.content += "商品名称:\t" + itemDetail.value + "\r\n" + "取货码:" + string.Format("{0:ssffff}", DateTime.Now) + "\r\n";
                            }
                        }
                    }
                }

            }
            _text.content= "申请时间:"+_processDetail.process_instance.create_time.ToString() + "\r\n" + _text.content;

            SenPersonMsg _sdMsg = new SenPersonMsg();
            Msg _msg = new Msg() { msgtype = "text", text =  _text };
            _sdMsg.agent_id = "250353028";
            _sdMsg.userid_list = _processDetail.process_instance.originator_userid;
            _sdMsg.msg = _msg;
            string strMsgJson = JsonHelper.ToJson<SenPersonMsg>(_sdMsg);
            this.strUrl = "https://oapi.dingtalk.com/topapi/message/corpconversation/asyncsend_v2?access_token=" + token;
            this.strJson = HttpMethod.PostUrl(this.strUrl, strMsgJson);
            WorkMsgReturn _workMsgReturn = JsonHelper.FromJson<WorkMsgReturn>(this.strJson);
            return _workMsgReturn;
        }



        //第五步 查询工作通知消息的发送结果
        //url https://oapi.dingtalk.com/topapi/message/corpconversation/getsendresult?access_token=ACCESS_TOKEN
        //参数 agent_id 应用 agentId ，task_id  第三步结果 
        public WorkSendOk GetWorkSendOk(string token, string task_id)
        {
            this.strUrl = "https://oapi.dingtalk.com/topapi/message/corpconversation/getsendresult?access_token=" + token + "&agent_id=250353028" + "&task_id=" + task_id;
            this.strJson = HttpMethod.HttpGet(this.strUrl, string.Empty);
            WorkSendOk _workSendOk = JsonHelper.FromJson<WorkSendOk>(this.strJson);
            return _workSendOk;
        }

        //Json字符串转换成Json抽象对象
        //  JObject jo = (JObject)JsonConvert.DeserializeObject(responseString);


    }
}
