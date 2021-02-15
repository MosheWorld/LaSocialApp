using System;
using System.Linq;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using System.Collections.Generic;
using LsSocial_Backend.Interfaces;

namespace LsSocial_Backend.Managers
{
    public class PostsManager : IPostsManager
    {
        private readonly IPostsDal _postsDal;
        private readonly ILoginManager _loginManager;

        #region Constructor
        public PostsManager(IPostsDal postsDal, ILoginManager loginManager)
        {
            _postsDal = postsDal;
            _loginManager = loginManager;
        }
        #endregion

        #region Public Methods
        public async Task<List<PostModel>> GetAllAsync()
        {
            List<PostModel> posts = _postsDal.GetAll().ToList();

            foreach (PostModel post in posts)
            {
                UserModel userModel = await _loginManager.GetByIDWithoutPosts(post.UserID, false);
                post.User = userModel;
            }

            return posts;
        }

        public async Task<PostModel> GetByIDAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("ID is not valid.");

            return await _postsDal.GetByIDAsync(id);
        }

        public async Task CreateAsync(PostModel postModel)
        {
            if (!IsModelValid(postModel))
                throw new ArgumentException("Post is not valid.");

            await _postsDal.CreateAsync(postModel);
        }

        public async Task DeleteAsync(PostModel postModel)
        {
            if (postModel == null || postModel.ID == Guid.Empty)
                throw new ArgumentException("Post is not valid.");

            PostModel postModelFromDB = await _postsDal.GetByIDAsync(postModel.ID);

            if (postModelFromDB == null)
                throw new ArgumentException("Given post ID is not valid.");

            await _postsDal.DeleteAsync(postModel);
        }
        #endregion

        #region Private Methods
        private bool IsModelValid(PostModel postModel)
        {
            if (postModel == null
                || string.IsNullOrEmpty(postModel.Name)
                || string.IsNullOrEmpty(postModel.Description)
                || postModel.UserID == Guid.Empty)
                return false;
            else
                return true;
        }
        #endregion
    }
}