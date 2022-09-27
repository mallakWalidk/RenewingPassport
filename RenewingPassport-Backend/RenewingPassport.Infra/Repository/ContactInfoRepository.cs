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
    public class ContactInfoRepository : IContactInfoRepository
    {
        private readonly IDbContext DbContext;
        public ContactInfoRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public bool CreateContactInfo(ContactInfo contact)
        {
            var p = new DynamicParameters();
            p.Add("@Name", contact.ContactInfoName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CEmail", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CPhonenumber", contact.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CInstagram", contact.Instagram, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CFacebook", contact.Facebook, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ctwitter", contact.Twitter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cyoutube", contact.Youtube, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("ContactInfo1_Package.CreateContactInfo1", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteContactInfo(int id)
        {
            var p = new DynamicParameters();
            p.Add("@CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("ContactInfo1_Package.DeleteContactInfo1", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ContactInfo> GetAllContactInfo()
        {
            IEnumerable<ContactInfo> result = DbContext.Connection.Query<ContactInfo>("ContactInfo1_Package.GetAllContactInfo1",  commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<ContactInfo> GetContactInfoByID(int id)
        {
            var p = new DynamicParameters();
            p.Add("@CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
   
            IEnumerable<ContactInfo> result = DbContext.Connection.Query<ContactInfo>("ContactInfo1_Package.GetContactInfo1ByID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateContactInfo(ContactInfo contact)
        {
            var p = new DynamicParameters();
            p.Add("@CID", contact.ContactInfoId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Name", contact.ContactInfoName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CEmail", contact.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CPhonenumber", contact.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CInstagram", contact.Instagram, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CFacebook", contact.Facebook, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Ctwitter", contact.Twitter, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Cyoutube", contact.Youtube, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("ContactInfo1_Package.UpdateContactInfo1", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public ContactInfo GetCurrentPage()
        {
            var result = DbContext.Connection.Query<WebsitePage>("websitePages_package.GetByStatus", commandType: CommandType.StoredProcedure).FirstOrDefault();
            var res = GetContactInfoByID(result.ContactInfo_Id).FirstOrDefault();
            return res;

        }

    }
}
