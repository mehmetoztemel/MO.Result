# MO.Result NuGet Package

This package is designed to make the transaction results more understandable.

## Installation
To integrate MO.Result into your project, install it via the NuGet package manager:
Install-Package MO.Result

Or through the .NET CLI:
dotnet add package MO.Result

## Usage 
```csharp

## Success 

return Result<string>.Success("User create is successful");
return Result<data type>.Success(data);

## Fail
return Result<string> Fail(401, "Something wrong")
return Result<string>.Failure(new List<string>() {"User not found!","Password is wrong!"});


```

## Source Code 
```
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
```