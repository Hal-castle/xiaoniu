using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using RedisBuffer;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;


namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class StaffController : ControllerBase
    {
        private UnitOfWork ff = null;//SqlSugar框架的实体类

        private readonly ILogger<StaffController> _logger;

        public StaffController(ILogger<StaffController> logger)
        {
            _logger = logger;
            ff = new UnitOfWork();
        }

        //登入
        [HttpGet]
        public bool staffIsExist(string Staff_Account, string Staff_Password)
        {
            //获取用户数据
            var datas = DataSources.GetData<Staff>(ff) as IEnumerable<Staff>;
            var queryMessage = datas.SingleOrDefault(item => item.Staff_Account == Staff_Account && item.Staff_Password == Staff_Password);
            if (queryMessage != null)
            {
                return true;
            }
            return false;
        }

        //获取用户的角色
        [HttpGet]
        public IEnumerable<int> getStaffRoles(int id)
        {
            //获取用户所有角色的id
            foreach (var item in (DataSources.GetData<Staff_Role>(ff) as IEnumerable<Staff_Role>).Where(item => item.Staff_Id == id))
            {
                yield return item.Role_Id;
            }
        }
        //获取角色的权限
        [HttpGet]
        public List<Power> getRolesPowers(int staffId)
        {
            var Cache = new RedisHelper();
            int[] roleIds = getStaffRoles(staffId).ToArray();

            if (!Cache.IsSet("Powers"))
            {
                int[] PowerIds = (DataSources.GetData<Role_Power>(ff) as IEnumerable<Role_Power>)
                .Where(item => roleIds.Contains(item.Role_Id))
                .Select(item => item.Role_Id)
                .ToArray();

                IEnumerable<Power> Powers = (DataSources.GetData<Power>(ff) as IEnumerable<Power>)
                    .Where(item => PowerIds.Contains(item.Pid));

                Cache.Set("Powers", Powers, 10);
            }
            return Cache.Get<IEnumerable<Power>>("Powers").ToList();
        }
    }
}
