using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public  class CategoryBs
    {
        private Categorydb objdb;
        public CategoryBs()
        {
            objdb = new Categorydb();

        }
        public IEnumerable<tbl_Category> GetAll()
        {
            return objdb.GetAll();
        }

        public tbl_Category GetById(int Id)
        {
            return objdb.GetById(Id);
        }
        public void Insert(tbl_Category category)
        {
            objdb.Insert(category);

        }
        public void Delete(int Id)
        {

            objdb.Delete(Id);

        }
        public void Update(tbl_Category category)
        {
            objdb.Update(category);
        }
    }
}
