using RenewingPassport.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IJwtRepository
    {
        LoginDTO Auth(LoginDTO login);
    }
}
