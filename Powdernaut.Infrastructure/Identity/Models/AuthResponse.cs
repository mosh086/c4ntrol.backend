using Powdernaut.Application.Common.Models.DTOs;

namespace Powdernaut.Infrastructure.Identity.Models;



public class IdentityOption
{
    public JwtOptions Jwt { get; set; }
}
public class JwtOptions
{
    public int ExpireMinutes { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string Key { get; set; }
}



public class IdentityResult<T> : IdentityResult
{
    public T Result { get; set; }
    public IdentityResult(bool success, T value)
    {
        Succeeded = success;
        Result = value;
    }
}