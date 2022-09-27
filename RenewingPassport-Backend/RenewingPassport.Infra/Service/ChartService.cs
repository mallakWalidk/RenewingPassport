using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
   public class ChartService:IChartService
    {
        private readonly IChartRepository _chartRepository;
      public ChartService(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
      public  List<GenderChartDto> GetCountPassportByGender()
        {
            return _chartRepository.GetCountPassportByGender();
        }
   

       public List<RenewingChartDto> GetCountPassportByIssueDate()
        {
            return _chartRepository.GetCountPassportByIssueDate();
        }

     

       public List<StatusChartDto> GetCountPassportByStatus()
        {
            return _chartRepository.GetCountPassportByStatus();
        }
    }
}
