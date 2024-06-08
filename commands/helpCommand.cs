using DSharpPlus.CommandsNext;
using DSharpPlus.SlashCommands;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using DSharpPlus;

namespace Project_Hayase.commands
{
    internal class HE
    {
        public DiscordEmbed HEmbed()
        {
            var embed = new DiscordEmbedBuilder
            {
                Description = (
                    "- You can use **slash-command**: **/**\n" +
                    "\n> `help`" +
                    "\n> `about`"
                ),
                Color = new DiscordColor("#7e67ff")
            };
            return embed.Build();
        }
    }


    internal class SLASHhelpCommand : ApplicationCommandModule
    {
        [SlashCommand("commands", "🪴 | My commands list.")]
        public async Task SLASHCommandsList(InteractionContext ctx)
        {
            var he = new HE();
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent("Bip bup bip! Here is my list of commands:")
                .AddEmbed(he.HEmbed())
                );
        }
    }
}
