using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //单位人事
    public class Unit_personnelController : Controller
    {
        private UnitOfWork ff = null;//SqlSugar框架的实体类
        private readonly ILogger<ValuesController> _logger;
        //构造函数
        public Unit_personnelController(ILogger<ValuesController> logger)
        {
            _logger = logger;
            ff = new UnitOfWork();
        }
        #region 单位管理
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        
        #region 部门管理

        #endregion
        #region 人员管理

        #endregion
        #region 群组管理

        #endregion
        #region 岗位管理

        #endregion
    }
}
