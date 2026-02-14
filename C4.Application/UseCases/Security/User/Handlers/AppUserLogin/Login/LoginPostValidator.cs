namespace C4.Application.UseCases.Security.User.Handlers.AppUserLogin.Login;

public class LoginPostValidator : AbstractValidator<LoginPostRequest>
{
    public LoginPostValidator()
    {
        RuleFor(x => x.User)
            .NotEmpty().WithMessage("User is required")
            .EmailAddress().WithMessage("A valid User is required");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
