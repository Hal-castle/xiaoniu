using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using RedisBuffer;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;

namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StaffController : ControllerBase
    {
        private UnitOfWork ff = null;//SqlSugar框架的实体类
       
        private readonly IConfiguration _configuration;
        private readonly ILogger<StaffController> _logger;

        public StaffController(ILogger<StaffController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            ff = new UnitOfWork();
        }

        //登入
        [HttpGet]
        public IActionResult staffIsExist(string Staff_Account, string Staff_Password)
        {
            var datas = DataSources.GetData<Staff>(ff,true) as IEnumerable<Staff>;

            var queryMessage = datas.SingleOrDefault(item => item.Staff_Account == Staff_Account && item.Staff_Password == Staff_Password);
            if (queryMessage != null)
            {
                var token = new JwtTokenUtil().GetToken(new Users()
                {
                    Name = queryMessage.Staff_Account,
                    Pass = queryMessage.Staff_Password
                }) ;
                var AllPowers = getRolesPowers(queryMessage.Staff_Id);
                var apiUrl = (AllPowers as IEnumerable<Power>).Select(item => item.Paction);
                new RedisHelper().Set(queryMessage.Staff_Id.ToString(), apiUrl, 10);
                return Ok(new { token, AllPowers });
            }
            return BadRequest("用户名密码错误");
        }

   
        [NonAction]
        public IEnumerable<int> getStaffRoles(int staffId)
        {
            var data = DataSources.GetData<Staff_Role>(ff, true) as IEnumerable<Staff_Role>;
            foreach (var item in data)
            {
                if(item.Staff_Id == staffId)
                {
                    yield return item.Role_Id;
                }
            }
        }

        [NonAction]
        public IEnumerable<int> getPowerIds(int[] roleIds)
        {
            var data = DataSources.GetData<Role_Power>(ff, true) as IEnumerable<Role_Power>;
            foreach (var item in data)
            {
                if (roleIds.Contains(item.Role_Id))
                {
                    yield return item.Power_Id;
                }
            }
        }

        //获取角色的权限
        [NonAction]
        public object getRolesPowers(int staffId)
        {
            //获取角色id
           int[] roleIds =  getStaffRoles(staffId).ToArray();
            //获取权限id
           int[] PowerIds = getPowerIds(roleIds) .ToArray();
            //获取权限
            var data = DataSources.GetData<Power>(ff, true) as IEnumerable<Power>;
            IEnumerable<Power> Powers = data.Where(item => PowerIds.Contains(item.Pid));
            var datas=  Powers.ToList();
            return data;
        }

        [Authorize]
        [TokenFilter]
        [HttpGet]
        public object All()
        {
            return new string[] { "张三", "李四" };
        }


        //系统过滤 验证token是否通过
        [Authorize]
        //自定义过滤 验证token权限
        [TokenFilter]

        [HttpGet]
        public object All1()
        {
            return new string[] { "呵呵", "你猜" };
        }
    }
}
