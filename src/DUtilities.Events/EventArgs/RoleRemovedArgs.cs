using Emzi0767.Utilities;
using DSharpPlus.Entities;

namespace DUtilities.Events
{
    public class RoleRemovedArgs : AsyncEventArgs
    {
        public DiscordRole Role
        {
            get;
            internal set;
        }
        public DiscordMember Member
        {
            get;
            internal set;
        }
        public DiscordGuild Guild
        {
            get;
            internal set;
        }
        internal RoleRemovedArgs(DiscordRole role, DiscordMember member, DiscordGuild guild) : base()
        {
            Role = role;
            Member = member;
            Guild = guild;
        }
    }
}