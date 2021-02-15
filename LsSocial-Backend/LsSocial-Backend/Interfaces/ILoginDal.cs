using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;

namespace LsSocial_Backend.Interfaces
{
    public interface ILoginDal
    {
        Task<UserModel> GetUserByUsernameAndPasswordAsync(LoginModel loginModel);
        Task<UserModel> GetByID(Guid ID);
    }
}