using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ListUsersController : BaseAdminController
    {


        // GET: Admin/ListUsers
        public ActionResult Index(string SortOrder, string SortBy, String Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var users = objBs.userBs.GetAll();

            switch (SortBy)
            {
                case "UserName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserName).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.UserName).ToList();
                            break;
                        default:
                            users = users.OrderBy(x => x.UserName).ToList();
                            break;
                    }
                    break;
                case "UserEmail":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                        default:
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                    }
                    break;
                case "Role":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Role).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            users = users.OrderBy(x => x.Role).ToList();
                            break;
                    }
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetAll().Count() / 2.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            users = users.Skip((page - 1) * 2).Take(2);
            return View(users);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                objBs.userBs.Delete(id);
                TempData["Msg"] = "Deleted Succesfully";
                return Redirect("Index");
            }
            catch (Exception e1)
            {

                TempData["Msg"] = "Deleted failed" + e1.Message;
                return Redirect("Index");
            }
        }
    }
}