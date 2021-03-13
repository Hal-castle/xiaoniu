using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UI;
using System.Net;
using System.IO;
using System.Text;

namespace 客户端1.Controllers
{
    public class HomePageController : Controller
    {
        //主界面

        public static string PostUrl = "http://106.ihuyi.cn/webservice/sms.php?method=Submit";
        [HttpPost]
        public IActionResult Yzm(string Phone)
        {
            string account = "C81436469";//用户名是登录用户中心->验证码、通知短信->帐户及签名设置->APIID
            string password = "a1b769cab5ae6b8bf75393fb086c8b5c"; //密码是请登录用户中心->验证码、通知短信->帐户及签名设置->APIKEY

            Random rad = new Random();
            int mobile_code = rad.Next(1000, 10000);
            string content = "您的验证码是：" + mobile_code + " 。请不要把验证码泄露给其他人。";

            //Session["mobile"] = mobile;
            //Session["mobile_code"] = mobile_code;

            string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";

            UTF8Encoding encoding = new UTF8Encoding();
            byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, Phone, content));

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = postData.Length;

            Stream newStream = myRequest.GetRequestStream();
            // Send the data.
            newStream.Write(postData, 0, postData.Length);
            newStream.Flush();
            newStream.Close();

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            if (myResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

                //Response.Write(reader.ReadToEnd());

                string res = reader.ReadToEnd();
                int len1 = res.IndexOf("</code>");
                int len2 = res.IndexOf("<code>");
                string code = res.Substring((len2 + 6), (len1 - len2 - 6));
                //Response.Write(code);

                int len3 = res.IndexOf("</msg>");
                int len4 = res.IndexOf("<msg>");
                string msg = res.Substring((len4 + 5), (len3 - len4 - 5));

                return Ok(mobile_code);
            }
            else
            {
                return Ok(0);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registered()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }

        //单位人事
        //单位管理
        public IActionResult Unit_management()
        {
            return View();
        }
        //部门管理
        public IActionResult Division_management()
        {
            return View();
        }
        //人员管理
        public IActionResult People_management()
        {
            return View();
        }
        //群组管理
        public IActionResult Group_management()
        {
            return View();
        }
        //岗位管理 
        public IActionResult Post_management()
        {
            return View();
        }
        //应用管理
        //接入应用
        public IActionResult Access_application()
        {
            return View();
        }
        //开发商管理
        public IActionResult Developer_Management()
        {
            return View();
        }
        //应用分类
        public IActionResult Application_classification()
        {
            return View();
        }
        //操作日志
        public IActionResult Operation_log()
        {
            return View();
        }



        //公众号
        //公众号管理
        public IActionResult Account_Management()
        {
            return View();
        }


        //流程管理
        //流程管理
        public IActionResult Process_management()
        {
            return View();
        }
        //工单管理
        public IActionResult Workorder_management()
        {
            return View();
        }


        //系统管理
        //角色管理
        public IActionResult Role_management()
        {
            return View();
        }
        //字典管理
        public IActionResult Dictionary_management()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
