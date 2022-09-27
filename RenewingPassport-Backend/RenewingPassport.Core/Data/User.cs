using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RenewingPassport.Core.Data
{
   public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
       // [MinLength(15,ErrorMessage = "The Minimum number of letters is 15 .")]
        [MaxLength(300,ErrorMessage = "The Maximum number of letters is 300 .")]
        public string FullName { get; set; }
        [Required]
       // [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
       // [RegularExpression(@"^[a-zA-Z].*$")]
        public string Passwordd { get; set; }
        [Required]
       // [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string User_Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"07[789]-\d{7}",ErrorMessage ="Phone Number Is not  Valid")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime UserBD { get; set; }
        [Required]
        [MaxLength(1500, ErrorMessage = "The Maximum number of letters is 1500 .")]
        //[MinLength(5, ErrorMessage = "The Minimum number of letters is 5 .")]
        public string UserImagePath { get; set; }
        [Required]
        public decimal NationalNumber { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Maximum number of letters is 50 .")]
       // [MinLength(3, ErrorMessage = "The Maximum number of letters is 3 .")]
        public string MotherName { get; set; }
        [Required]
        [MaxLength(6,ErrorMessage = "The Maximum number of letters is 6")]
       // [MinLength(4, ErrorMessage = "The Minimum number of letters is 4")]
        public string Gender { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Maximum number of letters is 50")]
        //[MinLength(4, ErrorMessage = "The Minimum number of letters is 4")]
        public string PlaceOfBirth { get; set; }
       
        [MaxLength(300, ErrorMessage = "The Maximum number of letters is 300")]
      //  [MinLength(4, ErrorMessage = "The Minimum number of letters is 2")]
        public string OldPassportPath { get; set; }
        [Required]
        [MaxLength(300, ErrorMessage = "The Maximum number of letters is 300")]
       // [MinLength(4, ErrorMessage = "The Minimum number of letters is 2")]
        public string IdentityPath { get; set; }

        public int Role_Id { get; set; }
        [ForeignKey("Role_Id")]
        public virtual Role Role { get; set; }
        public ICollection<Passport> passports { get; set; }
    }
}
