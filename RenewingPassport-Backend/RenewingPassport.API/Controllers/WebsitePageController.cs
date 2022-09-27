using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WebsitePageController : Controller
    {
        private readonly IWebsiteService websiteService;

        public WebsitePageController(IWebsiteService _websiteService)
        {
            websiteService = _websiteService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<WebsitePageDTO>), StatusCodes.Status200OK)]
        public List<WebsitePageDTO> GetAllWebsitepages()
        {
            return websiteService.GetAllWebsitepages();
        }

        [HttpPost]
        [ProducesResponseType(typeof(WebsitePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateWebsitepages([FromBody] WebsitePage websitepage)
        {
            return websiteService.CreateWebsitepages(websitepage);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(WebsitePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteWebsitepages(int id)
        {
            return websiteService.DeleteWebsitepages(id);
        }

        [HttpPut]
        [ProducesResponseType(typeof(WebsitePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateWebsitepages([FromBody] WebsitePage websitepage)
        {
            return websiteService.UpdateWebsitepages(websitepage);
        }

        [HttpGet]
        [ProducesResponseType(typeof(WebsitePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getbyid/{id}")]
        public WebsitePage GetById(int id)
        {
            return websiteService.GetById(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(WebsitePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getbystatus")]
        public WebsitePage GetByStatus()
        {
            return websiteService.GetByStatus();


        }
     }
    }
