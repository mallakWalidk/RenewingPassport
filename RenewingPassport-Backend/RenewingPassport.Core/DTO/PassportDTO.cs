using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.DTO
{
    public class PassportDTO
    {
        public int PassId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiry { get; set; }
        public string Athority { get; set; }
        public string Status { get; set; }
        public int User_Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime UserBD { get; set; }
        public string UserImagePath { get; set; }
        public decimal NationalNumber { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public string OldPassportPath { get; set; }
        public string IdentityPath { get; set; }
    }
    
}
