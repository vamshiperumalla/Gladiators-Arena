using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WebApplication2.Areas.Player.Controllers
{
    [Authorize(Roles = "Player")]
    public class BrowseGroundsController : BasePlayerController
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
                return View(grounds);

            }
            else if (selectedcategory != null && selectedLocation == null)
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "A" && x.CategoryId == selectedcategory);
                return View(grounds);

            }
            else if (selectedLocation != null && selectedcategory == null)
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "A" && x.CategoryId == selectedcategory);
                return View(grounds);

            }
            else
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "A" && x.CategoryId == selectedcategory && x.LocationId == selectedLocation);
                return View(grounds);
            }


        }
        public ActionResult GroundDetails(int GroundId)
        {
            var gr = objBs.groundBs.GetById(GroundId);
            return View(gr);
        }
    }
}