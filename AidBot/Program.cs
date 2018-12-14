using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace AidBot
{
    class Program : ModuleBase<SocketCommandContext>
    {

        //Global Variables to store the context of the bot
        private DiscordSocketClient Client;
        private CommandService Commands;
        private IServiceProvider Services;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        //the main task
        private async Task MainAsync()
        {
            //new instance of client context
            Client = new DiscordSocketClient();

            //new instance of command handler
            Commands = new CommandService();

            //builds the connection to the discord.net api
            Services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .BuildServiceProvider();

            //bot access token
            string token = "NTA0OTkzMjk4OTUyMzU1ODQw.DrNIUQ.pWXbI-a0IfzTxk3BByKyGkMYC6A";

            //logs the connection to the api
            Client.Log += Log;

            await RegisterCommandAsync();
            await Client.LoginAsync(TokenType.Bot, token);
            await Client.StartAsync();
            await Task.Delay(-1);

        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        private async Task RegisterCommandAsync()
        {
            Client.MessageReceived += HandleCommandAsync;

            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            //await LogMessagesAsync(message);

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasCharPrefix('/', ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(Client, message);
                var result = await Commands.ExecuteAsync(context, argPos, Services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }

        private async Task LogMessagesAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            Console.WriteLine($"{message.Channel} - {message.Author} - {message.Timestamp} - {message} ");

            StreamWriter sw = new StreamWriter($@"D:\\{message.Channel}Log.txt", true);
            sw.WriteLine($"{message.Source} {message.Author} - {message.Timestamp} - {message} ");
            sw.Close();



            await Task.CompletedTask;
        }
    }

}
