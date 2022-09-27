using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Service;
using System.Collections.Generic;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoService contactInfoService;

        public ContactInfoController(IContactInfoService _contactInfoService)
        {
            contactInfoService = _contactInfoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContactInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public bool CreateContactInfo([FromBody] ContactInfo contact)
        {
            return contactInfoService.CreateContactInfo(contact);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(ContactInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("delete/{id}")]
        public bool DeleteContactInfo(int id)
        {
            return contactInfoService.DeleteContactInfo(id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ContactInfo>), StatusCodes.Status200OK)]
        public List<ContactInfo> GetAllContactInfo()
        {
            return contactInfoService.GetAllContactInfo();
        }
        [HttpPost]
        [ProducesResponseType(typeof(ContactInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetContactInfoByID/{id}")]
        public List<ContactInfo> GetContactInfoByID(int id)
        {
            return contactInfoService.GetContactInfoByID(id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(ContactInfo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateContactInfo([FromBody]ContactInfo contact)
        {
            return contactInfoService.UpdateContactInfo(contact);
        }

        [ProducesResponseType(typeof(HomePage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("getcurrentpage")]
        public ContactInfo GetCurrentPage()
        {
            return contactInfoService.GetCurrentPage();

        }

    }
}
