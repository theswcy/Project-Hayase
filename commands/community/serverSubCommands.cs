using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using System.Threading.Tasks;

namespace Project_Hayase.commands.community
{
    [SlashCommandGroup("server", "📘 | Informations of this server.")]
    public class server_subs : ApplicationCommandModule
    {



        [SlashCommand("informations", "📘 | Informations of this server.")]
        public async Task ServerInfoCMD(InteractionContext ctx)
        {
            var he = new SIEmbed();
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent("Bip bup bip! Coming soon...")
                );
        }



        [SlashCommand("stats", "📘 | Stats of this server.")]
        public async Task ServerStatsCMD(InteractionContext ctx)
        {
            var he = new SIEmbed();
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent("Bip bup bip! Here informations of this server:")
                .AddEmbed(he.HEmbed(ctx))
                );
        }
    }
}
