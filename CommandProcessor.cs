using System;
using System.Collections.Generic;
using Cosmos;
namespace ZeroOS_Horizon
{
    public class CommandProcessor
    {
        private List<string> history;

        public CommandProcessor(List<string> history)
        {
            this.history = history;
        }

        public void ProcessCommand(string input)
        {
            history.Add(input);

            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();

            switch (command)
            {
                case "echo":
                    if (parts.Length > 1)
                    {
                        string text = string.Join(" ", parts, 1, parts.Length - 1);
                        Console.WriteLine("Echo: " + text);
                    }
                    else
                    {
                        Console.WriteLine("Usage: echo [text]");
                    }
                    break;

                case "help":
                    Console.WriteLine("Available commands: ");
                    Console.WriteLine("echo [text] - Echo the given text.");
                    Console.WriteLine("history - Show command history.");
                    break;

                case "history":
                    Console.WriteLine("Command history:");
                    for (int i = 0; i < history.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {history[i]}");
                    }
                    break;
                case "shutdown":
                    Console.WriteLine("Shutting down the system...");
                    Cosmos.System.Power.Shutdown();
                    break;

                case "restart":
                    Console.WriteLine("Restarting the system...");
                    Cosmos.System.Power.Shutdown();
                    break;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for a list of available commands.");
                    break;
            }
        }
    }
}
