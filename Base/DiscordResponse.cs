using BitheroesBot.Enums;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitheroesBot.Base
{
    public class DiscordResponse
    {
        public string Title { get; set; } = string.Empty;
        public string AdditionalHeader { get; set; } = string.Empty;
        public string Body1 { get; set; } = string.Empty;
        public string Body2 { get; set; } = string.Empty;
        public string Footer { get; set; } = string.Empty;
        public DiscordCommand discordCommand { get; private set; }
        public DiscordArguments discordArguments { get; private set; }
        public SocketMessage Original { get; private set; }
        public DiscordResponse(DiscordCommand command, DiscordArguments arguments, SocketMessage original)
        {
            this.discordCommand = command;
            this.discordArguments = arguments;
            switch(command)
            {
                //All Title 

                //By Command
                case DiscordCommand.None:
                    Title = "Not a Command"; 
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    //Run some method to verify player
                    Title = "Player Verification Response";
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                case DiscordCommand.GetMyExtendedId:
                    Title = "You have broken all sorts of rules and are going on a list.. tsk.";
                    Body1 = $"Deep Hack ID : {original.Author}";
                    break;
                default:
                    break;
            }

        }
        public void FormatTitle(DiscordCommand command)
        {
            //All Title 

            //By Command
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    //each method apply it's own formatting based on command. 
                    //example Title = string.Format($"###{Title}###"); 
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                case DiscordCommand.GetMyExtendedId:
                    break;

                default:
                    break;
            }
        }
        public void FormatAdditionalHeader(DiscordCommand command)
        {
            //All AdditionalHeader 

            //By Command
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                case DiscordCommand.GetMyExtendedId:
                    break;
                default:
                    break;
            }
        }
        public void FormatBody1(DiscordCommand command)
        {
            //All Body1 

            //By Command
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                case DiscordCommand.GetMyExtendedId:
                    break;
                default:
                    break;
            }
        }
        public void FormatBody2(DiscordCommand command)
        {
            //All Body2

            //By Command
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                case DiscordCommand.GetMyExtendedId:
                    break;
                default:
                    break;
            }
        }
        public void FormatFooter(DiscordCommand command)
        {
            //All Footer 

            //By Command
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                case DiscordCommand.GetMyExtendedId:
                    break;
                default:
                    break;
            }
        }
        //global formatting here 'for all title for all body etc'
        public string FormatResponseToSend(DiscordCommand command) {

            FormatTitle(command);
            FormatAdditionalHeader(command);
            FormatBody1(command);
            FormatBody2(command);
            FormatFooter(command);

            //do your formatting here ## etc to help the text format to how you want it to look in discord. 
            //specific to call formatting would be done before this point, this is formatting you want applied to all messages after you have done specific formating. 
          
            //Can add Case statement here based on command type to format based on command. 


            return String.Format($"{Title}\n {AdditionalHeader}\n {Body1}\n {Body2}\n {Footer}\n");
        
        
        }
    }
}
