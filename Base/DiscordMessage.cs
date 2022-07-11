using System;
using System.Collections.Generic;
using System.Text;
using BitheroesBot.Constants;
using BitheroesBot.Enums;
using Discord.WebSocket;

namespace BitheroesBot.Base
{
    public  class DiscordMessage
    {
        public DiscordCommand Command { get; set; }
        public DiscordArguments Arguments { get; set; }
        public DiscordResponse Response {get; set;}
        public DiscordMessage(SocketMessage message)
        {
            //I do parsing in this method. 
            Arguments = new DiscordArguments(message);
            Command = FromToDictionary.CreateCommandFromInputText(Arguments.CommandText);
            Response = new DiscordResponse(Command, Arguments, message);
        }
    }
}
