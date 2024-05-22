namespace tradeBot.API.Exceptions.User;

public class UserIdNotFoundException : BaseException
{
    public UserIdNotFoundException(long telegramId) : base($"Пользователь с айди '{telegramId}' не найден!")
    {
    }
}