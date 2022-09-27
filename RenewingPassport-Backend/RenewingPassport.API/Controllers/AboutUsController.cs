using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AboutUsController : Controller
    {
        private readonly IAboutUsService aboutUsService;

        public AboutUsController(IAboutUsService _aboutUsService)
        {
            aboutUsService = _aboutUsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<AboutUsPage>), StatusCodes.Status200OK)]
        public List<AboutUsPage> GetAllAboutUsPage()
        {
            return aboutUsService.GetAllAboutUsPage();
        }

        [HttpPost]
        [ProducesResponseType(typeof(AboutUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateAboutUsPage([FromBody]AboutUsPage aboutuspage)
        {
            return aboutUsService.CreateAboutUsPage(aboutuspage);
        }

        [HttpPut]
        [ProducesResponseType(typeof(AboutUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateAboutUsPage([FromBody]AboutUsPage aboutuspage)
        {
            return aboutUsService.UpdateAboutUsPage(aboutuspage);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(AboutUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteAboutUsPage(int id)
        {
            return aboutUsService.DeleteAboutUsPage(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(AboutUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getbyid/{id}")]
        public AboutUsPage GetAboutUsPageByID(int id)
        {
            return aboutUsService.GetAboutUsPageByID(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(AboutUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getcurrentpage")]
        public AboutUsPage GetCurrentPage()
        {
            return aboutUsService.GetCurrentPage();

        }

    }
}
