using RenewingPassport.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IChartRepository
    {
        List<GenderChartDto> GetCountPassportByGender();
        List<RenewingChartDto> GetCountPassportByIssueDate();
        List<StatusChartDto> GetCountPassportByStatus();

    }
}
