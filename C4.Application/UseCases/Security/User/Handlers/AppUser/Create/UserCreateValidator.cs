namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Create;

public class UserCreateValidator : AbstractValidator<UserCreateRequest>
{
    public UserCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");

    }
}