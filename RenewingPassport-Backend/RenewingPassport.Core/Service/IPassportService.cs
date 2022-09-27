using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Service
{
    public interface IPassportService
    {
        List<Passport> GetAllPassport();
        bool CreatePassport(Passport passport);
        bool UpdatePassport(Passport passport);
        bool DeletePassport(int id);
        List<PassportDTO> GetPassportByStatus(Passport passport);
        List<Passport> GetPassportByID(int id);
        List<PassportDTO> SearchByStartDate(Passport passport);
        List<PassportDTO> SearchByEndDate(Passport passport);
        List<PassportDTO> SearchByInterval(Passport passport);
        List<Passport> GetExpiredPassport(int id);
        List<CountRequestsDto> GetCountRequests();
        List<PassportDTO> GetUserPassport();
        List<PassportDTO> GetRequests();
        List<Passport> GetExpiredPassport();
        List<ReportDto> GetReportMonthly();
        List<ReportDto> GetReportAnnual();
        PassportDTO GetPassportByUserId(int id);
        List<UserPassportDto> GetUsersPassports();


    }
}
