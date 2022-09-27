using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Service
{
    public interface IRoleService
    {
         List<Role> GetAllRole();
         Role GetById(int id);

    }
}
