using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RenewingPassport.Core.Data
{
    public class Passport
    {
        [Key]
        public int PassId { get; set; }
        public DateTime? DateOfIssue { get; set; }
        public DateTime? DateOfExpiry { get; set; }
        public string Athority { get; set; }
        public string Status { get; set; }

        public int User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual User user { get; set; }

    }
}
