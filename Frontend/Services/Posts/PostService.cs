using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Frontend.Models.Posts;
using Frontend.Models.Comments;
using Frontend.Models;

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
            var response = await _httpClient.GetAsync($"{_baseUrl}/api/Post");
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (result.IsSuccess){
                return JsonConvert.DeserializeObject<List<PostDto>>(result.Result.ToString());
            }
            return new List<PostDto>();

        }

        public async Task<PostDto> GetPostByIdAsync(Guid id)
        {
            var response =  await _httpClient.GetAsync($"{_baseUrl}/api/Post/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (result.IsSuccess){
                return JsonConvert.DeserializeObject<PostDto>(result.Result.ToString());
            }
            return null;
        }

        public async Task<PostDto> AddPostAsync(PostRequestDto newPost)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/Post", newPost);
            return await response.Content.ReadFromJsonAsync<PostDto>();
        }

        public async Task<string> UpdatePostAsync(Guid id, PostRequestDto postRequestDto)
        {
            var request = JsonConvert.SerializeObject(postRequestDto);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/api/Post/{id}", bodyContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(content);
            if (result.IsSuccess){
                return "Post Updated";
            }
            return "";
        }

        public async Task<bool> DeletePostAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Post/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);
            if (results.IsSuccess){
                return true;
            }
            return false;
        }

       

        
    }
}
