using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace WebApplication2.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        protected SecurityBs objBs;
        public BaseSecurityController()
        {
            objBs = new SecurityBs();
        }
    }
}