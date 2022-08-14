using Emzi0767.Utilities;
using DSharpPlus.Entities;

namespace DUtilities.Events
{
    public class CommunicationDisabledArgs : AsyncEventArgs
    {
        public string NewNickname
        {
            get;
            internal set;
        }
        public string OldNickname
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
        internal CommunicationDisabledArgs(string newNickname, string oldNickname, DiscordMember member, DiscordGuild guild) : base()
        {
            NewNickname = newNickname;
            OldNickname = oldNickname;
            Member = member;
            Guild = guild;
        }
    }
}