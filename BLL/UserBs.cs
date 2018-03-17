using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class UserBs
    {
        private Userdb objdb;
        public UserBs()
        {
            objdb = new Userdb();

        }
        public IEnumerable<tbl_User> GetAll()
        {
            return objdb.GetAll();
        }

        public tbl_User GetById(int Id)
        {
            return objdb.GetById(Id);
        }
        public void Insert(tbl_User user)
        {
            objdb.Insert(user);

        }
        public void Delete(int Id)
        {

            objdb.Delete(Id);

        }
        public void Update(tbl_User user)
        {
            objdb.Update(user);
        }
    }
}
