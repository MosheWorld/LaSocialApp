using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using LsSocial_Backend.DbContent;
using LsSocial_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LsSocial_Backend.DAL
{
    public class LoginDal : ILoginDal
    {
        private readonly LaSocialContext _laSocialContext;

        #region Constructor
        public LoginDal(LaSocialContext laSocialContext)
        {
            _laSocialContext = laSocialContext;
        }
        #endregion

        #region Public Methods
        public async Task<UserModel> GetUserByUsernameAndPasswordAsync(LoginModel loginModel)
        {
            return await _laSocialContext.Users.FirstOrDefaultAsync(e => e.UserName == loginModel.UserName && e.Password == loginModel.Password);
        }

        public async Task<UserModel> GetByID(Guid ID)
        {
            return await _laSocialContext.Users.FirstOrDefaultAsync(e => e.ID == ID);
        }
        #endregion
    }
}