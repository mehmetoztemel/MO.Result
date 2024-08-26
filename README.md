# MO.Result NuGet Package

MO.Result, .NET projeleri için özel olarak tasarlanmış bir sonuç dönüşüm kütüphanesidir. Bu kütüphane, metotlarınızın dönüş değerlerini daha açıklayıcı hale getirmenize olanak tanırken, hata işleme sürecini kolaylaştırmak için kullanılır.

## Nasıl Kullanılır
Kullanım: MO.Result'ı kullanmak için aşağıdaki adımları izleyin:

```csharp
using MO.Result;

public class ExampleService
{
    public Result<int> Divide(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            return Result<int>.Fail("Denominator cannot be zero.");
        }

        int result = numerator / denominator;
        return Result<int>.Success(result);
    }
}
```
Kullanımda, Result <T> tipini metotların dönüş değeri olarak kullanabilirsiniz. Bu tip, başarılı veya başarısız bir işlemi temsil eder. Success ve Fail metotlarıyla sonuç döndürülebilir.

Özellikler
Açıklayıcı Sonuçlar: Metotların dönüş değerlerini daha açıklayıcı hale getirir.
Hata İşleme: Başarısız işlemlerin yönetimini kolaylaştırır.
Generics Desteği: Herhangi bir tür için sonuçlar döndürmek için generics desteği sağlar.
Katkıda Bulunma

## Source Code 
```
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
```
