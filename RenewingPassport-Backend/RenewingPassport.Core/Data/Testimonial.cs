using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RenewingPassport.Core.Data
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }
        
        public string SenderName { get; set; }
        [Required(ErrorMessage ="This Field Is reuired !! ")]
        public string Message { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Message_Date { get; set; }
       
        public string Status { get; set; }
        public string ImagePath { get; set; }


    }
}
