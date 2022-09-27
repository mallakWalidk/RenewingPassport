using Dapper;
using RenewingPassport.Core.Common;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using RenewingPassport.Infra.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RenewingPassport.Infra.Repository
{
    public class ChartRepository : IChartRepository
    {
        private readonly IDbContext _dbContext;
        public ChartRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<GenderChartDto> GetCountPassportByGender()
        {
            IEnumerable<GenderChartDto> result = _dbContext.Connection.Query<GenderChartDto>("Chart_Package.CountPassportByGender", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<RenewingChartDto> GetCountPassportByIssueDate()
        {
            IEnumerable<RenewingChartDto> result = _dbContext.Connection.Query<RenewingChartDto>("Chart_Package.CountPassportByMonth", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<StatusChartDto> GetCountPassportByStatus()
        {
            IEnumerable<StatusChartDto> result = _dbContext.Connection.Query<StatusChartDto>("Chart_Package.CountPassportByStatus", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
