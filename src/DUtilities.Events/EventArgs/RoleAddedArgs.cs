using Emzi0767.Utilities;
using DSharpPlus.Entities;

namespace DUtilities.Events
{
    public class RoleAddedArgs : AsyncEventArgs
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
        internal RoleAddedArgs(DiscordRole role, DiscordMember member, DiscordGuild guild) : base()
        {
            Role = role;
            Member = member;
            Guild = guild;
        }
    }
}