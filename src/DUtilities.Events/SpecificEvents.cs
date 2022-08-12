using System;
using DSharpPlus;
using DUtilities.Events;
using Emzi0767.Utilities;
using DSharpPlus.EventArgs;

namespace DUtilities.Events
{
    public static class SpecificEvents
    {
        private static AsyncEvent<object, MemberRoleAddedArgs> _MemberRoleAdded;
        public static event AsyncEventHandler<object, MemberRoleAddedArgs> MemberRoleAdded
        {
            add => _MemberRoleAdded.Register(value);
            remove => _MemberRoleAdded.Unregister(value);
        }
        private static AsyncEvent<object, MemberRoleRemovedArgs> _MemberRoleRemoved;
        public static event AsyncEventHandler<object, MemberRoleRemovedArgs> MemberRoleRemoved
        {
            add => _MemberRoleRemoved.Register(value);
            remove => _MemberRoleRemoved.Unregister(value);
        }
        private static AsyncEvent<object, MemberNicknameUpdatedArgs> _MemberNicknameUpdated;
        public static event AsyncEventHandler<object, MemberNicknameUpdatedArgs> MemberNicknameUpdated
        {
            add => _MemberNicknameUpdated.Register(value);
            remove => _MemberNicknameUpdated.Unregister(value);
        }

        public static void UseSpecificEvents(this DiscordClient client)
        {
            client.GuildMemberUpdated += GuildMemberUpdated;
        }
        private static async Task GuildMemberUpdated(DiscordClient client, GuildMemberUpdateEventArgs args)
        {
            if (args.RolesAfter != args.RolesBefore)
            {
                if (args.RolesAfter.Count > args.RolesBefore.Count)
                {
                    await _MemberRoleAdded.InvokeAsync(new Object(), new MemberRoleAddedArgs(args.GetChangedRole(), args.Member, args.Guild));
                }
                else
                {
                    await _MemberRoleRemoved.InvokeAsync(new Object(), new MemberRoleRemovedArgs(args.GetChangedRole(), args.Member, args.Guild));
                }
                return;
            }
        }
    }
}