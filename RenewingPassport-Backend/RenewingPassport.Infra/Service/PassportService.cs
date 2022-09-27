using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System.Collections.Generic;

namespace RenewingPassport.Infra.Service
{
    public class PassportService : IPassportService
    {
        private readonly IPassportRepository passportRepository;

        public PassportService(IPassportRepository _passportRepository)
        {
            passportRepository = _passportRepository;
        }

        public bool CreatePassport(Passport passport)
        {
            return passportRepository.CreatePassport(passport);
        }

        public bool DeletePassport(int id)
        {
            return passportRepository.DeletePassport(id);
        }

        public List<Passport> GetAllPassport()
        {
            return passportRepository.GetAllPassport();
        }

        public List<CountRequestsDto> GetCountRequests()
        {
            return passportRepository.GetCountRequests();
        }

        public List<Passport> GetExpiredPassport(int id)
        {
            return passportRepository.GetExpiredPassport(id);
        }

        public List<Passport> GetPassportByID(int id)
        {
            return passportRepository.GetPassportByID(id);
        }

        public List<PassportDTO> GetPassportByStatus(Passport passport)
        {
            return passportRepository.GetPassportByStatus(passport);
        }

        public List<UserPassportDto> GetUsersPassports()
        {
            return passportRepository.GetUsersPassports();
        }

        public List<PassportDTO> SearchByEndDate(Passport passport)
        {
            return passportRepository.SearchByEndDate(passport);
        }

        public List<PassportDTO> SearchByInterval(Passport passport)
        {
            return passportRepository.SearchByInterval(passport);
        }

        public List<PassportDTO> SearchByStartDate(Passport passport)
        {
            return passportRepository.SearchByStartDate(passport);
        }

        public bool UpdatePassport(Passport passport)
        {
            return passportRepository.UpdatePassport(passport);
        }

       public List<PassportDTO> GetUserPassport()
        {
            return passportRepository.GetUserPassport();

        }

        public List<Passport> GetExpiredPassport()
        {
            return passportRepository.GetExpiredPassport();
        }

       public List<PassportDTO> GetRequests()
        {
            return passportRepository.GetRequests();
        }

        public List<ReportDto> GetReportAnnual()
        {
            return passportRepository.GetReportAnnual();
        }

        public List<ReportDto> GetReportMonthly()
        {
            return  passportRepository.GetReportMonthly();
        }

        public PassportDTO GetPassportByUserId(int id)
        {
            return passportRepository.GetPassportByUserId(id);
        }

    }
}