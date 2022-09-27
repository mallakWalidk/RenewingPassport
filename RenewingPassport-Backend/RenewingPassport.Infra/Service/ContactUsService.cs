using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class ContactUsService: IContactUsService
    {
        private readonly IContactUsRepository repo;

        public ContactUsService(IContactUsRepository repo)
        {
            this.repo = repo;
        }

        public bool CreateContactUsPage(ContactUsPage contactuspage)
        {
            return repo.CreateContactUsPage(contactuspage);
        }

        public bool DeleteContactUsPage(int id)
        {
           return repo.DeleteContactUsPage(id);
        }

        public List<ContactUsPage> GetAllContactUsPage()
        {
            return repo.GetAllContactUsPage();
        }

        public ContactUsPage GetContactUsPageByID(int id)
        {
           return repo.GetContactUsPageByID(id);
        }

        public bool UpdateContactUsPage(ContactUsPage contactuspage)
        {
            return repo.UpdateContactUsPage(contactuspage);
        }
        public ContactUsPage GetCurrentPage()
        {
            return repo.GetCurrentPage();
        }

    }
}

