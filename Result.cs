namespace MO.Result
{
    public sealed class Result<T>
    {
        public T? Data { get; private set; }
        public List<string> ErrorMessages { get; private set; }
        public int StatusCode { get; private set; }
        public bool IsSuccess => ErrorMessages.Count == 0;

        private Result(T data)
        {
            Data = data;
            StatusCode = 200;
            ErrorMessages = new List<string>();
        }

        private Result(List<string> errorMessages, int statusCode)
        {
            ErrorMessages = errorMessages ?? new List<string>();
            StatusCode = statusCode;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(data);
        }

        public static Result<T> Failure(List<string> errorMessages, int statusCode = 999)
        {
            return new Result<T>(errorMessages, statusCode);
        }

        public static Result<T> Failure(string errorMessage, int statusCode = 999)
        {
            return new Result<T>(new List<string> { errorMessage }, statusCode);
        }
    }
}