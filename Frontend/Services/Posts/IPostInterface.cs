using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Frontend.Models.Posts;
using Frontend.Models.Comments;

namespace Frontend.Services.Posts
{
    public interface IPostInterface
    {
        Task<List<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(Guid postId);
        Task<PostDto> AddPostAsync(PostRequestDto newPost);
        Task<PostDto> UpdatePostAsync(Guid postId, PostRequestDto updatedPost);
        Task<bool> DeletePostAsync(Guid postId);
        
        
    }
}
