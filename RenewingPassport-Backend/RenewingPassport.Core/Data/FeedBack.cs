using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RenewingPassport.Core.Data
{
  public class FeedBack
    {
        [Key]
        public int FeedBackID { get; set; }
        [Required(ErrorMessage = "This Field Is reuired !! ")]
        public string FeedBack_Name { get; set; }

        public string CreatedBy { get; set; }
        [Required(ErrorMessage = "This Field Is reuired !! ")]
        public string Message { get; set; }
        [Required(ErrorMessage = "This Field Is reuired !! ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Field Is reuired !! ")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Message_Date { get; set; }
        
    
    }
}
