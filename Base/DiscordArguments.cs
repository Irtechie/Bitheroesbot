using BitheroesBot.Constants;
using BitheroesBot.Extensions;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitheroesBot.Base
{
    public class DiscordArguments
    {
        public string CommandText { get; set; } = string.Empty;
        public string Argument1 { get; set; } = string.Empty;
        public string Argument2 { get; set; } = string.Empty;
        public string Argument3 { get; set; } = string.Empty;
        public string Argument4 { get; set; } = string.Empty;
        public DiscordArguments(SocketMessage message)
        {
            var messageTrimmed = message.Content.Trim();
            var remainingMessage = messageTrimmed;
            //could probably be written less directly in iterations. 
            if (!remainingMessage.StartsWith("!") || remainingMessage.NextSpace() == -1)
            {
                CommandText = string.Empty;
                Argument1 = remainingMessage;
                return;
            }
            var start = 1;
            var end = remainingMessage.NextSpace();
            CommandText = FromToDictionary.ConvertFromTo(remainingMessage.Substring(start, end));
            remainingMessage = remainingMessage.Substring(end);

            start = 0;
            end = remainingMessage.NextSpace();
            if (end == -1)
            {
                Argument1 = remainingMessage;
                return;
            }
            Argument1 = FromToDictionary.ConvertFromTo(remainingMessage.Substring(start, end));
            remainingMessage = remainingMessage.Substring(end);


            start = 0;
            end = remainingMessage.NextSpace();
            if (end == -1)
            {
                Argument2 = remainingMessage;
                return;
            }
            Argument2 = FromToDictionary.ConvertFromTo(remainingMessage.Substring(start, end));
            remainingMessage = remainingMessage.Substring(end);

            start = 0;
            end = remainingMessage.NextSpace();
            if (end == -1)
            {
                Argument3 = remainingMessage;
                return;
            }
            Argument3 = FromToDictionary.ConvertFromTo(remainingMessage.Substring(start, end));
            Argument4 = remainingMessage;

        }
    }
}
