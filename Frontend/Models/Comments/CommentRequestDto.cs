namespace Frontend.Models.Comments
{
    public class CommentRequestDto
    {
        public Guid PostId { get; set; }
      
        public string Content { get; set; } = "";
    }
}
