using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace RenewingPassport.Core.Common
{
    public interface IDbContext
    {
        DbConnection Connection { get; }


    }
}
