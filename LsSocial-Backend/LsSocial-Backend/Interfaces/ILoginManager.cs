using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;

namespace LsSocial_Backend.Interfaces
{
    public interface ILoginManager
    {
        Task<LoginResultModel> LoginAsync(LoginModel loginModel);
        Task<UserModel> GetByID(Guid ID, bool includePassword = false);
        Task<UserModel> GetByIDWithoutPosts(Guid ID, bool includePassword = false);
    }
}