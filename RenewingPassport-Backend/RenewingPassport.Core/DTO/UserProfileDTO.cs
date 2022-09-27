using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.DTO
{
    public class UserProfileDTO
    {
        [Key]
        public int UserId { get; set; }
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
        [MaxLength(1500, ErrorMessage = "The Maximum number of letters is 1500 .")]

        public string UserImagePath { get; set; }
        
        [Required]
        [MaxLength(6, ErrorMessage = "The Maximum number of letters is 6")]
    
        public string Gender { get; set; }
    
    }
}
