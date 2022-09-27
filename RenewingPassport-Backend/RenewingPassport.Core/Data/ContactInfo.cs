using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.Data
{
    public class ContactInfo
    {
        [Key]
        public decimal ContactInfoId { get; set; }
        public string ContactInfoName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }

        public virtual ICollection<WebsitePage> websitePages { get; set; }
    }
}
