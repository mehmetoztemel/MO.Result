namespace MO.Result
{
    public sealed class Result<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess => ErrorMessages == null || ErrorMessages.Count == 0;
        public List<string>? ErrorMessages { get; set; }
        public int StatusCode { get; set; }
        public static Result<T> Success(T data, int statusCode = 200)
        {
            return new Result<T> { Data = data, StatusCode = statusCode };
        }

        public static Result<T> Failure(List<string> errorMessages, int statusCode = 500)
        {
            return new Result<T> { ErrorMessages = errorMessages, StatusCode = statusCode };
        }

        public static Result<T> Failure(string errorMessage, int statusCode = 500)
        {
            return new Result<T> { ErrorMessages = new List<string> { errorMessage }, StatusCode = statusCode };
        }
    }
}