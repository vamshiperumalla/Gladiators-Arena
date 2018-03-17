using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApproveGroundController : BaseAdminController
    {
        // GET: Admin/ApproveGround
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == "P").ToList();
                if (grounds.Count()==0)
                {
                    TempData["Msg"] = "No Pending Grounds";
                }
                return View(grounds);
            }
            else
            {
                var grounds = objBs.groundBs.GetAll().Where(x => x.IsApproved == Status).ToList();
                return View(grounds);
            }

        }

        public ActionResult GroundDetails(int GroundId)
        {
            var gr = objBs.groundBs.GetById(GroundId);
            return View(gr);
        }

        
        public ActionResult Approve(int id)
        {
            try
            {
                var ground = objBs.groundBs.GetById(id);
                ground.IsApproved = "A";
                objBs.groundBs.Update(ground);
                TempData["Msg"] = "Approved succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Approve Failed: " + e1.Message;
                return RedirectToAction("Index");
            }

        }
        public ActionResult Reject(int id)
        {
            try
            {
                var ground = objBs.groundBs.GetById(id);
                ground.IsApproved = "R";
                objBs.groundBs.Update(ground);
                TempData["Msg"] = "Rejected  succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Reject Failed: " + e1.Message;
                return RedirectToAction("Index");
            }
        }

    }
}