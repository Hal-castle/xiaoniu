using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace UI.Controllers
{
    public class HelpController : Controller
    {
        
        public bool LoadUrls(string urls)
        {
            try
            {
                HttpContext.Session.SetString("useUrls", urls);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
