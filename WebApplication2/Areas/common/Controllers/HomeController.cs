using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.common.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: common/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}