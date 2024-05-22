namespace tradeBot.API.Exceptions.User;

public class BaseException : Exception
{
    public BaseException(string message) : base(message)
    {
    }

    /// <summary>
    /// In case of using these custom exceptions we don't need to show stack trace due to its simplicity
    /// </summary>
    public override string? StackTrace
    {
        get
        {
            return "";
        }
    }
}