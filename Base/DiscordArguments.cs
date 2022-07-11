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
            var start = 0;
            var end = remainingMessage.NextSpace();
            //could probably be written less directly in iterations. 
            if (!remainingMessage.StartsWith("!"))
            {
                CommandText = string.Empty;
                Argument1 = remainingMessage;
                return;
            }
            remainingMessage = remainingMessage.Substring(1); //get rid of !

            if (end < 1)
            {
                CommandText = FromToDictionary.ConvertFromTo(remainingMessage);
                return;
            }
            end = remainingMessage.NextSpace();
            CommandText = FromToDictionary.ConvertFromTo(remainingMessage.Substring(start, end));
            remainingMessage = remainingMessage.Substring(end).Trim(); 

            start = 0;
            end = remainingMessage.NextSpace();
            if (end < 1)
            {
                Argument1 = remainingMessage;
                return;
            }
            Argument1 = remainingMessage.Substring(start, end);
            remainingMessage = remainingMessage.Substring(end).Trim();


            start = 0;
            end = remainingMessage.NextSpace();
            if (end < 1)
            {
                Argument2 = remainingMessage;
                return;
            }
            Argument2 = remainingMessage.Substring(start, end);
            remainingMessage = remainingMessage.Substring(end).Trim();

            start = 0;
            end = remainingMessage.NextSpace();
            if (end < 1)
            {
                Argument3 = remainingMessage;
                return;
            }
            Argument3 = remainingMessage.Substring(start, end).Trim();
            remainingMessage = remainingMessage.Substring(end).Trim();
            Argument4 = remainingMessage;

        }
    }
}
