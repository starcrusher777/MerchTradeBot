using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using tradeBot.TelegramBot.Helpers;
using tradeBot.TelegramBot.Handlers; 
using Refit;

namespace tradeBot.TelegramBot.Handlers;

public class CallbackHandler
{
    private readonly TelegramBotClient _client;
    private readonly MessageHelper _messageHelper;
    private readonly Connector.Connector _connector;

    public CallbackHandler(TelegramBotClient client, Connector.Connector connector)
    {
        _client = client;
        _messageHelper = _messageHelper.GetInstance(client);
        _connector = connector;
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
        var previousPath = await _connector.API.Telegram.GetPreviousMenu(callbackQuery.From.Id);
        var isBackButton = callbackQuery.Data.EndsWith("!back");
        var backButtonCallback = previousPath.Split("=").Last();

        if (isBackButton)
        {
            callbackQuery.Data = callbackQuery.Data.Split("!back").First();
            var temp = previousPath.Split("=").ToList();
            temp.RemoveAt(temp.Count - 1);
            previousPath = string.Join("=", temp);
            await _connector.API.Telegram.SetPreviousMenu(callbackQuery.From.Id, string.IsNullOrEmpty(previousPath) ? "=toMainMenu" : previousPath);
            temp.RemoveAt(temp.Count - 1);
            backButtonCallback = temp.Last();
        }

        var button = InlineKeyboardButton.WithCallbackData("Назад", $"{backButtonCallback}!back");
        var action = callbackQuery.Data.Split(' ')[0] switch
        {
            "mainMenu" => MainMenu(_client, callbackQuery),
            
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
    
    private async Task<Message> HandleUnrecognizedCallback(ITelegramBotClient botClient, CallbackQuery callbackQuery)
    {
        // Handle or log the fact that the callback data is not recognized.
        // You might want to inform the user or take other appropriate actions.

        return await botClient.SendTextMessageAsync(
            chatId: callbackQuery.Message!.Chat.Id,
            text: "Unrecognized callback data");
    }
}