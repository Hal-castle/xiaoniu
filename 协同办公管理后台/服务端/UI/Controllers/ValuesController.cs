using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Model;
using RedisBuffer;
using StackExchange.Redis;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private UnitOfWork ff = null;//SqlSugar框架的实体类
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
            ff = new UnitOfWork();
        }
        //获取数据
        [HttpGet]
        public object Get()
        {
            var data = DataSources.GetData<Student>(ff);
            return new { data = data, code = 0 };
        }
        //添加
        [HttpPost]
        public int Add([FromBody] Student stu)
        {
            ff.db<Student>().Insert(stu);//调用实体类，执行添加操作
            DataSources.GetData<Student>(ff, true);//将改动的数据在redis中重新加载
            return 1;
        }
        //删除
        [HttpDelete]
        public bool Del(int Id)
        {
            bool status = ff.db<Student>().Delete(s => s.Id == Id);//调用实体类，执行删除操作
            DataSources.GetData<Student>(ff, true);//将改动的数据在redis中重新加载
            return status;
        }
    }
}