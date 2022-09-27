using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.Service;
using System.Collections.Generic;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService _roleService)
        {
            roleService = _roleService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        public List<Role> GetAllRole()
        {
            return roleService.GetAllRole();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Role>), StatusCodes.Status200OK)]
        [Route("GetById/{id}")]
        public Role GetById(int id)
        {
           return roleService.GetById(id);
        }


    }
}
