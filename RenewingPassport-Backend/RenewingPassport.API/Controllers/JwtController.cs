using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Service;
using System.Security.Cryptography;
using System;

namespace Tahaluf.LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : Controller
    {
        private readonly IJwtService jwtService;

        public JwtController(IJwtService _jwtService)
        {
            jwtService = _jwtService;

        }
        [HttpPost]
        [Route("login")]
        public IActionResult Auth(LoginDTO login)
        {
            var token = jwtService.Auth(login);
            if(token == null)
                return Unauthorized();
            else
                return Ok(token);
        }
    }


}
