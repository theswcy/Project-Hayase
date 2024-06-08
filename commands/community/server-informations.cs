using DSharpPlus.SlashCommands;
using DSharpPlus.Entities;
using System.Threading.Tasks;
using DSharpPlus;
using System;

namespace Project_Hayase.commands
{
    internal class SIEmbed
    {
        public DiscordEmbed HEmbed(InteractionContext ctx)
        {
            var embed = new DiscordEmbedBuilder();
            try
            {
                var guild = ctx.Guild;
                int boost = guild.PremiumSubscriptionCount.Value;
                int emoji = 0;
                int stik = 0;


                if (boost < 2) // Non Level.
                {
                    boost = 2;
                    emoji = 50;
                    stik = 5;
                }
                else if (boost >= 2) // Level 1.
                {
                    boost = 7;
                    emoji = 100;
                    stik = 15;
                }
                else if (boost >= 7) // Level 2.
                {
                    boost = 14;
                    emoji = 150;
                    stik = 30;
                }
                else if (boost >= 14) // Level 3.
                {
                    boost = 14;
                    emoji = 250;
                    stik = 60;
                }


                embed = new DiscordEmbedBuilder
                {
                    Description = (
                        $"## {ctx.Guild.Name}"
                    ),
                    Color = new DiscordColor("#7e67ff")
                };
                if (guild.IconUrl != null)
                {
                    embed.WithThumbnail(guild.IconUrl);
                }


                embed.AddField(
                    "<:rezet_globo:1147178426927681646> Stats:",
                    $"> Boosts: **{guild.PremiumSubscriptionCount}** / **{boost}**." +
                    $"\n> Roles: **{guild.Roles.Count}** / **200**." +
                    $"\n> Emojis: **{guild.Emojis.Count}** / **{emoji}**." +
                    $"\n> Stickers: **{guild.Stickers.Count}** / **{stik}**." +
                    $"\n> Total channels: **{guild.Channels.Count}**." +
                    $"\n> Total members: **{guild.MemberCount}** / **{guild.MaxMembers}**."
                    );



            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            return embed.Build();
        }
    }
}
