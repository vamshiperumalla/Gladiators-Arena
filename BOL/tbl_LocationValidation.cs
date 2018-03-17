using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_LocationValidation
    {
        [Required(ErrorMessage = "Location Name is required..")]
        public string LocationName { get; set; }
    }
    [MetadataType(typeof(tbl_LocationValidation))]
    public partial class tbl_Location
    {

    }
}
