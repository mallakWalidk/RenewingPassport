using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        [Route("GetAllTestimonial")]
        public List<Testimonial> GetAllTestimonial()
        {
            return _testimonialService.GetAllTestimonial();
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        [Route("GetAcceptedTestimonial")]
        public List<Testimonial> GetAcceptedTestimonial()
        {
            return _testimonialService.GetAcceptedTestimonial();
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("DeleteTestimonial/{id}")]
        public bool DeleteTestimonial(int id)
        {
            return _testimonialService.DeleteTestimonial(id);
        }
        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool UpdateTestimonial([FromBody] Testimonial testimonial)
        {

            return _testimonialService.UpdateTestimonial(testimonial);
        }
        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateTestimonial([FromBody] Testimonial testimonial)
        {
            testimonial.Status = "Pending";
            testimonial.Message_Date = DateTime.Now;
            return _testimonialService.CreateTestimonial(testimonial);
        }
    }
}
