using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            projectEntities db = new projectEntities();
            string useremailvalue = value.ToString();
            int count = db.tbl_User.Where(x => x.UserEmail == useremailvalue).ToList().Count();
            if (count != 0)
            {
                return new ValidationResult("User Already Exist with This Email ID");
            }
            return ValidationResult.Success;

        }
    }

    public class tbl_UserValidation
    {
        [Required(ErrorMessage = "Emailid is required..")]
        [EmailAddress]
        [UniqueEmail]
        public string UserEmail { get; set; }
        [Required(ErrorMessage = "Password is required..")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required..")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }
        [Required(ErrorMessage = "UserName is required..")]
        public string UserName { get; set; }
    }
    [MetadataType(typeof(tbl_UserValidation))]
    public partial class tbl_User
    {
        [Required(ErrorMessage = "Confirm Password is required..")]
        public string ConfirmPassword { get; set; }
    }
}
