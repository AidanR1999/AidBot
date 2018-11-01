using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace AidBot.Commands
{
    public class TextReplies : ModuleBase<SocketCommandContext>
    {

        /*
         * This class is only for basic text replies, please use another class if your command isnt basic
         */

        //Ping command
        //command line is what you want the bot to respond to after the prefix /
        [Command("ping")]
        //ALL DEVS: name all tasks the name of the command + Async at the end
        public async Task PingAsync()
        {
            //enter the text you want the bot to reply with in the async task below
            await ReplyAsync("pong");
        }

        //Daniel command
        [Command("daniel")]
        public async Task DanielAsync()
        {
            await ReplyAsync("hahahahaha what a fucking twink");
        }

        //Lenny command
        [Command("lenny")]
        public async Task LennyAsync()
        {
            await ReplyAsync("( ͡° ͜ʖ ͡°)");
        }

        //Node command
        [Command("node")]
        public async Task NodeAsync()
        {
            await ReplyAsync("o shit, run from @Mark209917#9164");
        }

        //Yeeted command
        [Command("yeeted")]
        public async Task YeetedAsync()
        {
            await ReplyAsync("It's actually 'Yote' or 'Yoted'");
        }

        
        [Command("add")]
        public async Task lookCounterAsync()
        {

            StreamReader sr = new StreamReader($@"D:\\C# Projects\AidBot\AidBot\bin\lookCounter.txt");
            int counter = Int32.Parse(sr.ReadToEnd());
            sr.Close();

            counter++;

            StreamWriter sw = new StreamWriter($@"D:\\C# Projects\AidBot\AidBot\bin\lookcounter.txt");
            sw.WriteLine(counter);
            sw.Close();

            await ReplyAsync($"The **look counter** is now at **{counter}**");
        }
    }
}
