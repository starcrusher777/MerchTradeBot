using Telegram.Bot;
using Telegram.Bot.Types;

namespace tradeBot.TelegramBot.Helpers;

public class MessageHelper
{
    private static MessageHelper _instance;
    private TelegramBotClient _botClient;

    private MessageHelper(TelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public MessageHelper GetInstance(TelegramBotClient botClient)
    {
        if (_instance == null) _instance = new MessageHelper(botClient);
        return _instance;
    }

    public async Task DeleteInteractionMessageAsync(CallbackQuery callbackQuery)
    {
        try
        {
            await _botClient.DeleteMessageAsync(chatId: callbackQuery.Message.Chat.Id,
                callbackQuery.Message!.MessageId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}