using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ListCategoryController : BaseAdminController
    {


        public ActionResult Index(string SortOrder, string SortBy, String Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var category = objBs.categoryBs.GetAll();

            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            category = category.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            category = category.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            category = category.OrderBy(x => x.CategoryName).ToList();
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            category = category.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            category = category.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            category = category.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                    }
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.categoryBs.GetAll().Count() / 2.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            category = category.Skip((page - 1) * 2).Take(2);
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                objBs.categoryBs.Delete(id);
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