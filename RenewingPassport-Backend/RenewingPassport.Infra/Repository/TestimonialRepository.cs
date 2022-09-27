using Dapper;
using RenewingPassport.Core.Common;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RenewingPassport.Core.DTO;

namespace RenewingPassport.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;
     
        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateTestimonial(Testimonial testimonial)
        {
            var P = new DynamicParameters();
            P.Add("@TSenderName", testimonial.SenderName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@Tmessage", testimonial.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@TMessageDate", testimonial.Message_Date, dbType: DbType.Date, direction: ParameterDirection.Input);
            P.Add("@TStatus", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@TImagePath", testimonial.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
           

            var result = _dbContext.Connection.ExecuteAsync("Testimonial_Package.CreateTestimonial", P, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool DeleteTestimonial(int id)
        {
            var P = new DynamicParameters();

                P.Add("@TId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.ExecuteAsync("Testimonial_Package.DeleteTestimonial", P, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Testimonial> GetAcceptedTestimonial()
        {
            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>("Testimonial_Package.GetAcceptedTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Testimonial> GetAllTestimonial()
        {
            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>("Testimonial_Package.GetAllTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateTestimonial(Testimonial testimonial)
        {
            var P = new DynamicParameters();
           
            P.Add("@TStatus", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@TId", testimonial.TestimonialID, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.ExecuteAsync("Testimonial_Package.UpdateTestimonial", P, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
