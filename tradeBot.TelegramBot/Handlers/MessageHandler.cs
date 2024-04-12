using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using tradeBot.TelegramBot.Helpers;
using tradeBot.API.Models;





namespace tradeBot.TelegramBot.Handlers;

public class MessageHandler
{
    private readonly TelegramBotClient _client;

    public MessageHandler(TelegramBotClient client)
    {
        _client = client;
    }

    public async Task OnMessageReceived(Message message, CancellationToken cancellationToken)
    {
        var messageText = "";
        

    if (!string.IsNullOrEmpty(message.Text)) messageText = message.Text;
        else if (!string.IsNullOrEmpty(message.Caption)) messageText = message.Caption;
        else return;
        
        var action = messageText.Split(' ')[0] switch
        {
            "/start"    => Start(_client, message, cancellationToken),
            "/продажа"  => SellingOffer(_client, message, cancellationToken),
            
            _ => null
        };
        
        if (action != null)
        {
            await action;
        }
    }

    private async Task<Message> Start(ITelegramBotClient _client, Message message, CancellationToken cancellationToken)
    {
        return await _client.SendTextMessageAsync(chatId: message.From.Id, 
            text: "Для начала, введите свой логин и пароль через пробел.\\n\" +\n                  \"Пример: \\\"username 123123\\", cancellationToken: cancellationToken);
    }
    
    public async Task<Message> SellingOffer(ITelegramBotClient _client, Message message,
        CancellationToken cancellationToken)
    {
        
        var splittedMsg = (string.IsNullOrEmpty(message.Text) ? message.Caption : message.Text).Split(' ').ToList();
        splittedMsg.RemoveAt(0);
        var text = string.Join(" ", splittedMsg);
        var textList = text.ToList();
        var telegramId = message.From.Id;
        var offerType = text[2].ToString();
        var name = text[3].ToString();
        var price = text[4];
        var description = text[5].ToString();
        byte[] imageData;
        using (var ms = new MemoryStream())
        {
            await _client.GetInfoAndDownloadFileAsync(message.Photo[0].FileId, ms, cancellationToken);
            imageData = ms.ToArray();
        }
        
        OfferModel offerModel = new OfferModel()
        {
            UserId = telegramId,
            OfferType = offerType,
            Name = name,
            Price = price,
            Description = description,
            ImageData = imageData 
        };
        return new Message();
    }
}
