using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WebApplication2.Areas.common.Controllers
{
    [AllowAnonymous]
    public class BrowseGroundsController : BaseCommonController
    {

        // GET: common/Grounds
        public ActionResult Index()
        {
            projectEntities db = new projectEntities();
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.LocationId = new SelectList(objBs.locationBs.GetAll().ToList(), "LocationId", "LocationName");
            return View();
        }
        [HttpPost]
        public ActionResult Submit(tbl_Ground grd)
        {
            int? selectedcategory = grd.CategoryId;
            int? selectedLocation = grd.LocationId;

            if (selectedcategory == null && selectedLocation == null)
            {
               
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "A");
                if(grounds.Count()==0)
                {
                    TempData["Msg"] = "No Grounds In The Prefered Selection";
                }
                return View(grounds);

            }
            else if (selectedcategory != null && selectedLocation == null)
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "A" && x.CategoryId == selectedcategory);
                if (grounds.Count() == 0)
                {
                    TempData["Msg"] = "No Grounds In The Prefered Selection";
                }
                return View(grounds);

            }
            else if (selectedLocation != null && selectedcategory == null)
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "A" && x.CategoryId == selectedcategory);
                if (grounds.Count() == 0)
                {
                    TempData["Msg"] = "No Grounds In The Prefered Selection";
                }
                return View(grounds);

            }
            else
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "A" && x.CategoryId == selectedcategory && x.LocationId == selectedLocation);
                if (grounds.Count()==0 )
                {
                    TempData["Msg"] = "No Grounds In The Prefered Selection";
                }
                return View(grounds);
            }

            
        }
        public ActionResult GroundDetails(int GroundId)
        {
            
            var gr = objBs.groundBs.GetById(GroundId);
            TempData["Data"] = gr.GroundId;
            return View(gr);
        }
    }
}