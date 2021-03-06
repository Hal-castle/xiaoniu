using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;
using RedisBuffer;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplyManageController : ControllerBase
    {
        private UnitOfWork ff = null;//SqlSugar框架的实体类
        private readonly ILogger<ApplyManageController> _logger;

        public ApplyManageController(ILogger<ApplyManageController> logger)
        {
            _logger = logger;
            ff = new UnitOfWork();
        }
        #region 接入应用

        //获取数据
        [HttpGet]
        public object Get(int page, int limit, int apptype = 0, int status = 2, string Name = "")
        {
            //var data = DataSources.GetData<InsertApply>(ff);
            var data = ff.db<InsertApply>().GetList();
            if (!string.IsNullOrEmpty(Name))
                data = data.Where(s => s.InsertApply_Name.Contains(Name) || s.InsertApply_encoding.Equals(Name)).ToList();
            if (apptype != 0)
                data = data.Where(s => s.AppType.Equals(apptype)).ToList();
            if (status != 2)
                data = data.Where(s => s.InsertApply_tatus.Equals(status)).ToList();
            int count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            return new { data = data, code = 0, count = count };
        }
        public void AddLog(string Name, string Apply, string Type, string Content)
        {
            ULog u = new ULog();
            u.Uname = Name;
            u.Utimes = DateTime.Now;
            u.Uapply = Apply;
            u.Utype = Type;
            u.Ucontent = Content;
            ff.db<ULog>().Insert(u);
        }
        //添加
        [HttpPost]
        public bool Add([FromBody] InsertApply app)
        {
            app.InsertApply_ChangeTime = DateTime.Now;
            app.InsertApply_tatus = 0;
            bool status = ff.db<InsertApply>().Insert(app);//调用实体类，执行添加操作
            DataSources.GetData<InsertApply>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        //删除
        [HttpDelete]
        public bool Del(string Ids)
        {
            var begin = DateTime.Now.Second;
            dynamic[] dynamics = Ids.Split(",");
            
            ThreadStart threadStart = new ThreadStart(delegate ()
            {
                bool status = ff.db<InsertApply>().Delete(dynamics);//调用实体类，执行删除操作
            });
            Thread thread = new Thread(threadStart);
            thread.Start();//多线程启动匿名方法
            var zhong = DateTime.Now.Second;
            DataSources.GetData<InsertApply>(ff, true);//将改动的数据在redis中重新加载
            //等待线程结束
            while (thread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                Thread.Sleep(10);
            }
            var end = DateTime.Now.Second;
            return true;
        }
        //修改
        [HttpPut]
        public bool Put(InsertApply InsertApply)
        {
            InsertApply.InsertApply_ChangeTime = DateTime.Now;
            InsertApply.InsertApply_tatus = 0;
            bool status = ff.db<InsertApply>().Update(InsertApply);//调用实体类，执行删除操作
            DataSources.GetData<InsertApply>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        //获取所有的角色
        public object GetRole(int page, int limit)
        {
            var data = DataSources.GetData<Role>(ff);
            int count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            return new { data = data, code = 0, count = count };
        }
        #endregion
        #region 应用分类
        //获取数据
        public object GetAppArrange(int page, int limit, string Name = null)
        {
            var data = DataSources.GetData<AppArrange>(ff);
            if (!string.IsNullOrEmpty(Name))
                data = data.Where(s => s.Aname.Contains(Name) || s.APost_code.Equals(Name)).ToList();
            int count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            return new { data = data, code = 0, count = count };
        }
        //添加
        [HttpPost]
        public bool AddAppArrange([FromBody] AppArrange app)
        {
            app.Atimes = DateTime.Now;
            app.APost_code = "0001";
            bool status = ff.db<AppArrange>().Insert(app);//调用实体类，执行添加操作
            DataSources.GetData<AppArrange>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        //删除
        [HttpDelete]
        public bool DelAppArrange(string Ids)
        {
            dynamic[] dynamics = Ids.Split(",");
            bool status = ff.db<AppArrange>().Delete(dynamics);//调用实体类，执行删除操作
            DataSources.GetData<AppArrange>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        //修改
        [HttpPut]
        public bool PutAppArrange(AppArrange AppArrange)
        {
            AppArrange.Atimes = DateTime.Now;
            AppArrange.APost_code = "0001";
            bool status = ff.db<AppArrange>().Update(AppArrange);//调用实体类，执行删除操作
            DataSources.GetData<AppArrange>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        #endregion
        #region 开发商管理
        //获取数据
        public object GetDevelopers(int page, int limit, string Name = null)
        {
            var data = DataSources.GetData<Developers>(ff);
            if (!string.IsNullOrEmpty(Name))
                data = data.Where(s => s.Developers_Name.Contains(Name) || s.Developers_encoding.Equals(Name)).ToList();
            int count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            return new { data = data, code = 0, count = count };
        }
        //添加
        [HttpPost]
        public bool AddDevelopers([FromBody] Developers app)
        {
            app.Developers_changetime = DateTime.Now;
            bool status = ff.db<Developers>().Insert(app);//调用实体类，执行添加操作
            DataSources.GetData<Developers>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        //删除
        [HttpDelete]
        public bool DelDevelopers(string Ids)
        {
            dynamic[] dynamics = Ids.Split(",");
            bool status = ff.db<Developers>().Delete(dynamics);//调用实体类，执行删除操作
            DataSources.GetData<Developers>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        //修改
        [HttpPut]
        public bool PutDevelopers(Developers Developers)
        {
            Developers.Developers_changetime = DateTime.Now;
            bool status = ff.db<Developers>().Update(Developers);//调用实体类，执行删除操作
            DataSources.GetData<Developers>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
        #endregion
        #region 日志管理
        //获取数据
        public object GetULog(int page, int limit, string begin = null, string end = null, string Name = null)
        {
            var data = DataSources.GetData<ULog>(ff);
            if (!string.IsNullOrEmpty(begin))
            {
                var begintime = Convert.ToDateTime(begin);
                data = data.Where(s => DateTime.Compare(begintime, s.Utimes) <= 0).ToList();
            }
            if (!string.IsNullOrEmpty(end))
            {
                var endtime = Convert.ToDateTime(end);
                data = data.Where(s => DateTime.Compare(endtime, s.Utimes) >= 0).ToList();
            }
            if (!string.IsNullOrEmpty(Name))
                data = data.Where(s => s.Uname.Contains(Name) || s.Uapply.Equals(Name)).ToList();
            int count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            return new { data = data, code = 0, count = count };
        }
        #endregion
    }
}