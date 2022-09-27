using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RenewingPassport.Core.DTO
{
    public class PassportRequestDTO
    {
        public int PassId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string Athority { get; set; }
        public string Status { get; set; }
        public int User_Id { get; set; }
        public string RejectReason { get; set; }

    }
}
