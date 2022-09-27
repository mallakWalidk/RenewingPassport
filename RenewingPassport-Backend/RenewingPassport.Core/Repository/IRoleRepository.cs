using RenewingPassport.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Core.Repository
{
    public interface IRoleRepository
    {
         List<Role> GetAllRole();
         Role GetById(int id);
    }
}
