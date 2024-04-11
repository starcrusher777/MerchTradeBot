using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using tradeBot.TelegramBot.Helpers;
using tradeBot.TelegramBot.Handlers; 

namespace tradeBot.TelegramBot.Handlers;

public class CallbackHandler
{
    private readonly TelegramBotClient _client;

    public CallbackHandler(TelegramBotClient client)
    {
        _client = client;
    }
    
    public async Task OnMessageReceived(Message message, CancellationToken cancellationToken)
    {
        var messageText = "";
        

        if (!string.IsNullOrEmpty(message.Text)) messageText = message.Text;
        else if (!string.IsNullOrEmpty(message.Caption)) messageText = message.Caption;
        else return;
    }
    public async Task OnCallbackReceived(CallbackQuery callbackQuery, CancellationToken cancellationToken)
    {
        var action = callbackQuery.Data.Split(' ')[0] switch
        {
            "mainMenu" => MainMenu(_client, callbackQuery),
            "countWarps" => CountWarps(_client, callbackQuery),
            "countJade" => CountJade(_client, callbackQuery),
            _ => HandleUnrecognizedCallback(_client, callbackQuery)
        };

        await action;
    }

    private async Task<Message> MainMenu(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        return await botClient.SendTextMessageAsync(
            chatId: callbackQuery.Message!.Chat.Id,
            text: "Основное меню",
            replyMarkup: KeyboardHelper.GetMainMenuKeyboard(callbackQuery.From.Id));
    }

    public async Task<Message> CountWarps(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        return new Message();
    }
    
    public async Task<Message> CountJade(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        return new Message();
    }

    private async Task<Message> HandleUnrecognizedCallback(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        // Handle or log the fact that the callback data is not recognized.
        // You might want to inform the user or take other appropriate actions.

        return await botClient.SendTextMessageAsync(
            chatId: callbackQuery.Message!.Chat.Id,
            text: "Unrecognized callback data");
    }
}