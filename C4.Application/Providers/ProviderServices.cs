using C4.Application.Providers.CacheSystem;
using C4.Application.Providers.DataDapper;
using C4.Application.Providers.ObjectMapper;
using C4.Application.Providers.Serializer.Objects;
using C4.Application.Providers.UserManagement;

namespace C4.Application.Providers;

public class ProviderServices
{
    public readonly IObjectSerializer Convertor;
    public readonly IObjectMapper Mapper;
    public readonly ICacheAdapter CacheAdapter;
    public readonly IMediator Mediator;
    public readonly IDataDapper DataDapper;
    public readonly IUser User;
    public ProviderServices(
        IObjectSerializer convertor,
        IObjectMapper mapper,
        ICacheAdapter cacheAdapter,
        IMediator mediator,
        IUser user,
        IDataDapper dataDapper)
    {
        Convertor = convertor;
        Mapper = mapper;
        CacheAdapter = cacheAdapter;
        Mediator = mediator;
        User = user;
        DataDapper = dataDapper;
    }
}
