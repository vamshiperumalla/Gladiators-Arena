using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace WebApplication2.Areas.GroundBooking.Controllers
{
    public class BaseGroundBookingController : Controller
    {
        protected GroundBookingBs objBs;
        public BaseGroundBookingController()
        {
            objBs = new GroundBookingBs();
        }
    }
}