﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        protected AdminBs objBs;
        public BaseAdminController()
        {
            objBs = new AdminBs();
        }
    }
}