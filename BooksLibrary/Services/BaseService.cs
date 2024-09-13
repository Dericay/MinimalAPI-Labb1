using BooksLibrary.Models;
using MinimalAPI_Labb1.Models;
using Newtonsoft.Json;
using System.Text;

namespace BooksLibrary.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get; set; }

        public IHttpClientFactory _httpClient {  get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient;
            this.responseModel = new ResponseDto();
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var Client = _httpClient.CreateClient("SUT23BookLibraryAPI");

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                Client.DefaultRequestHeaders.Clear();
                
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/Json");
                }

                HttpResponseMessage apiRespo = null;

                switch (apiRequest.apiType)
                {
                    case StaticDetails.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDetails.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDetails.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDetails.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;

                }

                apiRespo = await Client.SendAsync(message);

                var apiContent = await apiRespo.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch (Exception e)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessage = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false,
                };

                var result = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(result);
                return apiResponseDto;
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }


    }
}
