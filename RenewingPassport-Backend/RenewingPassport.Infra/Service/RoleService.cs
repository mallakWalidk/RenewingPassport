using RenewingPassport.Core.Data;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;

        public RoleService(IRoleRepository _roleRepository)
        {
            roleRepository = _roleRepository;
        }
        public List<Role> GetAllRole()
        {
            return roleRepository.GetAllRole();
        }

        public Role GetById(int id)
        {
            return roleRepository.GetById(id);
        }
    }
}
