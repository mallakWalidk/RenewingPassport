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
    public class AboutUsRepository : IAboutUsRepository
    {
        private readonly IDbContext dbContext;
        public AboutUsRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateAboutUsPage(AboutUsPage aboutuspage)
        {
            var parameter = new DynamicParameters();

            parameter.Add("Name", aboutuspage.AboutUsName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AHeader1", aboutuspage.Header1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AHeader2", aboutuspage.Header2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AImagePath1", aboutuspage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AImagePath2", aboutuspage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AImagePath3", aboutuspage.ImagePath3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AText1", aboutuspage.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AText2", aboutuspage.Text2, dbType: DbType.String, direction: ParameterDirection.Input);


             dbContext.Connection.ExecuteAsync("aboutuspage_package.CreateAboutUsPage", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool DeleteAboutUsPage(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("AID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.ExecuteAsync("aboutuspage_package.DeleteAboutUsPage", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }

        public AboutUsPage GetAboutUsPageByID(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("AID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<AboutUsPage> result = dbContext.Connection.Query<AboutUsPage>("aboutuspage_package.GetAboutUsPageByID", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public List<AboutUsPage> GetAllAboutUsPage()
        {
            IEnumerable<AboutUsPage> result = dbContext.Connection.Query<AboutUsPage>("aboutuspage_package.GetAllAboutUsPage", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool UpdateAboutUsPage(AboutUsPage aboutuspage)
        {
            var parameter = new DynamicParameters();
            parameter.Add("AID", aboutuspage.AboutUsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("Name", aboutuspage.AboutUsName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AHeader1", aboutuspage.Header1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AHeader2", aboutuspage.Header2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AImagePath1", aboutuspage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AImagePath2", aboutuspage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AImagePath3", aboutuspage.ImagePath3, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AText1", aboutuspage.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("AText2", aboutuspage.Text2, dbType: DbType.String, direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync("aboutuspage_package.UpdateAboutUsPage", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public AboutUsPage GetCurrentPage()
        {
            var result = dbContext.Connection.Query<WebsitePage>("websitePages_package.GetByStatus", commandType: CommandType.StoredProcedure).FirstOrDefault();
            var res = GetAboutUsPageByID(result.AboutUs_Id);
            return res;

        }

    }
}
