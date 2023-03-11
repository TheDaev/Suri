using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dav;

namespace daveY.Commands
{
    public class FunCommands : BaseCommandModule
    {
        

        [Command("spam")]
        public async Task TestCommand(CommandContext ctx, string whattospam, int howmanytime)
        {
            for(int i = 0; i < howmanytime; i++)
            {
                await ctx.Channel.SendMessageAsync(whattospam);
            }

            
        }

        [Command("snake")]
        [RequireRoles(RoleCheckMode.All, "Gamer")]
        public async Task snake(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Not done yet!");
        }

        [Command("test")]
        [RequireRoles(RoleCheckMode.All, "Owner")]
        public async Task test(CommandContext ctx)
        {
            string input = File.ReadAllText(@"E:\DaveY\message.txt");
            var guild = await ctx.Client.GetChannelAsync(1084077489661431839);
            var message = await guild.SendMessageAsync(input);
        }     



    }
}
