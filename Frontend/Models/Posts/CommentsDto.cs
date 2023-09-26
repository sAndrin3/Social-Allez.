namespace Frontend.Models.Posts
{
    public class CommentsDto
    {
        public Guid id { get; set; }
        public string content { get; set; } = string.Empty;
    }
}