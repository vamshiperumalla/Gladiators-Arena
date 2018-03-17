using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_GroundValidation
    {
        [Required(ErrorMessage = "GroundName is required..")]
        public string GroundName { get; set; }
        [Required(ErrorMessage = "GroundDescription is required..")]
        public string GroundDesc { get; set; }
        [Required(ErrorMessage = "Address is required..")]
        public string GroundAddress { get; set; }
        [Required(ErrorMessage = "Manager Details is required..")]
        public string GroundManager { get; set; }
        [Required(ErrorMessage = "Contact is required..")]
        [Display(Name = "Contact Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [DataType(DataType.PhoneNumber)]
        public int GroundContact { get; set; }

        
        public byte[] GroundImage { get; set; }
        [Required(ErrorMessage = "City is required..")]
        public string GroundCity { get; set; }

        public string IsApproved { get; set; }

       

        [MetadataType(typeof(tbl_GroundValidation))]
        public partial class tbl_Ground
        {

        }
    }
}
