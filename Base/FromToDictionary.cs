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
            //basically a more foolproof way to make short to long names. 
            //shortnames are lowercase, longer are propercase to match constants
            new FromTo(string.Empty, String.Empty),
            new FromTo(DiscordCommandConstants.v, DiscordCommandConstants.VerifyInGamePlayer),
            new FromTo(DiscordCommandConstants.wb, DiscordCommandConstants.RequestWBGroup),
            new FromTo(DiscordCommandConstants.myid, DiscordCommandConstants.GetMyExtendedId)
        };
        public static string ConvertFromTo(string from)
        {
            from = from.ToLower().Trim();
            if (from == "")
            {
                return from;
            }

            return All.Where(e => e.From.ToLower().Trim() == from).FirstOrDefault().To;
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
