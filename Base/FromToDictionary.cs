using BitheroesBot.Base;
using BitheroesBot.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BitheroesBot.Extensions;

namespace BitheroesBot.Constants
{ 
    //if this gets large we can move to sqltable
    public class FromToDictionary
    {
        //Set all your commands in here that make sense. Example v => VerifyInGamePlayer
        public static List<FromTo> All = new List<FromTo>()
        {
            new FromTo(DiscordCommandConstants.v, DiscordCommandConstants.VerifyInGamePlayer),
            new FromTo(DiscordCommandConstants.wb, DiscordCommandConstants.RequestWBGroup),
        };
        public static string ConvertFromTo(string from)
        {
            if (from.Trim() == "")
            {
                return "";
            }
            return All.Where(e => e.From.ToLower().Trim() == from.ToLower().Trim()).FirstOrDefault().To;
        }

        public static DiscordCommand CreateCommandFromInputText(string commandText)
        {
            var output = DiscordCommand.None;
            if (commandText.Trim() == string.Empty)
            {
                return output;
            }
            output = commandText.ToEnum<DiscordCommand>();
            return output; 
        }
    }
}
