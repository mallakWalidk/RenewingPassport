using Dapper;
using RenewingPassport.Core.Common;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RenewingPassport.Infra.Repository
{
    public class PassportRepository : IPassportRepository
    {

        private readonly IDbContext DbContext;
        public PassportRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CreatePassport(Passport passport)
        {
            var p = new DynamicParameters();
            p.Add("@athority1", "Amman", dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DateOfIssue1", passport.DateOfIssue, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DateOfexpiry1", passport.DateOfExpiry, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Status1", passport.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@User_Id1", passport.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Passport_Package.CreatePassport", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeletePassport(int id)
        {
            var p = new DynamicParameters();
            p.Add("@PassNumber1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("Passport_Package.DeletePassport", p, commandType: CommandType.StoredProcedure);
            return true;        
           }

        public List<Passport> GetAllPassport()
        {
            IEnumerable<Passport> result = DbContext.Connection.Query<Passport>("Passport_Package.GetAllPassport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Passport> GetPassportByID(int id)
        {
            var p = new DynamicParameters();
            p.Add("@PassNumber1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Passport> result = DbContext.Connection.Query<Passport>("Passport_Package.GetPassportByID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PassportDTO> GetPassportByStatus(Passport passport)
        {
            var p = new DynamicParameters();
          
            p.Add("@Status1", passport.Status, dbType: DbType.String, direction: ParameterDirection.Input);
           


            IEnumerable<PassportDTO> result = DbContext.Connection.Query<PassportDTO>("Passport_Package.GetPassportByStatus", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PassportDTO> SearchByEndDate(Passport passport)
        {
            var p = new DynamicParameters();
            p.Add("@PEndDate", passport.DateOfIssue, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@PStatus", passport.Status, dbType: DbType.String, direction: ParameterDirection.Input);


            IEnumerable<PassportDTO> result = DbContext.Connection.Query<PassportDTO>("Passport_Package.SearchByEndDate", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PassportDTO> SearchByInterval(Passport passport)
        {
            var p = new DynamicParameters();
            p.Add("@PStartDate", passport.DateOfIssue, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@PEndDate", passport.DateOfExpiry, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@PStatus", passport.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<PassportDTO> result = DbContext.Connection.Query<PassportDTO>("Passport_Package.SearchByInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        
        public List<PassportDTO> SearchByStartDate(Passport passport)
        {
            var p = new DynamicParameters();
            p.Add("@pStartDate", passport.DateOfIssue, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@PStatus", passport.Status, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<PassportDTO> result = DbContext.Connection.Query<PassportDTO>("Passport_Package.SearchByStartDate", p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdatePassport(Passport passport)
        {
            var p = new DynamicParameters();
            p.Add("@passId1", passport.PassId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@athority1", passport.Athority, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DateOfIssue1", passport.DateOfIssue, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DateOfexpiry1", passport.DateOfExpiry, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@Status1", passport.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@User_Id1", passport.User_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("Passport_Package.UpdatePassport", p, commandType: CommandType.StoredProcedure);
            return true;
        }
       public List<CountRequestsDto> GetCountRequests()
        {
            IEnumerable<CountRequestsDto> result = DbContext.Connection.Query<CountRequestsDto>("Chart_Package.CountRequestByMonth", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Passport> GetExpiredPassport(int id)
        {
            var p = new DynamicParameters();
            p.Add("@UID", id, dbType: DbType.String, direction: ParameterDirection.Input);


            IEnumerable<Passport> result = DbContext.Connection.Query<Passport>("Passport_Package.GetExpiredPassport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<PassportDTO> GetUserPassport()
        {
            IEnumerable<PassportDTO> result = DbContext.Connection.Query<PassportDTO>("Passport_Package.GetUsersPassports", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }

     
       public List<Passport> GetExpiredPassport() {
            IEnumerable<Passport> result = DbContext.Connection.Query<Passport>("Passport_Package.GetAllPassport", commandType: CommandType.StoredProcedure);
            var res = result.Where(x => x.DateOfExpiry <= DateTime.Now && x.Status=="Renewed").ToList();
            return res;

        }

        public List<PassportDTO> GetRequests()
        {
            IEnumerable<PassportDTO> result = DbContext.Connection.Query<PassportDTO>("Passport_Package.GetRequests", commandType: CommandType.StoredProcedure);
            var res=result.OrderByDescending(x=>x.DateOfExpiry).ToList();
            return res;
        }


        public List<UserPassportDto> GetUsersPassports()
        {
         
            IEnumerable<UserPassportDto> result = DbContext.Connection.Query<UserPassportDto>("Passport_Package.GetUsersPassports", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ReportDto> GetReportMonthly()
        {
            IEnumerable<ReportDto> result = DbContext.Connection.Query<ReportDto>("Passport_Package.MonthlyReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
            
        }

        public List<ReportDto> GetReportAnnual()
        {
            IEnumerable<ReportDto> result = DbContext.Connection.Query<ReportDto>("Passport_Package.AnualReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public PassportDTO GetPassportByUserId(int id)
        {
            var p = new DynamicParameters();
            p.Add("@User_id1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<PassportDTO> result = DbContext.Connection.Query<PassportDTO>("Passport_Package.GetPassportByUserID", p, commandType: CommandType.StoredProcedure);

            return result.LastOrDefault();

        }

    }
}
