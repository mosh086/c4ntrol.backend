namespace C4.Application.UseCases.Security.User.Handlers.AppUser.Update;

public class UserUpdateValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateValidator()
    {
        // RuleFor(item => item.Email).EmailAddress().WithMessage("Email Is Not Correct Format ...");
        // Add other validation rules as needed
    }
}
