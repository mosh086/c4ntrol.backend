using C4.Application.Providers;

namespace C4.WebApi.Extensions;

public static class HttpContextExtensions
{
    public static ProviderServices ApplicationContext(this HttpContext httpContext) =>
        (ProviderServices)httpContext.RequestServices.GetService(typeof(ProviderServices))!;

}