using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UI
{
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.RouteData.Values["controller"].ToString();
            var actionName = context.RouteData.Values["action"].ToString();
            var url ="/" + controllerName + "/" + actionName;

            
            
            //这里改login
            if (actionName == "Index" || controllerName == "Help" || actionName == "Error")
            {
                return;
            }
            //判断用户是否登入
           base.OnActionExecuting(context);
           var AllUrl = context.HttpContext.Session.GetString("useUrls");

            //如果未登入放回登入界面
            if (AllUrl == null)
            {
                context.HttpContext.Response.Redirect("/HomePage/Index");
                return;
            }

            var urls = AllUrl.Length == 0 ? new List<string>(): AllUrl.Split(',').ToList();

            //如果访问界面包含权限
            foreach (var item in urls)
            {
                if (url == item)
                {
                    return;
                }
            }
            //返回错误界面(无权限)
            context.HttpContext.Response.Redirect("/Home/Error");
        }

    }
}
