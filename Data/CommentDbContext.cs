using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Data
{
    public class CommentDbContext : DbContext
    {
        public CommentDbContext(DbContextOptions<CommentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comments { get; set; }
    }
}
