using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationController : BaseAdminController
    {

        // GET: Admin/Location
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Location location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.locationBs.Insert(location);
                    TempData["Msg"] = "created Succesfully";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["Msg"] = "create failed";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e1)
            {

                TempData["Msg"] = "create failed: " + e1.Message;
                return Redirect("Index");
            }


        }
    }
}