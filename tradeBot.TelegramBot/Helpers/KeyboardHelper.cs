using Telegram.Bot.Types.ReplyMarkups;

namespace tradeBot.TelegramBot.Helpers;

public class KeyboardHelper
{
    public static InlineKeyboardMarkup GetMainMenuKeyboard(long telegramId)
    {
        var mainMenuKeyboard = new List<List<InlineKeyboardButton>>();

        var commonButtons = new List<InlineKeyboardButton>
        {
            InlineKeyboardButton.WithCallbackData("Посчитать прыжки", "countWarps"),
            InlineKeyboardButton.WithCallbackData("Нефрит за патч", "countJade"),
        };
        mainMenuKeyboard.Add(commonButtons);
        
        return new InlineKeyboardMarkup(mainMenuKeyboard);
    }
}