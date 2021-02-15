using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using System.Collections.Generic;
using LsSocial_Backend.DbContent;
using LsSocial_Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LsSocial_Backend.DAL
{
    public class PostsDal : IPostsDal
    {
        private readonly LaSocialContext _laSocialContext;

        #region Constructor
        public PostsDal(LaSocialContext laSocialContext)
        {
            _laSocialContext = laSocialContext;
        }
        #endregion

        #region Public Methods
        public IEnumerable<PostModel> GetAll()
        {
            return _laSocialContext.Posts;
        }

        public async Task<PostModel> GetByIDAsync(Guid id)
        {
            return await _laSocialContext.Posts.FirstOrDefaultAsync(e => e.ID == id);
        }

        public async Task CreateAsync(PostModel postModel)
        {
            postModel.CreatedAt = DateTime.Now;
            postModel.UpdatedAt = DateTime.Now;

            _laSocialContext.Posts.Add(postModel);
            await _laSocialContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(PostModel postModel)
        {
            PostModel originalPost = await GetByIDAsync(postModel.ID);

            _laSocialContext.Posts.Remove(originalPost);
            await _laSocialContext.SaveChangesAsync();
        }
        #endregion
    }
}