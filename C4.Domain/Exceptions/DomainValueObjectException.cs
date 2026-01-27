namespace C4.Domain.Exceptions;

public class DomainValueObjectException : BaseException
{
    public DomainValueObjectException(string message, params string[] parameters) : base(message, parameters)
    {
    }
}
