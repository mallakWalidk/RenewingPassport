using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using System.Collections.Generic;

namespace RenewingPassport.Core.Repository
{
    public interface IUserRepository
    {
        bool Register(RegisterDTO user);

        bool DeleteUser(int id);

        bool UpdateUser(User user);

        bool UpdateUserProfile(UserProfileDTO user);

        List<User> GetUserById(int Id);

        List<UserProfileDTO> GetUserProfileById(int Id);

        bool UpdatePassword(UserPasswordDTO user);

        List<User> GetAllUsers();

        List<CountDto> GetUsersCount();

        List<UserProfileDTO> GetUsernameAndEmail();
         bool UpdateUserInfo(UserInfoDTO user);
        User GetUserByEmail(string email);

    }
}