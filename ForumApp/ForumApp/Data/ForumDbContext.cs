using Microsoft.EntityFrameworkCore;
using ForumApp.Data.Entities;
using ForumApp.Data.Configure;

namespace ForumApp.Data
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Only for test!
            builder.ApplyConfiguration(new PostConfiguration());

            builder.Entity<Post>()
                .Property(p => p.IsDeleted)
                .HasDefaultValue(false);

            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
    }
}
