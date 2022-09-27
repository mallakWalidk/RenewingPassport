using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class HomepageService: IHomepageService
    {
        private readonly IHomepageRepository homepageRepository;

        public HomepageService(IHomepageRepository _homepageRepository)
        {
             homepageRepository = _homepageRepository;
        }

        public bool CreateHomePage(HomePage homepage)
        {
            return homepageRepository.CreateHomePage(homepage);
        }

        public bool DeleteHomePage(int id)
        {
            return homepageRepository.DeleteHomePage(id);
        }

        public List<HomePage> GetAllHomePage()
        {
            return homepageRepository.GetAllHomePage();
        }

        public HomePage GetHomePageByID(int id)
        {
            return homepageRepository.GetHomePageByID(id);
        }

        public bool UpdateHomePage(HomePage homepage)
        {
            return homepageRepository.UpdateHomePage(homepage);
        }
        public HomePage GetCurrentPage()
        {
            return homepageRepository.GetCurrentPage();
        }

    }
}
