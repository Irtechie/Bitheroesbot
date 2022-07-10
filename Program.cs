using BitheroesBot.Base;
using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BitheroesBot
{

    //based off of https://www.youtube.com/watch?v=IcnuPWyxMes with a lot of added support classes to make it easier for others to create their own.
    class Program
    {
        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();
        public const string TokenLocation = @"c:\\discordbot\token.txt"; //place to put your developer token
        private DiscordSocketClient _discordSocketClient; 
        public async Task MainAsync()
        {
            var token = GetTokenFromTextFile();

            _discordSocketClient = new DiscordSocketClient();
            _discordSocketClient.Log += Log;
            _discordSocketClient.MessageReceived += _discordSocketClient_MessageReceived;

            await _discordSocketClient.LoginAsync(TokenType.Bot, token);
            await _discordSocketClient.StartAsync(); 
            await Task.Delay(-1);
            
        }

        private Task _discordSocketClient_MessageReceived(SocketMessage message)
        {
            //find a better way to do validation later
            if (message.Content.StartsWith("!") && !message.Author.IsBot)
            {
                return ProcessMessage(message);
            }
            //implicit else -- do nothing if bot or no !
            return Task.CompletedTask;
        }

        private Task ProcessMessage(SocketMessage message)
        {
            //break up message and create parts. 
            var processingMessage = new DiscordMessage(message);
            message.Channel.SendMessageAsync($@"{message.Author.Mention} {processingMessage.Response.FormatResponseToSend(processingMessage.Command)}");
            return Task.CompletedTask;
            
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString().Trim());
            return Task.CompletedTask;
        }

        private string GetTokenFromTextFile()
        {
            return File.ReadAllText(TokenLocation);
        }
    }
}
