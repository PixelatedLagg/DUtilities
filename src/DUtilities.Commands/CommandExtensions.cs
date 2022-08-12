using DSharpPlus.CommandsNext;

namespace DUtilities.Commands
{
    public static class CommandExtensions
    {
        public static void UnregisterCommands<T>(this CommandsNextExtension commands) where T : BaseCommandModule
        {
            foreach (Command command in commands.RegisteredCommands.Values)
            {
                if (command.Module?.ModuleType == typeof(T))
                {
                    commands.UnregisterCommands(command);
                }
            }
        }
    }
}