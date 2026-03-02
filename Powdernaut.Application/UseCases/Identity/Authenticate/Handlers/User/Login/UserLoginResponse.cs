namespace Powdernaut.Application.UseCases.Identity.Authenticate.Handlers.User.Login;

public class UserLoginResponse : BaseDTO
{
    public string Message { get; set; }
    public UserLoginResponse(string message)
    {
        Message = message;
    }
}