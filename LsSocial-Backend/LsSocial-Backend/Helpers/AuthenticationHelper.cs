using System;
using System.Text;
using System.Security.Claims;
using LsSocial_Backend.Interfaces;
using System.Security.Cryptography;
using LsSocial_Backend.JWTContainer.JWTModel;
using LsSocial_Backend.JWTContainer.JWTManagers;

namespace LsSocial_Backend
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        #region Public Methods
        public string HashPassword(string password)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public string GenerateToken(Guid ID)
        {
            IAuthContainerModel containerModel = GetJWTContainerModel(ID);
            IAuthService authService = new JWTService(containerModel.SecretKey);

            return authService.GenerateToken(containerModel);
        }

        public static IAuthService GetJWTService()
        {
            IAuthContainerModel containerModel = new JWTContainerModel();
            return new JWTService(containerModel.SecretKey);
        }
        #endregion

        #region Private Methods
        private JWTContainerModel GetJWTContainerModel(Guid id)
        {
            return new JWTContainerModel()
            {
                Claims = new Claim[] { new Claim(ClaimTypes.NameIdentifier, id.ToString()) }
            };
        }
        #endregion
    }
}