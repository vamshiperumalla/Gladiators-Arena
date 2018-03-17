using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class Bookingdb
    {
        private projectEntities db;
        public Bookingdb()
        {
            db = new projectEntities();
        }
        public IEnumerable<tbl_GroundBooking> GetAll()
        {
            return db.tbl_GroundBooking.ToList();
        }

        public tbl_GroundBooking GetById(int Id)
        {
            return db.tbl_GroundBooking.Find(Id);
        }
        public void Insert(tbl_GroundBooking booking)
        {
            db.tbl_GroundBooking.Add(booking);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_GroundBooking booking = db.tbl_GroundBooking.Find(Id);
            db.tbl_GroundBooking.Remove(booking);
            Save();
        }
        public void Update(tbl_GroundBooking booking)
        {
            db.Entry(booking).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
