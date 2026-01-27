using C4.Domain.Exceptions;

namespace C4.Application.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message)
    {

    }
    public NotFoundException(Exception exception) : base(exception.Message, exception)
    {

    }
}