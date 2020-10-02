using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Controllers;
using TelegramCalcBot.Models.Calculator;

namespace TelegramCalcBot.Models.Commands
{
    public class RPN : Command
    {
        public override string Name => "rpn";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            bool flag = Data.check(message.Chat.Id);

            if (message.Text == "/rpn")
            {
                start(message, client);
            }
            else
            {
                client.SendTextMessageAsync(chatId, ReversePolishNotion.Get_RPN(message.Text));
                Data.delete(chatId);
            }


        }

        public static void start(Message message, TelegramBotClient client)
        {
            client.SendTextMessageAsync(message.Chat.Id, "Введите арифметическое выражение, чтобы определить ОПЗ");
        }
    }
}