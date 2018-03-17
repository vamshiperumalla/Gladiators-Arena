using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace WebApplication2.Areas.Security.Controllers
{   
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_User user)
        {
            //string role = form["Role"].ToString();

      

            
            //else
            //{
            //    if(role=="Facility Manager")
            //    {
            //        user.Role = "Facilty Manager";
            //    }
            //    else
            //    {
            //        user.Role = "Player";
            //    }
            //}
            try
            {
                if (user.Role == null)
                {
                    TempData["Msg"] = "Role is not selected";
                    string role = null;
                }
                else
                {
                    string role = user.Role.ToString();
                }


                
                

                if (ModelState.IsValid)
                {


                    objBs.userBs.Insert(user);
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
                return RedirectToAction("Index");
            }



        }
    }
}