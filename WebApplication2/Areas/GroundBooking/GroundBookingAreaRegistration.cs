using System.Web.Mvc;

namespace WebApplication2.Areas.GroundBooking
{
    public class GroundBookingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GroundBooking";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GroundBooking_default",
                "GroundBooking/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}