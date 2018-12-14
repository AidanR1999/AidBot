using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Audio.Streams;
using Discord.Commands;

namespace AidBot.Commands
{
    public class Timetable : ModuleBase<SocketCommandContext>
    {
        private string[,] _time = new string[,]
        {
            {"#", "#", "#"},
            {"Database - 06.087", "Multiplatform - 05.50", "#"},
            {"#", "#", "#"},
            {"OOProgramming - 05.50", "Data Structures - 06.79", "Guidance - 05.39"},
            {"OOAnalysis - 04.52", "#", "#"}
        };

        private string[] _days = new string[]
        {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"
        };

        [Command("timetable")]
        async Task TimetableAsync()
        {
            string output = "Timetable : \n";

            for (int i = 0; i < 5; i++)
            {
                if (i != 0)
                {
                    output += " \n ";
                }
                output += _days[i];
                for (int j = 0; j < 3; j++)
                {
                    output += " " + _time[i, j] + " ";
                }
            }

            await ReplyAsync(output);
        }
    }
}
