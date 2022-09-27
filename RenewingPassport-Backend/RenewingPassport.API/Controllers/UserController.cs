using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenewingPassport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public bool DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [Route("GetAllUser")]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [Route("GetUserById/{Id}")]
        public List<User> GetUserById(int Id)
        {
            return _userService.GetUserById(Id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [Route("GetUserProfileById/{Id}")]
        public List<UserProfileDTO> GetUserProfileById(int Id)
        {
            return _userService.GetUserProfileById(Id);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<CountDto>), StatusCodes.Status200OK)]
        [Route("GetUsersCount")]
        public List<CountDto> GetUsersCount()
        {
            return _userService.GetUsersCount();
        }
        [HttpPost]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Register")]
        public bool Register([FromBody] RegisterDTO user)
        {
            return _userService.Register(user);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdatePassword")]
        public bool UpdatePassword([FromBody] UserPasswordDTO user)
        {
            return _userService.UpdatePassword(user);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateUser")]
        public bool UpdateUser([FromBody] User user)
        {
            return _userService.UpdateUser(user);
        }
        [HttpPut]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateUserProfile")]
        public bool UpdateUserProfile([FromBody] UserProfileDTO user)
        {
            return _userService.UpdateUserProfile(user);
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetUsernameAndEmail")]
        public List<UserProfileDTO> GetUsernameAndEmail()
        {
            return _userService.GetUsernameAndEmail();
        }

        [HttpPut]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("UpdateUserInfo")]
        public bool UpdateUserInfo([FromBody] UserInfoDTO user)
        {

            return _userService.UpdateUserInfo(user);
        }
    }
    }
