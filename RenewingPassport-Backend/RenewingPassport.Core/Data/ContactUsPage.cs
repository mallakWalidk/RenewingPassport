using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.Data
{
    public class ContactUsPage
    {
        [Key]
        public int ContactUsId { get; set; }
        public string ContactUsName { get; set; }
        public string Header1 { get; set; }
        public string Header2 { get; set; }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
        public string ImagePath1 { get; set; }
        public string ImagePath2 { get; set; }
        public virtual ICollection<WebsitePage> websitePages { get; set; }


    }
}
