using DSharpPlus;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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