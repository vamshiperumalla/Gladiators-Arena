using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : BaseAdminController
        {

            // GET: Admin/Category
            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(tbl_Category category)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        objBs.categoryBs.Insert(category);
                        TempData["Msg"] = "created Succesfully";
                        return Redirect("Index");

                    }
                    else
                    {
                        TempData["Msg"] = "create failed";
                        return Redirect("Index");
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