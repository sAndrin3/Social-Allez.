using Frontend.Models;
using Frontend.Models.Comments;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Services.comments
{
    public class CommentsService : ICommentInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:7777";

        public CommentsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ResponseDto> AddCommentAsync(CommentRequestDto comment)
        {
            var comments = new StringContent(JsonConvert.SerializeObject(comment), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/api/Comment", comments);
            var content = await response.Content.ReadAsStringAsync();
            var commentResponse = JsonConvert.DeserializeObject<ResponseDto>(content);
            if (commentResponse.IsSuccess)
            {
                return commentResponse;
            }
            else
            {
                throw new Exception(commentResponse.Message);
            }
        }

        public async Task<ResponseDto> DeleteCommentAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/api/Comment/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var commentResponse = JsonConvert.DeserializeObject<ResponseDto>(content);
                return commentResponse;
            }
            else
            {
                throw new Exception($"Failed to delete comment. Status code: {response.StatusCode}");
            }
        }


    }
}