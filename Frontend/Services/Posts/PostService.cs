using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Frontend.Models.Posts;
using Frontend.Models.Comments;

namespace Frontend.Services.Posts
{
    public class PostService : IPostInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5069"; 

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PostDto>>($"{_baseUrl}/api/Post");
        }

        public async Task<PostDto> GetPostByIdAsync(Guid postId)
        {
            return await _httpClient.GetFromJsonAsync<PostDto>($"{_baseUrl}/api/Post/{postId}");
        }

        public async Task<PostDto> AddPostAsync(PostRequestDto newPost)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Post", newPost);
            return await response.Content.ReadFromJsonAsync<PostDto>();
        }

        public async Task<PostDto> UpdatePostAsync(Guid postId, PostRequestDto updatedPost)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/api/Post/{postId}", updatedPost);
            return await response.Content.ReadFromJsonAsync<PostDto>();
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Post/{postId}");
            return response.IsSuccessStatusCode;
        }

       

        
    }
}
