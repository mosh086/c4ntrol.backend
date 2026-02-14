using C4.Application.UseCases.Security.User.Repositories;

namespace C4.Application.UseCases.Security.User.Handlers.AppUserLogin.Login;

public class LoginPostHandler : Handler<LoginPostRequest, LoginPostResponse>
{
    private readonly IUserLoginRepository _repository;
    public LoginPostHandler(ProviderServices providerServices, IUserLoginRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<LoginPostResponse> Handle(LoginPostRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var user = _repository.GetByUsernameAsync(request.User);



            return new LoginPostResponse("Token");
        }
        catch (Exception ex)
        {
            // Log error if needed
            throw new ApplicationException("", ex);
        }
    }
}

