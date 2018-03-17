using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {
        public CategoryBs categoryBs { get; set; }
        public LocationBs locationBs { get; set; }
        public UserBs userBs { get; set; }
        public GroundBs groundBs { get; set; }
        public BookingBs bookingBs { get; set; }

        public BaseBs()
        {
            categoryBs = new CategoryBs();
            locationBs = new LocationBs();
            userBs = new UserBs();
            groundBs = new GroundBs();
            bookingBs = new BookingBs();

        }
    }
}
