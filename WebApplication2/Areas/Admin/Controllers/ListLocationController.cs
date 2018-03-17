using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ListLocationController : BaseAdminController
    {

        // GET: Admin/ListLocation
        public ActionResult Index(string SortOrder, string SortBy, String Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var location = objBs.locationBs.GetAll();


            if (SortBy == "Location")
            {

                switch (SortOrder)
                {
                    case "Asc":
                        location = location.OrderBy(x => x.LocationName).ToList();
                        break;
                    case "Desc":
                        location = location.OrderByDescending(x => x.LocationName).ToList();
                        break;
                    default:
                        location = location.OrderBy(x => x.LocationName).ToList();
                        break;
                }


            }
            else
            {
                location = location.OrderByDescending(x => x.LocationName).ToList();
            }


            ViewBag.TotalPages = Math.Ceiling(objBs.locationBs.GetAll().Count() / 2.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            location = location.Skip((page - 1) * 2).Take(2);
            return View(location);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                objBs.locationBs.Delete(id);
                TempData["Msg"] = "Deleted Succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {

                TempData["Msg"] = "Deleted failed" + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}