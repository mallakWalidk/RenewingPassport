using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.Data
{
   public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "The maximum number of letters is 100 ")]
        public string Role_Name { get; set; }
        public ICollection<User> users { get; set; }
    }
}
