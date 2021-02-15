using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LsSocial_Backend.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using LsSocial_Backend.JWTContainer.JWTModel;
using LsSocial_Backend.JWTContainer.JWTManagers;

namespace LsSocial_Backend
{
    public class JWTValidationAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            string token = context?.HttpContext?.Request?.Headers["Authorization"];

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new BadRequestObjectResult("There is no token in the header.");
            }
            else
            {
                IAuthService authService = AuthenticationHelper.GetJWTService();

                bool isTokenValid = authService.IsTokenValid(token);

                List<Claim> claims = authService.GetTokenClaims(token).ToList();
                Guid userID = new Guid(claims.FirstOrDefault(e => e.Type.Equals(ClaimTypes.NameIdentifier)).Value);

                context.HttpContext.Items.Add("UserID", userID);

                if (isTokenValid == false)
                {
                    context.Result = new BadRequestObjectResult("Token is not valid.");
                }
            }
        }
    }
}