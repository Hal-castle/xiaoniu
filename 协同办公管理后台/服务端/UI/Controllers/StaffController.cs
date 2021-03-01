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
        public IEnumerable<int> getStaffRoles(int staffId)
        {
            var data = DataSources.GetData<Staff_Role>(ff, true) as IEnumerable<Staff_Role>;
            //获取用户所有角色的id
            foreach (var item in data)
            {
                if(item.Staff_Id == staffId)
                {
                    yield return item.Role_Id;
                }
            }
        }

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
        [HttpGet]
        public List<Power> getRolesPowers(int staffId,int prevId = 0)
        {
            //获取角色id
           int[] roleIds =  getStaffRoles(staffId).ToArray();
            //获取权限id
           int[] PowerIds = getPowerIds(roleIds) .ToArray();
            //获取权限
            var data = DataSources.GetData<Power>(ff, true) as IEnumerable<Power>;
            IEnumerable<Power> Powers = data.Where(item => PowerIds.Contains(item.Pid));

            if(prevId != 0)
            {
                Powers = Powers.Where(item => item.Pprev_authority == prevId);
            }

            var datas=  Powers.ToList();
            return datas;
        }
    }
}
