using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.DTO
{
    public class UserPasswordDTO
    {
        public int UserId { get; set; }
    
        public string OldPassword { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%?&])[A-Za-z\d$@$!%?&]{0,}$", ErrorMessage = "Password Is not  Valid")]
        public string NewPassword { get; set; }

    }
}
