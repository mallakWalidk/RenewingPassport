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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext dbContext;
        public RoleRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Role> GetAllRole()
        {
            IEnumerable<Role> result = dbContext.Connection.Query<Role>("roles1_package.GetAllRole", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Role GetById(int id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("roleid1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<Role> result = dbContext.Connection.Query<Role>("roles1_package.GetById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
