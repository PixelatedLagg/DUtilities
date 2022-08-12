using DSharpPlus;
using DSharpPlus.Entities;

namespace DUtilities
{
    public static class GuildExtensions
    {
        public static async Task<IEnumerable<DiscordMember>> GetMembersByRoleAsync(this DiscordGuild guild, DiscordRole role)
        {
            return (await guild.GetAllMembersAsync()).Where(x => x.Roles.Contains(guild.GetRole(role.Id)));
        }
    }
}