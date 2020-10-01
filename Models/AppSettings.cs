using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramCalcBot.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://telegramcalcbot.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "Ipatoff_bot";

        public static string Key { get; set; } = "";

    }
}