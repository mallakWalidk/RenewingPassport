using Dapper;
using RenewingPassport.Core.Common;
using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RenewingPassport.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;

        public UserRepository(IDbContext dbCOntext)
        {
            _dbContext = dbCOntext;
        }
        public bool DeleteUser(int id)
        {
            var P = new DynamicParameters();
            P.Add("@userid1", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.ExecuteAsync("user_Package.DeleteUser", P, commandType: CommandType.StoredProcedure);

            return true;

        }

        public List<User> GetAllUsers()
        {
           
            IEnumerable<User> result = _dbContext.Connection.Query<User>("Users1_package.GetAllUsers",  commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<User> GetUserById(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@userid1", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<User> result = _dbContext.Connection.Query<User>("Users1_package.GetUserById",P, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<UserProfileDTO> GetUsernameAndEmail()
        {
            IEnumerable<UserProfileDTO> result = _dbContext.Connection.Query<UserProfileDTO>("Users1_package.GetUsernameAndEmail", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<UserProfileDTO> GetUserProfileById(int Id)
        {
            var P = new DynamicParameters();
            P.Add("@userid1", Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<UserProfileDTO> result = _dbContext.Connection.Query<UserProfileDTO>("Users1_package.GetUserProfileById", P, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<CountDto> GetUsersCount()
        {
            IEnumerable<CountDto> result = _dbContext.Connection.Query<CountDto>("Users1_package.GetUsersCount", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Register(RegisterDTO user)
        {
            var P = new DynamicParameters();
            P.Add("@FULLNAME1", user.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@phonenumber1", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USERBD1", user.UserBD, dbType: DbType.Date, direction: ParameterDirection.Input);
            P.Add("@USERNAME1", user.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USER_EMAIL1", user.User_Email, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@PASSWORDD1", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@GENDER1", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@ROLE_ID1",1, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("Users1_package.Register1", P, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool UpdatePassword(UserPasswordDTO user)
        {
            var P = new DynamicParameters();
            P.Add("@userid1", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@PASSWORDD1", user.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("Users1_package.UpdatePassword", P, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool UpdateUser(User user)
        {
            var P = new DynamicParameters();
            P.Add("@userid1", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@FULLNAME1", user.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@phonenumber1", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USERBD1", user.UserBD, dbType: DbType.Date, direction: ParameterDirection.Input);
            P.Add("@USERNAME1", user.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USER_EMAIL1", user.User_Email, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@PASSWORDD1", user.Passwordd, dbType: DbType.Date, direction: ParameterDirection.Input);
            P.Add("@USERIMAGEPATH1", user.UserImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@NATIONALNUMBER1", user.NationalNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@MOTHERNAME1", user.MotherName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@GENDER1", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@PLACEOFBIRTH1", user.PlaceOfBirth, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@OLDPASSPORTPATH1", user.OldPassportPath, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@IDENTITYPATH1", user.IdentityPath, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@ROLE_ID1", user.Role_Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.ExecuteAsync("Users1_package.UpdateUser", P, commandType: CommandType.StoredProcedure);

            return true;
        }
        public bool UpdateUserProfile(UserProfileDTO user)
        {
            var P = new DynamicParameters();
            P.Add("@userid1", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@FULLNAME1", user.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@phonenumber1", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USERBD1", user.UserBD, dbType: DbType.Date, direction: ParameterDirection.Input);
            P.Add("@USERNAME1", user.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USER_EMAIL1", user.User_Email, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USERIMAGEPATH1", user.UserImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@GENDER1", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteAsync("Users1_package.UpdateUserProfile", P, commandType: CommandType.StoredProcedure);

            return true;
        }

        public bool  UpdateUserInfo(UserInfoDTO user)
        {
            var P = new DynamicParameters();
            P.Add("@userid1", user.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            P.Add("@FULLNAME1", user.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@USERBD1", user.UserBD, dbType: DbType.Date, direction: ParameterDirection.Input);
            P.Add("@USERIMAGEPATH1", user.UserImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@GENDER1", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@MOTHERNAME1", user.MotherName, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@PLACEOFBIRTH1", user.PlaceOfBirth, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@NATIONALNUMBER1", user.NationalNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@IDENTITYPATH1", user.IdentityPath, dbType: DbType.String, direction: ParameterDirection.Input);
            P.Add("@OLDPASSPORTPATH1", user.OldPassportPath, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.ExecuteAsync("Users1_package.UpdateUserInfo", P, commandType: CommandType.StoredProcedure);

            return true;
        }
        public User GetUserByEmail(string email)
        {
            var P = new DynamicParameters();
            P.Add("@USER_EMAIL1", email, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<User> result = _dbContext.Connection.Query<User>("Users1_package.GetUserByEmail", P, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
