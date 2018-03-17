﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;

namespace DAL
{
    public class Userdb
    {
        private projectEntities db;
        public Userdb()
        {
            db = new projectEntities();
        }
        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetById(int Id)
        {
            return db.tbl_User.Find(Id);
        }
        public void Insert(tbl_User user)
        {
            db.tbl_User.Add(user);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_User user = db.tbl_User.Find(Id);
            db.tbl_User.Remove(user);
            Save();
        }
        public void Update(tbl_User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}