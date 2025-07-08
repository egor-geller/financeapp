namespace fin.server.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}