using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Threading.Tasks;

namespace Project_Hayase.commands.about
{
    internal class aboutMeEmbed
    {
        public DiscordEmbed HEmbed(InteractionContext ctx)
        {
            var embed = new DiscordEmbedBuilder
            {
                Description = (
                    "a"
                )
            };
            return embed;
        }
    }


    internal class SLASHaboutMeCommand : ApplicationCommandModule
    {
        [SlashCommand("aboutme", "🪴 | Things about you.")]
        public async Task SaboutR(InteractionContext ctx)
        {
            var he = new aboutMeEmbed();
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent("Bip bup bip! Here things about you:")
                .AddEmbed(he.HEmbed(ctx))
                );
        }
    }
}
