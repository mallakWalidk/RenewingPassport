using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ContactUsController : Controller
    {
        private readonly IContactUsService contactUsService;

        public ContactUsController(IContactUsService _contactUsService)
        {
            contactUsService = _contactUsService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<ContactUsPage>), StatusCodes.Status200OK)]
        public List<ContactUsPage> GetAllContactUsPage()
        {
            return contactUsService.GetAllContactUsPage();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContactUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateContactUsPage(ContactUsPage contactuspage)
        {
            return contactUsService.CreateContactUsPage(contactuspage);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ContactUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateContactUsPage(ContactUsPage contactuspage)
        {
            return contactUsService.UpdateContactUsPage(contactuspage);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ContactUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteContactUsPage(int id)
        {
            return contactUsService.DeleteContactUsPage(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ContactUsPage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getbyid/{id}")]
        public ContactUsPage GetContactUsPageByID(int id)
        {
            return contactUsService.GetContactUsPageByID(id);
        }

        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getcurrentpage")]
        public ContactUsPage GetCurrentPage()
        {
            return contactUsService.GetCurrentPage();

        }
    }
}
