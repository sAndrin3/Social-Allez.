using System.ComponentModel.DataAnnotations.Schema;
using Frontend.Models.Posts;

namespace Frontend.Models.Posts
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string ImageUrl { get; set; }
        [NotMapped]
        public List<CommentsDto> Comments { get; set; } = new List<CommentsDto>();
    }

}