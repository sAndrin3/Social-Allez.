using Frontend.Models;
using Frontend.Models.Comments;

namespace Frontend.Services.comments
{
    public interface ICommentInterface
    {
          Task<ResponseDto> AddCommentAsync(CommentRequestDto commentRequestDto);
          Task<ResponseDto> DeleteCommentAsync(Guid id);

        
    }
}