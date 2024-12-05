using System;
using Spectre.Console;

namespace Inlämning_3
{
    public static class ConsoleHelper
    {
        public static void Pause()
        {
            AnsiConsole.Markup("[bold green]Press any key to continue...[/]");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
