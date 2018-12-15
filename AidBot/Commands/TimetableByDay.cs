using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Audio.Streams;
using Discord.Commands;

namespace AidBot.Commands
{
    public class TimetableByDay : ModuleBase<SocketCommandContext>
    {

        DateTime dayValue = DateTime.Now;


        private string[,] array2Da = new string[7, 2]

        {
            // 2d array holding days and classes information
            {"Monday", "Day off"},
            {"Tuesday", "AM: Database - 06.087  PM: Multiplatform - 05.50"},
            {"Wednesday", "Day off"},
            {"Thursday", "AM: OOProgramming - 05.50  PM: Data Structures - 06.79  and Guidance - 05.39"},
            {"Friday", "OOAnalysis - 04.52"},
            {"Saturday", "It's Weekend, No Classes Today"},
            {"Sunday", "It's Weekend, No Classes Today"}
        };


        // Discrod command
        [Command("class")]
        async Task TimetableByDayAsync()
        {
            
            // get todays Day
            string day = dayValue.DayOfWeek.ToString();

            string output = "";

            // iterate and save class info to output depending on which day is it
            for (int i = 0; i < array2Da.GetLength(0); i++)
            {

                if (array2Da[i, 0] == day)
                {
                    output = array2Da[i, 1];

                }
            }

            // return appropriate class info
            await ReplyAsync(output);
        }
    }
}
