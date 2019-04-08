using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DDAPIEntity;

namespace TestDingDingApiPost
{
    class Program
    {

        static void Main(string[] args)
        {
            DDAPI _dDAPI = new DDAPI();
            string strToken = _dDAPI.GetAcessTocken();

            ProcessInstance _processInstance = _dDAPI.GetProsListId(strToken);

            foreach (var item in _processInstance.result.list)
            {
                ProcessDetail _processDetail = _dDAPI.GetProsDetial(strToken, item);

                WorkMsgReturn _workMsgReturn = _dDAPI.DoPostPerson(strToken, _processDetail);

               // 检查数据是否真实发送
                 WorkSendOk _workSendOk = _dDAPI.GetWorkSendOk(strToken, _workMsgReturn.task_id);

            }

            //ProcessDetail _processDetail = _dDAPI.GetProsDetial(strToken, _processInstance.result.list[0]);

            //WorkMsgReturn _workMsgReturn = _dDAPI.DoPostPerson(strToken, _processDetail);

            Console.WriteLine("执行成功");
            Console.ReadLine();
        }
    }
}