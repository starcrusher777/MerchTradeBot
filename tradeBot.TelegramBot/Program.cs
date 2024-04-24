﻿using tradeBot.TelegramBot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using tradeBot.Connector;


var connector = new Connector(new List<(string, string)>());

TelegramBotClient botClient = new TelegramBotClient("token"); //replace with ur actual token

using CancellationTokenSource cts = new ();

// StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
ReceiverOptions receiverOptions = new ()
{
    AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
};

var messageHandler = new MessageHandler(botClient, connector);
var callbackHandler = new CallbackHandler(botClient, connector);

async Task HandleUpdateAsync(ITelegramBotClient _, Update update, CancellationToken cancellationToken)
{
    var handler = update switch
    {
        // UpdateType.Unknown:
        // UpdateType.ChannelPost:
        // UpdateType.EditedChannelPost:
        // UpdateType.ShippingQuery:
        // UpdateType.PreCheckoutQuery:
        // UpdateType.Poll:
        { Message: { } message }                       => messageHandler.OnMessageReceived(message, cancellationToken),
        //{ EditedMessage: { } message }                 => BotOnMessageReceived(message, cancellationToken),
        { CallbackQuery: { } callbackQuery }           => callbackHandler.OnCallbackReceived(callbackQuery, cancellationToken),
        _                                              => Unknown()
    };

    try
    {
        await handler;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandlePollingErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: cts.Token
);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Start listening for @{me.Username}");
await Task.Delay(Timeout.Infinite);

// Send cancellation request to stop bot
cts.Cancel();


Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    var ErrorMessage = exception switch
    {
        ApiRequestException apiRequestException
            => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
        _ => exception.ToString()
    };

    Console.WriteLine(ErrorMessage);
    return Task.CompletedTask;
}

Task Unknown()
{
    return Task.CompletedTask;
}