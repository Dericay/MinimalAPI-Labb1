using Microsoft.AspNetCore.Mvc;
using static BookLibrary.StaticDetails;

namespace BookLibrary.Models
{
    public class APIRequest
    {
        public ApiType apiType { get; set; }

        public string Url { get; set; }

        public object Data { get; set; }

        public string AccessToken {  get; set; } 
    }
}
