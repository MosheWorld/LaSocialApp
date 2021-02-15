using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using LsSocial_Backend.Interfaces;

namespace LsSocial_Backend.Controllers
{
    [Route("Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginManager _loginManager;
        private readonly ISignupManager _signupManager;

        #region Constructor
        public AuthenticationController(ILoginManager loginManager, ISignupManager signupManager)
        {
            _loginManager = loginManager;
            _signupManager = signupManager;
        }
        #endregion

        #region Public API Methods
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> GetAll([FromBody] LoginModel loginModel)
        {
            try
            {
                LoginResultModel loginResultModel = await _loginManager.LoginAsync(loginModel);
                return Ok(loginResultModel);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request Here {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup([FromBody] UserModel userModel)
        {
            try
            {
                await _signupManager.SignUpAsync(userModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request Here {ex.Message}");
            }
        }
        #endregion
    }
}