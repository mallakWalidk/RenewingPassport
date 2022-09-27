using RenewingPassport.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Service
{
    public interface IChartService
    {
        List<GenderChartDto> GetCountPassportByGender();
        List<RenewingChartDto> GetCountPassportByIssueDate();
        List<StatusChartDto> GetCountPassportByStatus();
    }
}
