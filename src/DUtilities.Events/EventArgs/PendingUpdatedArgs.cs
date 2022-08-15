using Emzi0767.Utilities;
using DSharpPlus.Entities;

namespace DUtilities.Events
{
    public class PendingUpdatedArgs : AsyncEventArgs
    {
        public bool PassedScreening
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
        internal PendingUpdatedArgs(bool passedScreening, DiscordMember member, DiscordGuild guild) : base()
        {
            PassedScreening = passedScreening;
            Member = member;
            Guild = guild;
        }
    }
}