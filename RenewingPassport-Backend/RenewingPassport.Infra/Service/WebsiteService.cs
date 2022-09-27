using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class WebsiteService: IWebsiteService
    {
        private readonly IWebsiteRepository websiteRepository;

        public WebsiteService(IWebsiteRepository _websiteRepository)
        {
            websiteRepository = _websiteRepository;
        }

        public bool CreateWebsitepages(WebsitePage websitepage)
        {
          return  websiteRepository.CreateWebsitepages(websitepage);
        }

        public bool DeleteWebsitepages(int id)
        {
            return websiteRepository.DeleteWebsitepages(id);
        }

        public List<WebsitePageDTO> GetAllWebsitepages()
        {
            return websiteRepository.GetAllWebsitepages();
        }

        public WebsitePage GetById(int id)
        {
            return websiteRepository.GetById(id);
        }

        public bool UpdateWebsitepages(WebsitePage websitepage)
        {
            return websiteRepository.UpdateWebsitepages(websitepage);
        }

        public WebsitePage GetByStatus()
        {
            return websiteRepository.GetByStatus();
        }

    }
}
