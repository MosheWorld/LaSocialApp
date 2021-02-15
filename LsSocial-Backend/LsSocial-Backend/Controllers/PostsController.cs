using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using LsSocial_Backend.Interfaces;

namespace LsSocial_Backend.Controllers
{
    [Route("Posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsManager _postsManager;
        private readonly ILoginManager _loginManager;

        #region Constructor
        public PostsController(IPostsManager postsManager, ILoginManager loginManager)
        {
            _postsManager = postsManager;
            _loginManager = loginManager;
        }
        #endregion

        #region Public API Methods
        [HttpGet]
        [Route("GetAll")]
        [JWTValidation]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _postsManager.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request Here {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetByID/{id}")]
        [JWTValidation]
        public IActionResult GetByID(Guid id)
        {
            try
            {
                return Ok(_postsManager.GetByIDAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request Here {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Create")]
        [JWTValidation]
        public async Task<IActionResult> Create([FromBody] PostModel postModel)
        {
            try
            {
                Guid userID = postModel.UserID; // HttpContext.Items["UserID"];
                UserModel userModel = await _loginManager.GetByID(userID, true);

                if (userID != userModel.ID)
                    throw new ArgumentException("Poster user ID is not equals to body user ID.");

                postModel.User = userModel;
                await _postsManager.CreateAsync(postModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request Here {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Delete")]
        [JWTValidation]
        public async Task<IActionResult> Delete([FromBody] PostModel postModel)
        {
            try
            {
                Guid userID = postModel.UserID; // HttpContext.Items["UserID"];
                UserModel userModel = await _loginManager.GetByID(userID, true);

                if (userID != userModel.ID)
                    throw new ArgumentException("Poster user ID is not equals to body user ID.");

                postModel.User = userModel;
                await _postsManager.DeleteAsync(postModel);
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