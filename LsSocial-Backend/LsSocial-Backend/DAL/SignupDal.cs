using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using LsSocial_Backend.DbContent;
using LsSocial_Backend.Interfaces;

namespace LsSocial_Backend.DAL
{
    public class SignupDal : ISignupDal
    {
        private readonly LaSocialContext _laSocialContext;

        #region Constructor
        public SignupDal(LaSocialContext laSocialContext)
        {
            _laSocialContext = laSocialContext;
        }
        #endregion

        #region Public Methods
        public async Task SignupAsync(UserModel userModel)
        {
            userModel.CreatedAt = DateTime.Now;
            userModel.UpdatedAt = DateTime.Now;

            _laSocialContext.Users.Add(userModel);
            await _laSocialContext.SaveChangesAsync();
        }
        #endregion
    }
}