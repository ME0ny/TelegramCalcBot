using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Controllers;
using TelegramCalcBot.Models.Calculator;

namespace TelegramCalcBot.Models.Commands
{
    public class Start : Command
    {
        public override string Name => "start";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            client.SendTextMessageAsync(message.Chat.Id,
@"Я понимаю команды:
/start - меню
/rpn - обратная польская запись
/calculator - калькулятор");

        }
    }
}