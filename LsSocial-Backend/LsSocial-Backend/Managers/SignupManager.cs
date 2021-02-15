using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using LsSocial_Backend.Interfaces;

namespace LsSocial_Backend.Managers
{
    public class SignupManager : ISignupManager
    {
        private readonly ISignupDal _signupDal;
        private readonly IAuthenticationHelper _authenticationHelper;

        #region Constructor
        public SignupManager(ISignupDal signupDal, IAuthenticationHelper authenticationHelper)
        {
            _signupDal = signupDal;
            _authenticationHelper = authenticationHelper;
        }
        #endregion

        #region Public Methods
        public async Task SignUpAsync(UserModel userModel)
        {
            if (!IsModelValid(userModel))
                throw new ArgumentException("User model is not valid.");

            userModel.Password = _authenticationHelper.HashPassword(userModel.Password);
            await _signupDal.SignupAsync(userModel);
        }
        #endregion

        #region Private Methods
        private bool IsModelValid(UserModel userModel)
        {
            if (userModel == null
                || string.IsNullOrEmpty(userModel.UserName)
                || string.IsNullOrEmpty(userModel.FirstName)
                || string.IsNullOrEmpty(userModel.LastName)
                || string.IsNullOrEmpty(userModel.Password))
                return false;
            else
                return true;
        }
        #endregion
    }
}