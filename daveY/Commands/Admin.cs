using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace daveY.Commands
{
    public class Admin : BaseCommandModule
    {
        [Command("ban")]
        [RequireRoles(RoleCheckMode.All, "Owner")]
        public async Task ban(CommandContext ctx, DiscordMember user, string reason)
        {
            await user.BanAsync(1, reason);
            await ctx.Channel.SendMessageAsync(reason);
            
        }

        [Command("unban")]
        [RequireRoles(RoleCheckMode.All, "Owner")]
        public async Task unban(CommandContext ctx, DiscordMember user)
        {
            await user.UnbanAsync("He's a good boi now!");
            await ctx.Channel.SendMessageAsync("Welcome back, "+user+"!");
        }

        [Command("mute")]
        [RequireRoles(RoleCheckMode.All, "Owner")]
        public async Task mute(CommandContext ctx, DiscordMember user, string reason)
        {
            await ctx.Channel.SendMessageAsync("The user " + user.ToString() + "Has been muted because " + reason);
            await user.SetMuteAsync(true, reason);
        }

    }
}
