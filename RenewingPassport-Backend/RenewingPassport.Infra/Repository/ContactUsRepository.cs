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
    public class ContactUsRepository: IContactUsRepository
    {
        private readonly IDbContext dbContext;
        public ContactUsRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateContactUsPage(ContactUsPage contactuspage)
        {
            var parameter = new DynamicParameters();

            parameter.Add("name", contactuspage.ContactUsName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CHeader1", contactuspage.Header1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cHeader2", contactuspage.Header2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cImagePath1", contactuspage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CImagePath2", contactuspage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CText1", contactuspage.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CText2", contactuspage.Text2, dbType: DbType.String, direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync("contactuspage_package.CreateContactUsPage", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool DeleteContactUsPage(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.Connection.ExecuteAsync("contactuspage_package.DeleteContactUsPage", parameter, commandType: CommandType.StoredProcedure);
            return true;

        }

        public List<ContactUsPage> GetAllContactUsPage()
        {
            IEnumerable<ContactUsPage> result = dbContext.Connection.Query<ContactUsPage>("contactuspage_package.GetAllContactUsPage", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public ContactUsPage GetContactUsPageByID(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<ContactUsPage> result = dbContext.Connection.Query<ContactUsPage>("contactuspage_package.GetContactUsPageByID", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();


        }

        public bool UpdateContactUsPage(ContactUsPage contactuspage)
        {
            var parameter = new DynamicParameters();
            parameter.Add("CID", contactuspage.ContactUsId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("name", contactuspage.ContactUsName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CHeader1", contactuspage.Header1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cHeader2", contactuspage.Header2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("cImagePath1", contactuspage.ImagePath1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CImagePath2", contactuspage.ImagePath2, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CText1", contactuspage.Text1, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("CText2", contactuspage.Text2, dbType: DbType.String, direction: ParameterDirection.Input);


            dbContext.Connection.ExecuteAsync("contactuspage_package.UpdateContactUsPage", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }


        public ContactUsPage GetCurrentPage()
        {
            var result = dbContext.Connection.Query<WebsitePage>("websitePages_package.GetByStatus", commandType: CommandType.StoredProcedure).FirstOrDefault();
            var res = GetContactUsPageByID(result.ContactUs_Id);
            return res;

        }
    }

}
