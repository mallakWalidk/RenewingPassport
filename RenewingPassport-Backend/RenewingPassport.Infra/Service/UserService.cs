using Dapper;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public List<User> GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }

        public List<UserProfileDTO> GetUsernameAndEmail()
        {
            return _userRepository.GetUsernameAndEmail();
        }

        public List<UserProfileDTO> GetUserProfileById(int Id)
        {
            return _userRepository.GetUserProfileById(Id);
        }

        public List<CountDto> GetUsersCount()
        {
            return _userRepository.GetUsersCount();
        }

        public bool Register(RegisterDTO user)
        {
            user.Password= SecurePasswordHasher.Hash(user.Password, 10000);
            return _userRepository.Register(user);
        }

        public bool UpdatePassword(UserPasswordDTO user)
        {
            if (SecurePasswordHasher.Verify(user.OldPassword, _userRepository.GetUserById(user.UserId)[0].Passwordd))
            {
                user.NewPassword = SecurePasswordHasher.Hash(user.NewPassword, 10000);
                return _userRepository.UpdatePassword(user);
            }
            else
                return false;
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public bool UpdateUserProfile(UserProfileDTO user)
        {
            return _userRepository.UpdateUserProfile(user);
        }
        public bool UpdateUserInfo(UserInfoDTO user)
        {
            return _userRepository.UpdateUserInfo(user);

        }
        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
    }
}
