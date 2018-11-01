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
        private DiscordSocketClient Client;
        private CommandService Commands;
        private IServiceProvider Services;

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            Client = new DiscordSocketClient();
            Commands = new CommandService();
            Services = new ServiceCollection()
                .AddSingleton(Client)
                .AddSingleton(Commands)
                .BuildServiceProvider();

            string token = "NTA0OTkzMjk4OTUyMzU1ODQw.DrNIUQ.pWXbI-a0IfzTxk3BByKyGkMYC6A";

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

            await LogMessagesAsync(message);

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

            StreamWriter sw = new StreamWriter($@"D:\core\AidBot\AidBot\Resources\{message.Channel}Log.txt", true);
            sw.WriteLine($"{message.Source} {message.Author} - {message.Timestamp} - {message} ");
            sw.Close();



            await Task.CompletedTask;


        }


        [Command("ping")]
        //ALL DEVS: name all tasks the name of the command + Async at the end
        public async Task PingAsync()
        {
            //enter the text you want the bot to reply with in the async task below
            await ReplyAsync("pong");
        }
    }

}
