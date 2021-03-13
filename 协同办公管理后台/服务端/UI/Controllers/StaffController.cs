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

using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;


namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StaffController : ControllerBase
    {

        #region
        private UnitOfWork ff = null;//SqlSugar框架的实体类
        private readonly IConfiguration _configuration;
        private readonly ILogger<StaffController> _logger;

        public StaffController(ILogger<StaffController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            ff = new UnitOfWork();
        }
        #endregion
        //接口测试
        #region
        [Authorize]
        [TokenFilter]
        [HttpGet]
        public object All()
        {
            return new string[] { "张三", "李四" };
        }

        [Authorize]
        [TokenFilter]
        [HttpGet]
        public object All1()
        {
            return new string[] { "呵呵", "你猜" };
        }

        public object Error()
        {
            return new {message = "无权访问" };
        }
        #endregion
        //数据获取
        #region
        
        [NonAction]
        public IEnumerable<int> getStaffRoles(int staffId)
        {
            var data = DataSources.GetData<Staff_Role>(ff, true) as IEnumerable<Staff_Role>;
            foreach (var item in data)
            {
                if (item.Staff_Id == staffId)
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
        [NonAction]
        public object getRolesPowers(int staffId)
        {
            //获取角色id
            int[] roleIds = getStaffRoles(staffId).ToArray();
            //获取权限id
            int[] PowerIds = getPowerIds(roleIds).ToArray();
            //获取权限
            var data = DataSources.GetData<Power>(ff, true) as IEnumerable<Power>;
            IEnumerable<Power> Powers = data.Where(item => PowerIds.Contains(item.Pid));
            var datas = Powers.ToList();
            return datas;
        }
        #endregion



        //用户注册
        public object Registered(Staff sta)
        {
            return null;
        }
        //用户登入
        public object Login(string LoginType, string Name = "",string Pass = "",int Phone = 0)
        {
            Staff data = null;
            var allData = DataSources.GetData<Staff>(ff, true);
            switch (LoginType)
            {
                case "Pass":
                    data = allData.Where(item => item.Staff_Password == Pass).
                               Where(item => item.Staff_Account == Name).SingleOrDefault();
                    break;
                case "Phone":
                    data = allData.Where(item => item.Staff_Phone == Phone).SingleOrDefault();
                    break;
            }
            if (data == null) return new { code = 1 };

            string Token = new JwtTokenUtil().GetToken(data.Staff_Account, data.Staff_Password);

            return new { code = 0, Token };
        }

        //主界面加载信息
        public object LoadPower()
        {
            string str = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            try
            {
                var Uncode = new JwtTokenUtil().UpToken(str);
                Users use = JsonConvert.DeserializeObject<Users>(Uncode);
                var uses = (DataSources.GetData<Staff>(ff) as IEnumerable<Staff>)
                                .Where(item => item.Staff_Account == use.Name)
                                .Where(item => item.Staff_Password == use.Pass)
                                .SingleOrDefault();
                var allPowers = getRolesPowers(uses.Staff_Id);
                new RedisHelper().Set(uses.Staff_Id.ToString(), allPowers, 10);
                return new { code = 0, allPowers };
            }
            catch { }
            return new { code = 1 };
        }
    }
}
