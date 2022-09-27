using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RenewingPassport.Core.Data
{
    public class WebsitePage
    {
        [Key]
        public int WebsitePagesId { get; set; }

        public string WebsitePagesName { get; set; }

        public int Home_Id { get; set; }

        public int ContactUs_Id { get; set; }
        public int AboutUs_Id { get; set; }

        public int ContactInfo_Id { get; set; }

        
        public string Status { get; set; }

        [ForeignKey("Home_Id")]
        public virtual HomePage homepage { get; set; }

        [ForeignKey("ContactUs_Id")]
        public virtual ContactUsPage contactuspage { get; set; }

        [ForeignKey("AboutUs_Id")]
        public virtual AboutUsPage aboutuspage { get; set; }

        [ForeignKey("ContactInfo_Id")]
        public virtual ContactInfo contactinfo { get; set; }
    }
}