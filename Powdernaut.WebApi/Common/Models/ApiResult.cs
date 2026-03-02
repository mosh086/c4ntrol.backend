namespace Powdernaut.WebApi.Common.Models;

public class ApiResult
{
    public static ApiResult<T> Success<T>(T data)
    {
        return new ApiResult<T>()
        {
            Data = data,
            Error = null!,
            Message = "Success",
            Success = true,
            Token = ""
        };
    }

    public static ApiResult<T> Return<T>(T data)
    {
        if (data is null || data is false)
            return Faild(data);
        return Success(data);
    }

    public static ApiResult<T> Faild<T>(T data)
    {
        return new ApiResult<T>()
        {
            Data = data,
            Error = null!,
            Message = "Faild",
            Success = false,
            Token = ""
        };
    }
    public static ApiResult<bool> UnAuthorize()
    {
        return new ApiResult<bool>()
        {
            Data = false,
            Error = null!,
            Message = "Unauthorized access. Please log in.",
            Success = false,
            Token = ""
        };
    }
}
public class ApiResult<T> : ApiResult
{
    public bool Success { get; set; }
    public T Data { get; set; } = default!;
    public string Message { get; set; } = string.Empty;
    public Exception Error { get; set; } = default!;
    public string Token { get; set; } = string.Empty;
}