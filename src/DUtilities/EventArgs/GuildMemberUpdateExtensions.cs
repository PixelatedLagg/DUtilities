using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace DUtilities
{
    public static class GuildMemberUpdateExtensions
    {
        public static DiscordRole GetChangedRole(this GuildMemberUpdateEventArgs args)
        {
            if (args.RolesAfter.Count > args.RolesBefore.Count)
            {
                foreach (DiscordRole role in args.RolesAfter)
                {
                    if (!args.RolesBefore.Contains(role))
                    {
                        return role;
                    }
                }
            }
            else
            {
                foreach (DiscordRole role in args.RolesBefore)
                {
                    if (!args.RolesAfter.Contains(role))
                    {
                        return role;
                    }
                }
            }
            throw new Exception("No roles have changed!");
        }
        public static UpdateType GetUpdateType(this GuildMemberUpdateEventArgs args)
        {
            if (args.RolesAfter != args.RolesBefore)
            {
                return UpdateType.Roles;
            }
            if (args.NicknameAfter != args.NicknameBefore)
            {
                return UpdateType.Nickname;
            }
            if (args.AvatarHashAfter != args.AvatarHashBefore)
            {
                return UpdateType.AvatarHash;
            }
            if (args.PendingAfter != args.PendingBefore)
            {
                return UpdateType.Pending;
            }
            return UpdateType.CommunicationDisabled;
        }
    }
}