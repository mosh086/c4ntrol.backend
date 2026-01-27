namespace C4.Domain.Exceptions;

public class DomainException : BaseException
{
    public DomainException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
