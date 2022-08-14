using Emzi0767.Utilities;
using DSharpPlus.Entities;

namespace DUtilities.Events
{
    public class AvatarHashUpdatedArgs : AsyncEventArgs
    {
        public string NewAvatarHash
        {
            get;
            internal set;
        }
        public string OldAvatarHash
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
        internal AvatarHashUpdatedArgs(string nowAvatarHash, string oldAvatarHash, DiscordMember member, DiscordGuild guild) : base()
        {
            NewAvatarHash = nowAvatarHash;
            OldAvatarHash = oldAvatarHash;
            Member = member;
            Guild = guild;
        }
    }
}