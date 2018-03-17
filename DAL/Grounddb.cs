using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class Grounddb
    {
        private projectEntities db;
        public Grounddb()
        {
            db = new projectEntities();
        }
        public IEnumerable<tbl_Ground> GetAll()
        {
            return db.tbl_Ground.ToList();
        }

        public tbl_Ground GetById(int Id)
        {
            return db.tbl_Ground.Find(Id);
        }
        public void Insert(tbl_Ground ground)
        {
            db.tbl_Ground.Add(ground);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_Ground ground = db.tbl_Ground.Find(Id);
            db.tbl_Ground.Remove(ground);
            Save();
        }
        public void Update(tbl_Ground ground)
        {
            db.Entry(ground).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
