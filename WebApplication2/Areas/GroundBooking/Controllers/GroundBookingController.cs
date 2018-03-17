using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace WebApplication2.Areas.GroundBooking.Controllers
{
    [Authorize(Roles = "Player")]
    public class GroundBookingController : BaseGroundBookingController
    {
        // GET: GroundBooking/GroundBooking
        [HttpGet]
        public ActionResult Index(tbl_GroundBooking booking)
        {
           
            var Data = TempData["Data"];
            TempData.Keep("Data");
            booking.GroundId = (int)Data;
            IEnumerable<DateTime?> dates= objBs.bookingBs.GetAll().Where(x => x.GroundId == (int)Data).Select(x=>x.Date);

            //string dayonly = dates.ToString();


            var day = dates.ToArray();
           
            ViewBag.Day= day;

            return View();
            
        }
        [HttpPost] 
        public ActionResult Submit(tbl_GroundBooking booking, FormCollection form)
        {
            
            
  
            try
            {
                    String name = Request["datepicker"];
                DateTime oDate = Convert.ToDateTime(name);
                var day = oDate.Date;


                projectEntities tb = new projectEntities();

                var Data = TempData["Data"];
                TempData.Keep("Data");
                IEnumerable<DateTime?> dates = objBs.bookingBs.GetAll().Where(x => x.GroundId == (int)Data).Select(x => x.Date);

                //string dayonly = dates.ToString();
              

                var bookeddates = dates.ToArray();
                booking.GroundId = (int)Data;
                booking.UserId = objBs.userBs.GetAll().Where(X => X.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                
                booking.LocationId = objBs.groundBs.GetAll().Where(x => x.GroundId == (int)Data).FirstOrDefault().LocationId;
                booking.CategoryId = objBs.groundBs.GetAll().Where(x => x.GroundId == (int)Data).FirstOrDefault().CategoryId;
                booking.Date = day;

               

                
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                }
                if (ModelState.IsValid)
                {
                    //DateTime[] bookeddates;
                   
                    if (bookeddates.Length==0)
                    {
                        if (TempData["Data"] != null)
                        {
                            objBs.bookingBs.Insert(booking);
                            TempData["Msg"] = "Ground Booked Successfully";
                        }
                        
                    }
                    else
                    {

                        if (TempData["Data"] != null)
                        {

                            int count = bookeddates.Length;

                            List<string> value = new List<string>();
                            for (int i = 0; i < count; i++)

                            {

                                value.Add(bookeddates[i].ToString());





                            }
                            var array = value.ToArray();
                            if (array.Contains(day.ToString()))
                            {
                                TempData["Msg"] = "Sorry No availability on this Date";
                            }
                            else
                            {
                                objBs.bookingBs.Insert(booking);
                                TempData["Msg"] = "Ground Booked Successfully";
                            }
                        }

                    }

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
        
        public ActionResult Index1()
        {
            return View();
        }
            
        
        
        
    }
}