using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RenewingPassport.Core.Common;
//using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.DTO;

namespace RenewingPassport.Infra.Repository
{
    public class JwtRepository : IJwtRepository
    {
        private readonly IDbContext DbContext;
        public JwtRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }


        public LoginDTO Auth(LoginDTO login)
        {
            var p = new DynamicParameters();
            p.Add("@username1", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@user_email1", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@passwordd1", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<LoginDTO> result = DbContext.Connection.Query<LoginDTO>("Auth_Package.Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();




        }
    }
}
