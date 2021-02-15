using System.Security.Claims;
using System.Collections.Generic;
using LsSocial_Backend.JWTContainer.JWTModel;

namespace LsSocial_Backend.JWTContainer.JWTManagers
{
    public interface IAuthService
    {
        string SecretKey { get; set; }

        bool IsTokenValid(string token);
        string GenerateToken(IAuthContainerModel model);
        IEnumerable<Claim> GetTokenClaims(string token);
    }
}