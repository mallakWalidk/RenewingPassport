﻿using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IContactInfoRepository
    {
        List<ContactInfo> GetAllContactInfo();
        bool CreateContactInfo(ContactInfo contact);
        bool UpdateContactInfo(ContactInfo contact);
        bool DeleteContactInfo(int id);
        List<ContactInfo>GetContactInfoByID(int id);
        public ContactInfo GetCurrentPage();

    }
}
