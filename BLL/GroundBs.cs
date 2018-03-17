using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public  class GroundBs
    {
        private Grounddb objdb;
        public GroundBs()
        {
            objdb = new Grounddb();

        }
        public IEnumerable<tbl_Ground> GetAll()
        {
            return objdb.GetAll();
        }

        public tbl_Ground GetById(int Id)
        {
            return objdb.GetById(Id);
        }
        public void Insert(tbl_Ground ground)
        {
            objdb.Insert(ground);

        }
        public void Delete(int Id)
        {

            objdb.Delete(Id);

        }
        public void Update(tbl_Ground ground)
        {
            objdb.Update(ground);
        }
    }
}
