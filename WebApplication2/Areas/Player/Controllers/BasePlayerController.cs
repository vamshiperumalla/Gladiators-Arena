using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace WebApplication2.Areas.Player.Controllers
{
    public class BasePlayerController : Controller
    {
        protected PlayerBs objBs;
        public BasePlayerController()
        {
            objBs = new PlayerBs();
        }
    }
}