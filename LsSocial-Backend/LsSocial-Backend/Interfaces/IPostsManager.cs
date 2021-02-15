using System;
using System.Threading.Tasks;
using LsSocial_Backend.Models;
using System.Collections.Generic;

namespace LsSocial_Backend.Interfaces
{
    public interface IPostsManager
    {
        Task<List<PostModel>> GetAllAsync();
        Task<PostModel> GetByIDAsync(Guid id);
        Task CreateAsync(PostModel postModel);
        Task DeleteAsync(PostModel postModel);
    }
}