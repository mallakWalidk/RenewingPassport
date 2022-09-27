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
    public class HomepageRepository : IHomepageRepository
    {
        private readonly IDbContext dbContext;
        public HomepageRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateHomePage(HomePage homepage)
        {
            var parameter = new DynamicParameters();

            parameter.Add("name", homepage.HomeName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath1", homepage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath2", homepage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath3", homepage.ImagePath3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath4", homepage.ImagePath4, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText1", homepage.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText2", homepage.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText3", homepage.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText4", homepage.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText5", homepage.Text5, dbType: DbType.String, direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync("homepage_package.CreateHomePage", parameter, commandType: CommandType.StoredProcedure);

            return true;


        }

        public bool DeleteHomePage(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("HID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.ExecuteAsync("homepage_package.DeleteHomePage", parameter, commandType: CommandType.StoredProcedure);
            return true;


        }

        public List<HomePage> GetAllHomePage()
        {
            IEnumerable<HomePage> result = dbContext.Connection.Query<HomePage>("homepage_package.GetAllHomePage", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public HomePage GetHomePageByID(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("HID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<HomePage> result = dbContext.Connection.Query<HomePage>("homepage_package.GetHomePageByID", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool UpdateHomePage(HomePage homepage)
        {
            var parameter = new DynamicParameters();
            parameter.Add("HID", homepage.HomeId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("name", homepage.HomeName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath1", homepage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath2", homepage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath3", homepage.ImagePath3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HImagePath4", homepage.ImagePath4, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText1", homepage.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText2", homepage.Text2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText3", homepage.Text3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText4", homepage.Text4, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("HText5", homepage.Text5, dbType: DbType.String, direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync("homepage_package.UpdateHomePage", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }
        public HomePage GetCurrentPage()
        {
        var result = dbContext.Connection.Query<WebsitePage>("websitePages_package.GetByStatus", commandType: CommandType.StoredProcedure).FirstOrDefault();
            var res = GetHomePageByID(result.Home_Id);
            return res;
    }
}
}
