using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WebApplication2.Areas.facilitymanager.Controllers
{
    [Authorize(Roles = "Facility Manger")]
    public class groundController : BaseFacilityManagerController
    {



        // GET: facilitymanger/ground
        public ActionResult Index()
        {
            projectEntities db = new projectEntities();
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll().ToList(), "CategoryId", "CategoryName");
            ViewBag.LocationId = new SelectList(objBs.locationBs.GetAll().ToList(), "LocationId", "LocationName");
            ViewBag.UserId = new SelectList(objBs.userBs.GetAll().ToList(), "UserId", "UserEmail");

            return View();
        }

        [HttpPost]
        public ActionResult Submit(tbl_Ground ground, HttpPostedFileBase Image)
        {


            if (Image != null)
            {

                byte[] image = new byte[Image.ContentLength];

                Image.InputStream.Read(image, 0, Image.ContentLength);
                ground.GroundImage = image;

            }

            try
            {
                ground.IsApproved = "P";
                ground.UserId = objBs.userBs.GetAll().Where(X => X.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors }) 
                    .ToArray();
                }
                if (ModelState.IsValid)
                {


                    objBs.groundBs.Insert(ground);
                    TempData["Msg"] = "submited Succesfully";
                    return RedirectToAction("Index");

                }
                else
                {

                    TempData["Msg"] = "submit failed";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e1)
            {

                TempData["Msg"] = "submit failed: " + e1.Message;
                return Redirect("Index");
            }


        }
    }
}