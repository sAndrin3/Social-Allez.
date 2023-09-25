using Frontend.Models;
using Frontend.Models.Comments;

namespace Frontend.Services.comments
{
    public interface ICommentInterface
    {
        
        Task<List<Comment>> GetAllComments();
        
        Task<ResponseDto> CreateComment(CommentRequestDto commentRequestDto);

        
    }
}