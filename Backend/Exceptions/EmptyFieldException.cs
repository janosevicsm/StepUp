namespace Backend.Exceptions;

public class EmptyFieldException : Exception
{
    public EmptyFieldException() { }
    public EmptyFieldException(string message) : base(message) { }
}