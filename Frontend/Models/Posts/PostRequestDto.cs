using System.ComponentModel.DataAnnotations;

namespace Frontend.Models.Posts
{
    public class PostRequestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}