using System;
using System.Collections.Generic;
using Cosmos.System;
using Console = System.Console;

namespace ZeroOS_Horizon
{
    public class CommandProcessor
    {
        private List<string> history;
        private FileHandler fileHandler; // Create an instance of FileHandler

        public CommandProcessor(List<string> history)
        {
            this.history = history;
            this.fileHandler = new FileHandler(); // Instantiate FileHandler
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
                    Console.WriteLine("create [filename] [content] - Create a new file with the specified content.");
                    Console.WriteLine("edit [filename] [content] - Edit an existing file's content.");
                    Console.WriteLine("delete [filename] - Delete a file.");
                    Console.WriteLine("list - List all files.");
                    Console.WriteLine("read [filename] - Read the contents of a file.");
                    Console.WriteLine("shutdown - Shutdown the system.");
                    Console.WriteLine("restart - Restart the system.");
                    Console.WriteLine("date - Display the current date.");
                    Console.WriteLine("time - Display the current time.");
                    Console.WriteLine("clear - Clear the screen.");

                    break;

                case "history":
                    Console.WriteLine("Command history:");
                    for (int i = 0; i < history.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}: {history[i]}");
                    }
                    break;

                case "create":
                    if (parts.Length > 2)
                    {
                        string fileName = parts[1];
                        string content = string.Join(" ", parts, 2, parts.Length - 2);
                        fileHandler.CreateFile(fileName, content);
                        Console.WriteLine($"File '{fileName}' created.");
                    }
                    else
                    {
                        Console.WriteLine("Usage: create [filename] [content]");
                    }
                    break;

                case "edit":
                    if (parts.Length > 2)
                    {
                        string fileName = parts[1];
                        string content = string.Join(" ", parts, 2, parts.Length - 2);
                        fileHandler.EditFile(fileName, content);
                        Console.WriteLine($"File '{fileName}' edited.");
                    }
                    else
                    {
                        Console.WriteLine("Usage: edit [filename] [content]");
                    }
                    break;

                case "delete":
                    if (parts.Length > 1)
                    {
                        string fileName = parts[1];
                        fileHandler.DeleteFile(fileName);
                        Console.WriteLine($"File '{fileName}' deleted.");
                    }
                    else
                    {
                        Console.WriteLine("Usage: delete [filename]");
                    }
                    break;

                case "list":
                    fileHandler.ListFiles();
                    break;

                case "read":
                    if (parts.Length > 1)
                    {
                        string fileName = parts[1];
                        string content = fileHandler.ReadFile(fileName);
                        if (content != null)
                        {
                            Console.WriteLine($"Contents of '{fileName}':");
                            Console.WriteLine(content);
                        }
                        else
                        {
                            Console.WriteLine($"File '{fileName}' not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usage: read [filename]");
                    }
                    break;


                case "about":
                    Console.WriteLine("ZeroOS-Horizon");
                    Console.WriteLine("Developed by JKaliraj");
                    Console.WriteLine("GitHub Repository: https://github.com/JKaliraj/ZeroOS-Horizon");
                    break;

                case "date":
                    Console.WriteLine("Current date: " + DateTime.Now.ToShortDateString());
                    break;

                case "time":
                    Console.WriteLine("Current time: " + DateTime.Now.ToLongTimeString());
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "shutdown":
                    Console.WriteLine("Shutting down the system...");
                    Power.Shutdown();
                    break;

                case "restart":
                    Console.WriteLine("Restarting the system...");
                    Power.Reboot();
                    break;

                default:
                    Console.WriteLine("Unknown command. Type 'help' for a list of available commands.");
                    break;
            }
        }
    }
}
