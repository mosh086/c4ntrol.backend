namespace C4.Application.UseCases.Security.User.Handlers.AppUserLogin.Login;

public class LoginPostRequest : RequestModel<LoginPostResponse>
{
    public string User { get; set; }
    public string Password { get; set; }
}
