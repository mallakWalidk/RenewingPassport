using Dapper;
using RenewingPassport.Core.Common;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RenewingPassport.Infra.Repository
{
    public class FeedBackRepository : IFeedBackRepository
    {
        private readonly IDbContext _dbContext;
        public FeedBackRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool CreateFeedBack(FeedBack feedBack)
        {
            var P = new DynamicParameters();
            P.Add("@FeedName", feedBack.FeedBack_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@FeedCreatedBy", feedBack.CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@FeedMessage", feedBack.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@FeedEmail", feedBack.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@feedPhoneNumber", feedBack.PhoneNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@FeedDate", feedBack.Message_Date, dbType: DbType.Date, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.ExecuteAsync("FeedBack_Package.CreateFeedBack", P, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool DeleteFeedBack(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@FID", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("FeedBack_Package.DeleteFeedBack", P, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<FeedBack> GetAllFeedBack()
        {
            IEnumerable<FeedBack> result = _dbContext.Connection.Query<FeedBack>("FeedBack_Package.GetAllFeedBack", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<FeedBack> GetFeedBackById(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@FID", Id, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<FeedBack> result = _dbContext.Connection.Query<FeedBack>("FeedBack_Package.GetFeedBackByID", P, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateFeedBack(FeedBack feedBack)
        {
            var P = new DynamicParameters();
            P.Add("@FID", feedBack.FeedBackID, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@FeedName", feedBack.FeedBack_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@FeedCreatedBy", feedBack.CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@FeedMessage", feedBack.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@FeedEmail", feedBack.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@feedPhoneNumber", feedBack.PhoneNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@FeedDate", feedBack.Message_Date, dbType: DbType.Date, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.ExecuteAsync("FeedBack_Package.UpdateFeedBack", P, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
