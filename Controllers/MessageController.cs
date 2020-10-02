using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TelegramCalcBot.Models;
using Telegram.Bot.Types;
using TelegramCalcBot.Models.Commands;

namespace TelegramCalcBot.Controllers
{
    class Data
    {
        public static Dictionary<long, Command> clientChat = new Dictionary<long, Command>();

        public static bool check(long key)
        {
            if (clientChat.ContainsKey(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void append(long key, Command value)
        {
            clientChat.Add(key, value);
        }
        public static void delete(long key)
        {
            clientChat.Remove(key);
        }

        public static void edit(long key, Command value)
        {
            clientChat[key] = value;
        }

        public static Command get(long key)
        {
            return clientChat[key];
        }
    }

    public class MessageController : ApiController
    {
        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody] Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();
            bool flag = Data.check(message.Chat.Id);
            bool flagCommand = false;
            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    if(Data.check(message.Chat.Id) == true)
                    {
                        Data.edit(message.Chat.Id, command);
                    }
                    else
                    {
                        Data.append(message.Chat.Id, command);
                    }
                    flagCommand = true;
                    command.Execute(message, client);
                    break;
                }
            }

            if(flagCommand == false && flag == true)
            {
                Data.get(message.Chat.Id).Execute(message, client);
            }

            return Ok();
        }

    }
}