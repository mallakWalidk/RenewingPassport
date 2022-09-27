using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RenewingPassport.Core.Data
{
    public class Bank
    {
        [Key]
        public int VisaId { get; set; }
        public string Name_On_Visa { get; set; }
        public int Visa_Number { get; set; }
        public int Visa_Cvv { get; set; }
        public int Month1 { get; set; }
        public int Year1 { get; set; }
        public double Balance { get; set; }
    }
}
