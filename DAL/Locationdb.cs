using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class Locationdb
    {
        private projectEntities db;
        public Locationdb()
        {
            db = new projectEntities();
        }
        public IEnumerable<tbl_Location> GetAll()
        {
            return db.tbl_Location.ToList();
        }

        public tbl_Location GetById(int Id)
        {
            return db.tbl_Location.Find(Id);
        }
        public void Insert(tbl_Location location)
        {
            db.tbl_Location.Add(location);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_Location location = db.tbl_Location.Find(Id);
            db.tbl_Location.Remove(location);
            Save();
        }
        public void Update(tbl_Location location)
        {
            db.Entry(location).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
