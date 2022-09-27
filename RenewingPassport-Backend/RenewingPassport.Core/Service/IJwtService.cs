using RenewingPassport.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
//using RenewingPassport.Core.Data;

namespace RenewingPassport.Core.Service
{
    public interface IJwtService
    {
        string Auth(LoginDTO login);
    }
}
