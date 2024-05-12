using System.Net;
using System.Text.Json.Serialization;

namespace MO.Result
{
    public class Result<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string>? ErrorMessages { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;

        public static Result<T> Success(T data)
        {
            return new Result<T> { Data = data };
        }

        public static Result<T> Fail(int statusCode, string errorMessage)
        {
            return new Result<T> { IsSuccess = false, StatusCode = statusCode, ErrorMessages = new List<string> { errorMessage } };
        }

        public static Result<T> Fail(int statusCode, List<string> errorMessages)
        {
            return new Result<T> { IsSuccess = false, StatusCode = statusCode, ErrorMessages = errorMessages };
        }

        public static Result<T> Fail(string errorMessage)
        {
            return new Result<T> { IsSuccess = false, StatusCode = 500, ErrorMessages = new List<string> { errorMessage } };
        }

        public static Result<T> Fail(List<string> errorMessages)
        {
            return new Result<T> { IsSuccess = false, StatusCode = 500, ErrorMessages = errorMessages };
        }

    }
}
