using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class AboutUsService : IAboutUsService
    {
        private readonly IAboutUsRepository aboutUsRepository;

        public AboutUsService(IAboutUsRepository _aboutUsRepository)
        {
            aboutUsRepository = _aboutUsRepository;
        }

        public bool CreateAboutUsPage(AboutUsPage aboutuspage)
        {
           return aboutUsRepository.CreateAboutUsPage(aboutuspage);
        }

        public bool DeleteAboutUsPage(int id)
        {
            return aboutUsRepository.DeleteAboutUsPage(id);
        }

        public AboutUsPage GetAboutUsPageByID(int id)
        {
            return aboutUsRepository.GetAboutUsPageByID(id);
        }

        public List<AboutUsPage> GetAllAboutUsPage()
        {
            return aboutUsRepository.GetAllAboutUsPage();
        }

        public bool UpdateAboutUsPage(AboutUsPage aboutuspage)
        {
            return aboutUsRepository.UpdateAboutUsPage(aboutuspage);
        }

        public AboutUsPage GetCurrentPage()
        {
            return aboutUsRepository.GetCurrentPage();
        }

    }
}
