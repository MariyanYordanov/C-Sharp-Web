using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumApp.Data.DataConstans.Post;

namespace ForumApp.Data.Entities
{
    [Comment("Published posts")]
    public class Post
    {
        [Comment("Posts Identifier")]
        public int Id { get; init; }

        [Required]
        [Comment("Post title")]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; } = null!;

        [Required]
        [Comment("Content")]
        [MaxLength(ContentMaxLenght)]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("Marks reacordas deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
