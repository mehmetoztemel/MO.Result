using System.Text.Json.Serialization;

namespace MO.Result
{
    public sealed class Result<T>
    {
        public T? Data { get; private set; }
        public bool IsSuccess { get; private set; }
        public List<string>? ErrorMessages { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }

        private Result(T data)
        {
            Data = data;
            StatusCode = 200;
            IsSuccess = true;
        }

        private Result(string errorMessage, int statusCode)
        {
            ErrorMessages = new List<string> { errorMessage };
            StatusCode = statusCode;
            IsSuccess = false;
            Data = default;
        }

        private Result(List<string> errorMessages, int statusCode)
        {
            ErrorMessages = errorMessages;
            StatusCode = statusCode;
            IsSuccess = false;
            Data = default;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data);
        }

        public static Result<T> Failure(string errorMessage, int statusCode = 500)
        {
            return new Result<T>(errorMessage, statusCode);
        }

        public static Result<T> Failure(List<string> errorMessages, int statusCode = 500)
        {
            return new Result<T>(errorMessages, statusCode);
        }
    }
}