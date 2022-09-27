using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IWebsiteRepository
    {
         List<WebsitePageDTO> GetAllWebsitepages();
         bool CreateWebsitepages(WebsitePage websitepage);
         bool DeleteWebsitepages(int id);
         bool UpdateWebsitepages(WebsitePage websitepage);
         WebsitePage GetById(int id);
         WebsitePage GetByStatus();

    }
}
