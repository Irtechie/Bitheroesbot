using BitheroesBot.Enums;
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
        private DiscordCommand discordCommand;
        private DiscordArguments discordArguments;
        public DiscordResponse(DiscordCommand command, DiscordArguments arguments)
        {
            this.discordCommand = command;
            this.discordArguments = arguments;
            switch(command)
            {
                case DiscordCommand.None:
                    Title = "Not a Command"; 
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    //Run some method to verify player
                    Title = "Player Verification Response";
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                default:
                    break;
            }

        }
        public void FormatTitle(DiscordCommand command)
        {
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
                default:
                    break;
            }
        }
        public void FormatAdditionalHeader(DiscordCommand command)
        {
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                default:
                    break;
            }
        }
        public void FormatBody1(DiscordCommand command)
        {
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                default:
                    break;
            }
        }
        public void FormatBody2(DiscordCommand command)
        {
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
                    break;
                default:
                    break;
            }
        }
        public void FormatFooter(DiscordCommand command)
        {
            switch (command)
            {
                case DiscordCommand.None:
                    break;
                case DiscordCommand.VerifyInGamePlayer:
                    break;
                case DiscordCommand.RequestWBGroup:
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
            var title = Title;
            var additionalHeader = AdditionalHeader;
            var body1 = Body1;
            var body2 = Body2;
            var footer = Footer;

            //Can add Case statement here based on command type to format based on command. 


            return String.Format($"{title}\n {additionalHeader}\n {body1}\n {body2}\n {footer}\n");
        
        
        }
    }
}
