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
    public class WebsiteRepository: IWebsiteRepository
    {
        private readonly IDbContext dbContext;
        public WebsiteRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateWebsitepages(WebsitePage websitepage)
        {
            var parameter = new DynamicParameters();

            parameter.Add("websitepagesname1", websitepage.WebsitePagesName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("aboutus_id1", websitepage.AboutUs_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("home_id1", websitepage.Home_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("contactinfo_id1", websitepage.ContactInfo_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("contactus_id1", websitepage.ContactUs_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("status1", websitepage.Status, dbType: DbType.String, direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync("websitePages_package.CreateWebsitepages", parameter, commandType: CommandType.StoredProcedure);

            return true;


        }

        public bool DeleteWebsitepages(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("WebsitePagesId1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.ExecuteAsync("websitePages_package.DeleteWebsitepages", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<WebsitePageDTO> GetAllWebsitepages()
        {
            IEnumerable<WebsitePageDTO> result = dbContext.Connection.Query<WebsitePageDTO>("websitepages_package.GetAllWebsitepages", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public WebsitePage GetById(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("WebsitePagesId1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<WebsitePage> result = dbContext.Connection.Query<WebsitePage>("websitepages_package.GetById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public bool UpdateWebsitepages(WebsitePage websitepage)
        {
            var parameter = new DynamicParameters();

            parameter.Add("websitepagesid1", websitepage.WebsitePagesId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("websitepagesname1", websitepage.WebsitePagesName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("aboutus_id1", websitepage.AboutUs_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("home_id1", websitepage.Home_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("contactinfo_id1", websitepage.ContactInfo_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("contactus_id1", websitepage.ContactUs_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("status1", websitepage.Status, dbType: DbType.String, direction: ParameterDirection.Input);



            dbContext.Connection.ExecuteAsync("websitePages_package.UpdateWebsitepages", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }
        public WebsitePage GetByStatus()
        {
            var result = dbContext.Connection.Query<WebsitePage>("websitePages_package.GetByStatus", commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

    }
}
