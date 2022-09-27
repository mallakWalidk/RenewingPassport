using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using RenewingPassport.Core.DTO;
using System.Collections.Generic;

namespace RenewingPassport.Infra.Service
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfoRepository contactInfoRepository;

        public ContactInfoService(IContactInfoRepository _contactInfoRepository)
        {
            contactInfoRepository = _contactInfoRepository;
        }

        public bool CreateContactInfo(ContactInfo contact)
        {
            return contactInfoRepository.CreateContactInfo(contact);
        }

        public bool DeleteContactInfo(int id)
        {
            return contactInfoRepository.DeleteContactInfo(id);
        }

        public List<ContactInfo> GetAllContactInfo()
        {
            return contactInfoRepository.GetAllContactInfo();
        }

        public List<ContactInfo> GetContactInfoByID(int id)
        {
            return contactInfoRepository.GetContactInfoByID(id);
        }

        public bool UpdateContactInfo(ContactInfo contact)
        {
            return contactInfoRepository.UpdateContactInfo(contact);
        }
        public ContactInfo GetCurrentPage()
        {
            return contactInfoRepository.GetCurrentPage();
        }

    }
}