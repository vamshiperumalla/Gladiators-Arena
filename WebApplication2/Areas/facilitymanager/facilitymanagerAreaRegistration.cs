using System.Web.Mvc;

namespace WebApplication2.Areas.facilitymanager
{
    public class facilitymanagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "facilitymanager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "facilitymanager_default",
                "facilitymanager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}