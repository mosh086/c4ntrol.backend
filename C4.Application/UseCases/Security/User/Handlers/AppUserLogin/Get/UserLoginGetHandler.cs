using C4.Application.UseCases.Security.User.Repositories;

namespace C4.Application.UseCases.Security.User.Handlers.AppUserLogin.Get;

public class UserLoginGetHandler : Handler<UserLoginGetRequest, List<UserLoginGetResponse>>
{
    private readonly IUserLoginRepository _repository;
    public UserLoginGetHandler(ProviderServices providerServices, IUserLoginRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<List<UserLoginGetResponse>> Handle(UserLoginGetRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Add your business logic here
            // Example:
            // var user = new User { Email = request.Email };
            // await _repository.CreateAsync(user);

            return new List<UserLoginGetResponse>();
        }
        catch (Exception ex)
        {
            // Log error if needed
            throw new ApplicationException("", ex);
        }
    }
}

