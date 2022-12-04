using System.Net;

namespace OderApp.Models
{
    public class Result<TValue>
    {
        public Result(HttpStatusCode statusCode, TValue? data, string? description)
        {
            StatusCode = statusCode;
            Data = data;
            Description = description;
        }

        public HttpStatusCode StatusCode { get; set; }
        public TValue? Data { get; set; }
        public string? Description { get; set; }
    }
}
