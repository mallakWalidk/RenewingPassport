using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IBankRepository
    {
       Bank GetBankByID(int id);
    }
}
