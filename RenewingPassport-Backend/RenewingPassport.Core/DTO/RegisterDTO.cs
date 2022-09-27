using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.DTO
{
    public class RegisterDTO
    {
       
        [Required]
        [MaxLength(300, ErrorMessage = "The Maximum number of letters is 300 .")]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string User_Email { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime UserBD { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%?&])[A-Za-z\d$@$!%?&]{0,}$", ErrorMessage = "Password Is not  Valid")]
        public string Password { get; set; }

        [Required]
        [MaxLength(6, ErrorMessage = "The Maximum number of letters is 6")]

        public string Gender { get; set; }
    }
}
