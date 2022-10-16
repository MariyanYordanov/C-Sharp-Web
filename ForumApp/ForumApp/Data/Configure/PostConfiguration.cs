using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configure
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = GetPosts();

            builder.HasData(posts);
        }

        private List<Post> GetPosts()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "First post",
                    Content = "First post will be about performing CRUD operations in MVC."
                },
                new Post()
                {
                    Id = 2,
                    Title = "Second post",
                    Content = "Second post will be a summary of my experience with CRUD operations."
                },
                new Post()
                {
                    Id = 3,
                    Title = "Third post",
                    Content = "Third post will be ..."
                }
            };
        }
    }
}
