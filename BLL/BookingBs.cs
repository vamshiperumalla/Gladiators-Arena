using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class BookingBs
    {
        private Bookingdb objdb;
       

        public BookingBs()
        {
            objdb = new Bookingdb();

        }
        public IEnumerable<tbl_GroundBooking> GetAll()
        {
            return objdb.GetAll();
        }

        public tbl_GroundBooking GetById(int Id)
        {
            return objdb.GetById(Id);
        }
        public void Insert(tbl_GroundBooking booking)
        {
            objdb.Insert(booking);

        }
        public void Delete(int Id)
        {

            objdb.Delete(Id);

        }
        public void Update(tbl_GroundBooking booking)
        {
            objdb.Update(booking);
        }
    }
}
