using Frontend.Models;
using Frontend.Models.Comments;
using Newtonsoft.Json;
using System.Text;

namespace Frontend.Services.comments
{
    public class CommentsService : ICommentInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:5009";

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
           var deleteComment = _httpClient.DeleteAsync($"{_baseUrl}/api/Comment/{id}");
           var content = await deleteComment.Result.Content.ReadAsStringAsync();
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

    }
}