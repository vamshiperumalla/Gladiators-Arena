using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
   public class LocationBs
    {
        private Locationdb objdb;
        public LocationBs()
        {
            objdb = new Locationdb();

        }
        public IEnumerable<tbl_Location> GetAll()
        {
            return objdb.GetAll();
        }

        public tbl_Location GetById(int Id)
        {
            return objdb.GetById(Id);
        }
        public void Insert(tbl_Location location)
        {
            objdb.Insert(location);

        }
        public void Delete(int Id)
        {

            objdb.Delete(Id);

        }
        public void Update(tbl_Location location)
        {
            objdb.Update(location);
        }
    }
}
