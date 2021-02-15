using System.Threading.Tasks;
using LsSocial_Backend.Models;

namespace LsSocial_Backend.Interfaces
{
    public interface ISignupManager
    {
        Task SignUpAsync(UserModel userModel);
    }
}