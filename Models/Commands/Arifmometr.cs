using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramCalcBot.Controllers;
using TelegramCalcBot.Models.Calculator;

namespace TelegramCalcBot.Models.Commands
{
    public class Arifmometr : Command
    {
        public override string Name => "calculator";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            bool flag = Data.check(message.Chat.Id);

            if (message.Text == "/calculator")
            {
                start(message, client);
            }
            else
            {
                client.SendTextMessageAsync(chatId, Convert.ToString(Calculation.Computation(ReversePolishNotion.Get_RPN(message.Text))));
                Data.delete(chatId);
            }

        }

        public static void start(Message message, TelegramBotClient client)
        {
            client.SendTextMessageAsync(message.Chat.Id, "Калькулятор: введите арифметическое выражение");
        }
    }
}