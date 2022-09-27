using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Service
{
    public interface IContactUsService
    {
         List<ContactUsPage> GetAllContactUsPage();
         bool CreateContactUsPage(ContactUsPage contactuspage);
         bool UpdateContactUsPage(ContactUsPage contactuspage);
         bool DeleteContactUsPage(int id);
         ContactUsPage GetContactUsPageByID(int id);
         ContactUsPage GetCurrentPage();

    }
}
