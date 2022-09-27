using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
           return _testimonialRepository.CreateTestimonial(testimonial);
        }

        public bool DeleteTestimonial(int id)
        {
            return _testimonialRepository.DeleteTestimonial(id);
        }

        public List<Testimonial> GetAcceptedTestimonial()
        {
            return _testimonialRepository.GetAcceptedTestimonial();
        }

        public List<Testimonial> GetAllTestimonial()
        {
            return _testimonialRepository.GetAllTestimonial();
        }

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            return _testimonialRepository.UpdateTestimonial(testimonial);
        }
    }
}
