using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UI;

namespace 客户端1.Controllers
{
    //使用过滤器
    [MyActionFilter]
    public class HomePageController : Controller
    {
        //主界面
        
        public IActionResult Index()
        {
            //登入后保存sesscion
            HttpContext.Session.SetString("Use", "123");
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
    }
}
