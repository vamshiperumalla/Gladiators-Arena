using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace WebApplication2.Areas.common.Controllers
{
    public class BaseCommonController : Controller
    {
        protected CommonBs objBs;
        public BaseCommonController()
        {
            objBs = new CommonBs();
        }
    }
}