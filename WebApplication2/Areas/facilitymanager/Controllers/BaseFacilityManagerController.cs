using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace WebApplication2.Areas.facilitymanager.Controllers
{
    public class BaseFacilityManagerController : Controller
    {
        protected FacilityManagerBs objBs;
        public BaseFacilityManagerController()
        {
            objBs = new FacilityManagerBs();
        }
    }
}