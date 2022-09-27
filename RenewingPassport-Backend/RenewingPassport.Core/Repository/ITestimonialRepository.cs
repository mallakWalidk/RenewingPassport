using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RenewingPassport.Core.DTO;

namespace RenewingPassport.Core.Repository
{
    public interface ITestimonialRepository
    {
        bool CreateTestimonial(Testimonial testimonial);
        bool DeleteTestimonial(int id);
        bool UpdateTestimonial(Testimonial testimonial);
        List<Testimonial> GetAllTestimonial();
        List<Testimonial> GetAcceptedTestimonial();
    }
}
