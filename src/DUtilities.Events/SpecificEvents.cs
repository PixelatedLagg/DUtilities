using System;
using DSharpPlus;
using Emzi0767.Utilities;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace DUtilities.Events
{
    public static class SpecificEvents
    {
        private static TimeSpan Limit = TimeSpan.FromSeconds(1);
        private static AsyncEvent<DiscordClient, MemberRoleAddedArgs> _MemberRoleAdded = new AsyncEvent<DiscordClient, MemberRoleAddedArgs>("MEMBER_ROLE_ADDED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, MemberRoleAddedArgs> MemberRoleAdded
        {
            add => _MemberRoleAdded.Register(value);
            remove => _MemberRoleAdded.Unregister(value);
        }
        private static AsyncEvent<DiscordClient, MemberRoleRemovedArgs> _MemberRoleRemoved = new AsyncEvent<DiscordClient, MemberRoleRemovedArgs>("MEMBER_ROLE_REMOVED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, MemberRoleRemovedArgs> MemberRoleRemoved
        {
            add => _MemberRoleRemoved.Register(value);
            remove => _MemberRoleRemoved.Unregister(value);
        }
        private static AsyncEvent<DiscordClient, MemberNicknameUpdatedArgs> _MemberNicknameUpdated = new AsyncEvent<DiscordClient, MemberNicknameUpdatedArgs>("MEMBER_NICKNAME_UPDATED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, MemberNicknameUpdatedArgs> MemberNicknameUpdated
        {
            add => _MemberNicknameUpdated.Register(value);
            remove => _MemberNicknameUpdated.Unregister(value);
        }

        public static void UseSpecificEvents(this DiscordClient client)
        {
            client.GuildMemberUpdated += GuildMemberUpdated;
        }
        private static void SpecificEventErrorHandler<TSender, TArgs>(AsyncEvent<TSender, TArgs> asyncEvent, Exception ex, AsyncEventHandler<TSender, TArgs> handler, TSender sender, TArgs eventArgs) where TArgs : AsyncEventArgs
        {
            if (ex is AsyncEventTimeoutException)
            {
                Console.WriteLine($"An event handler for {asyncEvent.Name} took too long to execute.");
                return;
            }
            Console.WriteLine("Event handler exception thrown");
        }
        private static async Task GuildMemberUpdated(DiscordClient client, GuildMemberUpdateEventArgs args)
        {
            if (args.RolesAfter.Count > args.RolesBefore.Count)
            {
                await _MemberRoleAdded.InvokeAsync(client, new MemberRoleAddedArgs(args.GetChangedRole(), args.Member, args.Guild));
                return;
            }
            if (args.RolesAfter.Count < args.RolesBefore.Count)
            {
                await _MemberRoleRemoved.InvokeAsync(client, new MemberRoleRemovedArgs(args.GetChangedRole(), args.Member, args.Guild));
                return;
            }
            if (args.NicknameAfter != args.NicknameBefore)
            {
                await _MemberNicknameUpdated.InvokeAsync(client, new MemberNicknameUpdatedArgs(args.NicknameAfter, args.NicknameBefore, args.Member, args.Guild));
            }
        }
    }
}