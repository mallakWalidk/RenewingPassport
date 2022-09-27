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
    public class BankRepository : IBankRepository
    {
        private readonly IDbContext DbContext;
        public BankRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public Bank GetBankByID(int id)
        {
            var p = new DynamicParameters();
            p.Add("@BID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            Bank result = DbContext.Connection.Query<Bank>("bank_Package.GetBankByID", p, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return result;
        }
    }
}
