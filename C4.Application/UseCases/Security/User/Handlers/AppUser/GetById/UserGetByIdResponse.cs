using C4.Application.UseCases.Security.User.Repositories;
using C4.Domain.UseCases.Security;

namespace C4.Application.UseCases.Security.User.Handlers.AppUser.GetById;

public class UserGetByIdResponse : BaseDTO
{
    public string Email { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
}

public class UserGetByIdRequest : RequestModel<UserGetByIdResponse>
{
    public UserGetByIdRequest(Guid entityId)
    {
        EntityId = entityId;
    }

    public string Email { get; set; } = string.Empty;
    public Guid EntityId { get; set; }
    // Add other request properties here
}

public class UserGetByIdHandler : Handler<UserGetByIdRequest, UserGetByIdResponse>
{
    private readonly IUserRepository _repository;
    public UserGetByIdHandler(ProviderServices providerServices, IUserRepository repository) : base(providerServices)
    {
        _repository = repository;
    }

    public override async Task<UserGetByIdResponse> Handle(UserGetByIdRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.GetAsync(request.EntityId, cancellationToken);

            return ProviderServices.Mapper.Map<AppUserEntity, UserGetByIdResponse>(entity);
        }
        catch (Exception ex)
        {
            // Log error if needed
            throw new ApplicationException("", ex);
        }
    }
}

public class UserProfile : Profile
{
    public UserProfile()
    {
        // Add other mappings as needed
        CreateMap<AppUserEntity, UserGetByIdResponse>().ReverseMap();
    }
}

public class UserGetByIdValidator : AbstractValidator<UserGetByIdRequest>
{
    public UserGetByIdValidator()
    {
        RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
        // Add other validation rules as needed
    }
}