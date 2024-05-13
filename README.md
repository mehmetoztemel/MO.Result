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
Kullanımda, Result<T> tipini metotların dönüş değeri olarak kullanabilirsiniz. Bu tip, başarılı veya başarısız bir işlemi temsil eder. Success ve Fail metotlarıyla sonuç döndürülebilir.

Özellikler
Açıklayıcı Sonuçlar: Metotların dönüş değerlerini daha açıklayıcı hale getirir.
Hata İşleme: Başarısız işlemlerin yönetimini kolaylaştırır.
Generics Desteği: Herhangi bir tür için sonuçlar döndürmek için generics desteği sağlar.
Katkıda Bulunma

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
