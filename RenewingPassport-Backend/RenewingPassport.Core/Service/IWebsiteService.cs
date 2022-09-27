using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Service
{
    public interface IWebsiteService
    {
         List<WebsitePageDTO> GetAllWebsitepages();
         bool CreateWebsitepages(WebsitePage websitepage);
         bool DeleteWebsitepages(int id);
         Boolean UpdateWebsitepages(WebsitePage websitepage);
         WebsitePage GetById(int id);
         WebsitePage GetByStatus();
    }
}
