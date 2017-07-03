﻿using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using PassiveBOT.Configuration;

namespace PassiveBOT.Commands
{
    [RequireUserPermission(GuildPermission.Administrator)]
    [RequireContext(ContextType.Guild)]
    public class GuildSetup : ModuleBase
    {
        [Command("Setup")]
        [Summary("Setup")]
        [Remarks("Initialises the servers configuration file")]
        public async Task Setup()
        {
            GuildConfig.Setup(Context.Guild.Id, Context.Guild.Name);
            await ReplyAsync(GuildConfig.Read(Context.Guild.Id));
        }

        [Command("Config")]
        [Summary("Config")]
        [Remarks("Shows the servers current configuration")]
        public async Task Config()
        {
            await ReplyAsync(GuildConfig.Read(Context.Guild.Id));
        }

        [Command("Welcome")]
        [Summary("Welcome <message>")]
        [Remarks("Sets the welcome message for new users in the server")]
        public async Task Welcome([Remainder] string message)
        {
            GuildConfig.SetWMessage(Context.Guild.Id, message);
            await ReplyAsync("The Welcome Message for this server has been set to:\n" +
                             $"**{message}**");
        }

        [Command("WelcomeChannel")]
        [Alias("wc")]
        [Summary("wc")]
        [Remarks("Sets the current channel as the welcome channel")]
        public async Task Wchannel()
        {
            GuildConfig.SetWChannel(Context.Guild.Id, Context.Channel.Id);
            await ReplyAsync("The Welcome Channel for this server has been set to:\n" +
                             $"**{Context.Channel.Name}**");
        }

        [Command("WelcomeStatus")]
        [Alias("ws")]
        [Summary("ws <true/false>")]
        [Remarks("sets the welcome message as true or false (on/off)")]
        public async Task WOff(bool status)
        {
            GuildConfig.SetWelcomeStatus(Context.Guild.Id, status);
            await ReplyAsync($"Welcome Messageing for this server has been set to: {status}");
        }

        [Command("SetDj")]
        [Summary("SetDj <@role>")]
        [Remarks("Sets the DJ role")]
        public async Task Dj([Remainder] IRole role)
        {
            GuildConfig.SetDj(Context.Guild.Id, role.Id);
            await ReplyAsync($"The DJ Role has been set to: {role.Name}");
        }

        [Command("Errors")]
        [Summary("Errors <true/false>")]
        [Remarks("Toggles Error Status")]
        public async Task Errors(bool status)
        {
            GuildConfig.SetError(Context.Guild.Id, status);
            if (status)
                await ReplyAsync("Errors will now be Logged");
            else
                await ReplyAsync("Errors will no longer be logged");
        }

    }
}