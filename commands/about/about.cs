using DSharpPlus;
using DSharpPlus.SlashCommands;
using DSharpPlus.Entities;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Reflection;

namespace Project_Hayase.commands
{
    internal class aboutEmbed
    {
        public DiscordEmbed HEmbed(InteractionContext ctx)
        {
            var proc = Process.GetCurrentProcess();
            var fileInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var fileSize = fileInfo.Length / 1024.0 / 1024.0;


            var embed = new DiscordEmbedBuilder
            {
                Description = (
                    "- Heyoo, I'm **Rezet**! An application with powerful tools for your community! Operating in **slash commands** and in the future, with **native intelligence**.\n⠀"
                ),
                Color = new DiscordColor("#7e67ff")
            };


            embed.AddField(
                "⠀⠀⠀⠀<:rezet_shine:1147368423475658882> System:",
                "> My version: **Sharp 1.0**." +
                "\n> Language: **CSharp**. [ **C#** ]." +
                $"\n> Operating in: **{ctx.Client.Guilds.Count} communities**." + 
                "\n> Framework: **Microsoft .NET Framework 8.0**." +
                "\n> Next functions: **Rayquaza API**." +
                "\n⠀"
                );


            embed.AddField(
                "⠀⠀⠀⠀<:rezet_shine:1147373071737573446> Components:",
                $"> PING: **{ctx.Client.Ping}ms**." +
                $"\n> RAM: **{proc.PrivateMemorySize64 / 1024 / 1024}MB** / **8GB with 3.6Ghz**." +
                $"\n> SSD: **{fileSize:F2}** / **128GB**." +
                "\n⠀"
                );


            embed.WithImageUrl("https://media.discordapp.net/attachments/1111358828282388532/1172043117294264350/IMG_20231109_020343.png");


            return embed.Build();
        }
    }


    internal class SLASHaboutCommand : ApplicationCommandModule
    {
        [SlashCommand("about", "🪴 | Things about me.")]
        public async Task SaboutR(InteractionContext ctx)
        {
            var he = new aboutEmbed();
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent("Bip bup bip! Here things about me:")
                .AddEmbed(he.HEmbed(ctx))
                );
        }
    }
}