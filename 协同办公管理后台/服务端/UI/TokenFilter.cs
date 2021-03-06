﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SqlSugar;
using Model;
using Newtonsoft.Json;
using RedisBuffer;
using Microsoft.AspNetCore.Mvc;

namespace UI
{
    public class TokenFilter : ActionFilterAttribute
    {
        UnitOfWork ff = new UnitOfWork();

        //token全局过滤
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //获取token
            string str = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (str != null)
            {
                var Uncode = new JwtTokenUtil().UpToken(str);
                Users use = JsonConvert.DeserializeObject<Users>(Uncode);

                //获取用户
                var uses = (DataSources.GetData<Staff>(ff) as IEnumerable<Staff>)
                                .Where(item => item.Staff_Account == use.Name)
                                .Where(item => item.Staff_Password == use.Pass)
                                .SingleOrDefault();
                             
                if (uses != null)
                {
                    var controllerName = context.RouteData.Values["controller"].ToString();
                    var actionName =     context.RouteData.Values["action"].ToString();
                    var url = "/" + controllerName + "/" + actionName;
                    var allPowers = new RedisHelper().Get<IEnumerable<Power>>(uses.Staff_Id.ToString());
                    if (allPowers != null)
                    {
                        foreach (var item in allPowers)
                        {
                            if (item.Paction == url)
                            {
                                return;
                            }
                        }
                    }
                }
            }
            //返回404
            context.HttpContext.Response.Redirect("/Staff/Error");
        }
    }
}
