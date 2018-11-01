using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace AidBot.Commands
{
    public class BasicPhotoReplies : ModuleBase<SocketCommandContext>
    {

        /*
         * This class is only for photo replies
         */



        //Look command
        [Command("look")]
        public async Task LookAsync()
        {
            await Context.Channel.SendFileAsync(@"D:\core\AidBot\AidBot\Resources\board.jpg", "", false, null);
        }

        //Troll command
        [Command("troll")]
        public async Task TrollAsync()
        {
            await Context.Channel.SendFileAsync(@"D:\C# Projects\AidBot\AidBot\Resources/troll.jpg", "", false, null);
        }


    }
}
