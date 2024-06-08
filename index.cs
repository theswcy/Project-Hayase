using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using Project_Hayase.commands;
using Project_Hayase.commands.community;
using Project_Hayase.config;
using System.Threading.Tasks;

namespace Project_Hayase
{
    internal class index
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands { get; set; }
        // private static DatabaseHandler DbHandler { get; set; }


        // MAIN:
        static async Task Main(string[] args)
        {
            var jsonreader = new JSONReader();
            await jsonreader.ReadJSON();


            // REZET SETUP:
            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = jsonreader.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
            };

            Client = new DiscordClient(discordConfig);
            Client.Ready += Client_Ready;
            // Client.GuildCreated += Client_GuildCreated;

            // DbHandler = new DatabaseHandler();


            var commandsConfig = new CommandsNextConfiguration()
            {
                EnableDms = true,
                EnableDefaultHelp = false,
            };



            // SYNC COMMANDS:
            var Slash = Client.UseSlashCommands();
            Slash.RegisterCommands<SLASHhelpCommand>();
            Slash.RegisterCommands<SLASHaboutCommand>();
            // SYNC SUB COMMANDS:
            Slash.RegisterCommands<server_subs>();


            await Client.ConnectAsync();
            await Task.Delay(-1);
        }


        // CHANGE BOT STATUS:
        private static async Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            var activity = new DiscordActivity("Heyo!", ActivityType.Playing);
            var userStatus = UserStatus.DoNotDisturb;
            await Client.UpdateStatusAsync(activity, userStatus);
        }


        // GUILD CREATE DATABASE:
        // private static async Task Client_GuildCreated(DiscordClient sender, GuildCreateEventArgs e)
        //{
        //    await DbHandler.InsertGuildData(guildId: e.Guild.Id, guildName: e.Guild.Name);
        //}
    }
}
