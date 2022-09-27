using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.DTO
{
    public class WebsitePageDTO
    {
        [Key]
        public int WebsitePagesId { get; set; }

        public string WebsitePagesName { get; set; }

        public int Home_Id { get; set; }

        public int ContactUs_Id { get; set; }
        public int AboutUs_Id { get; set; }

        public int ContactInfo_Id { get; set; }


        public string AboutUsName { get; set; }

        public string ContactInfoName { get; set; }
        public string ContactUsName { get; set; }
        public string HomeName { get; set; }
        public string Status { get; set; }

    }
}
