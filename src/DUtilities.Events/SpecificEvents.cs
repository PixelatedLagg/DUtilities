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
        private static AsyncEvent<DiscordClient, RoleAddedArgs> _MemberRoleAdded = new AsyncEvent<DiscordClient, RoleAddedArgs>("MEMBER_ROLE_ADDED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, RoleAddedArgs> MemberRoleAdded
        {
            add => _MemberRoleAdded.Register(value);
            remove => _MemberRoleAdded.Unregister(value);
        }
        private static AsyncEvent<DiscordClient, RoleRemovedArgs> _MemberRoleRemoved = new AsyncEvent<DiscordClient, RoleRemovedArgs>("MEMBER_ROLE_REMOVED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, RoleRemovedArgs> MemberRoleRemoved
        {
            add => _MemberRoleRemoved.Register(value);
            remove => _MemberRoleRemoved.Unregister(value);
        }
        private static AsyncEvent<DiscordClient, NicknameUpdatedArgs> _MemberNicknameUpdated = new AsyncEvent<DiscordClient, NicknameUpdatedArgs>("MEMBER_NICKNAME_UPDATED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, NicknameUpdatedArgs> MemberNicknameUpdated
        {
            add => _MemberNicknameUpdated.Register(value);
            remove => _MemberNicknameUpdated.Unregister(value);
        }
        private static AsyncEvent<DiscordClient, AvatarHashUpdatedArgs> _MemberAvatarHashUpdated = new AsyncEvent<DiscordClient, AvatarHashUpdatedArgs>("MEMBER_AVATAR_HASH_UPDATED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, AvatarHashUpdatedArgs> MemberAvatarHashUpdated
        {
            add => _MemberAvatarHashUpdated.Register(value);
            remove => _MemberAvatarHashUpdated.Unregister(value);
        }
        private static AsyncEvent<DiscordClient, PendingUpdatedArgs> _MemberPendingUpdated = new AsyncEvent<DiscordClient, PendingUpdatedArgs>("MEMBER_PENDING_UPDATED", Limit, SpecificEventErrorHandler);
        public static event AsyncEventHandler<DiscordClient, PendingUpdatedArgs> MemberPendingUpdated
        {
            add => _MemberPendingUpdated.Register(value);
            remove => _MemberPendingUpdated.Unregister(value);
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
                await _MemberRoleAdded.InvokeAsync(client, new RoleAddedArgs(args.GetChangedRole(), args.Member, args.Guild));
                return;
            }
            if (args.RolesAfter.Count < args.RolesBefore.Count)
            {
                await _MemberRoleRemoved.InvokeAsync(client, new RoleRemovedArgs(args.GetChangedRole(), args.Member, args.Guild));
                return;
            }
            if (args.NicknameAfter != args.NicknameBefore)
            {
                await _MemberNicknameUpdated.InvokeAsync(client, new NicknameUpdatedArgs(args.NicknameAfter, args.NicknameBefore, args.Member, args.Guild));
                return;
            }
            if (args.AvatarHashAfter != args.AvatarHashBefore)
            {
                await _MemberAvatarHashUpdated.InvokeAsync(client, new AvatarHashUpdatedArgs(args.AvatarHashAfter, args.AvatarHashBefore, args.Member, args.Guild));
                return;
            }
            if (args.PendingAfter != args.PendingBefore)
            {
                await _MemberPendingUpdated.InvokeAsync(client, new PendingUpdatedArgs(args.PendingAfter ?? false, args.Member, args.Guild));
                return;
            }
        }
    }
}