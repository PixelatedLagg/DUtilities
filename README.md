# DUtilities
Some convenient utilities for DSharpPlus.

### Event Hooks

To setup, be sure to call `myDiscordClient.UseSpecificEvents()` in your main method. After, you should be able to use any of the events in the `SpecificEvents` class.

Example:
```cs
using DUtilities.Events;
using DSharpPlus;
using DSharpPlus.CommandsNext;

class Program
{
    public static DiscordClient discord;
    public static CommandsNextExtension commands;
    static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }
    static async Task MainAsync()
    {
        discord = new DiscordClient(new DiscordConfiguration()
        {
            Token = File.ReadAllText("token.txt"),
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.GuildMembers | DiscordIntents.GuildPresences | DiscordIntents.Guilds | DiscordIntents.GuildMessages
        });
        commands = discord.UseCommandsNext(new CommandsNextConfiguration()
        { 
            StringPrefixes = new[] { "." }
        });
        commands.RegisterCommands<Base>();
        discord.UseSpecificEvents();
        SpecificEvents.MemberNicknameUpdated += NicknameChanged;
        await discord.ConnectAsync();
        await Task.Delay(-1);
    }
    static async Task NicknameChanged(DiscordClient client, NicknameUpdatedArgs args)
    {
        Console.WriteLine(args.NewNickname);
        await Task.Delay(0);
    }
}
```
