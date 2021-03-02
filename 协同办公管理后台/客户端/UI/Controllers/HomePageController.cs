using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace 客户端1.Controllers
{
    public class HomePageController : Controller
    {
        //主界面
        public IActionResult Index()
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
            //var result= Common.HttpHelper.GetApiResult("get", "api/ApplyManage/Get");
            //List<object> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(result);
            //ViewBag.List=list;
            return View();
        }
        /// <summary>
        /// 图片上传并存入数据库
        /// </summary>
        /// <returns></returns>
        public object InsertPicture([FromForm] IFormCollection formData)
        {
            IFormFile uploadfile = formData.Files[0];
            if (uploadfile != null)
            {
                //文件后缀
                var fileExtension = Path.GetExtension(uploadfile.FileName);
                var strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff"); //取得时间字符串
                var strRan = Convert.ToString(new Random().Next(100, 999)); //生成三位随机数
                var saveName = strDateTime + strRan + fileExtension;
                var path = "Img";
                var di = ("/" + path + "/" + saveName);
                var bi = Path.Combine("wwwroot",path);
                if (!Directory.Exists(bi))
                {
                    Directory.CreateDirectory(bi);
                }
                using (FileStream fs = System.IO.File.Create(Path.Combine(bi, saveName)))
                {
                    uploadfile.CopyTo(fs);
                    fs.Flush();
                }
                return new { code = 0, path = di };
            }
            return new { code = 1 };
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
    }
}
