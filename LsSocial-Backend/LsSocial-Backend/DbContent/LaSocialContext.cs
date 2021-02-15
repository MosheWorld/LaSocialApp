using LsSocial_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LsSocial_Backend.DbContent
{
    public class LaSocialContext : DbContext
    {
        public LaSocialContext(DbContextOptions<LaSocialContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<PostModel> Posts { get; set; }
    }
}