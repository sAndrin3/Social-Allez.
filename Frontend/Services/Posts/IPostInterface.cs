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
        Task<string> UpdatePostAsync(Guid id, PostRequestDto postRequestDto);
        Task<bool> DeletePostAsync(Guid postId);
        
        
    }
}
