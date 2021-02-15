using System.Threading.Tasks;
using LsSocial_Backend.Models;

namespace LsSocial_Backend.Interfaces
{
    public interface ISignupDal
    {
        Task SignupAsync(UserModel userModel);
    }
}