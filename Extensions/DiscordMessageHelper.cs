using System;
using System.Collections.Generic;
using System.Text;

namespace BitheroesBot.Extensions
{
    public static class DiscordMessageHelper
    {
        public static int NextSpace(this string input) {
            return input.IndexOf(" ");
        }
    }
}
