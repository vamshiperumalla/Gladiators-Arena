using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class Categorydb
    {
        private projectEntities db;
        public Categorydb()
        {
            db = new projectEntities();
        }
        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }

        public tbl_Category GetById(int Id)
        {
            return db.tbl_Category.Find(Id);
        }
        public void Insert(tbl_Category category)
        {
            db.tbl_Category.Add(category);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_Category category = db.tbl_Category.Find(Id);
            db.tbl_Category.Remove(category);
            Save();
        }
        public void Update(tbl_Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
