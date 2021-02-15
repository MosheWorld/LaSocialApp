using System;
using LsSocial_Backend.JWTContainer.JWTManagers;

namespace LsSocial_Backend.Interfaces
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(Guid ID);
        string HashPassword(string password);
    }
}