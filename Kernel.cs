using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace ZeroOS_Horizon
{
    public class Kernel : Sys.Kernel
    {
        private List<string> history = new List<string>();
        private CommandProcessor commandProcessor;

        protected override void BeforeRun()
        {
            Console.Clear();  // Clear the console
            Console.BackgroundColor = ConsoleColor.DarkMagenta; // Set background color to Dark Magenta
            Console.ForegroundColor = ConsoleColor.White; // Set text color to White
            int screenWidth = Console.WindowWidth;

            string welcomeMessage = "Welcome to ZeroOS-Horizon";
            int padding = (screenWidth - welcomeMessage.Length) / 2;

            Console.WriteLine(new string('*', screenWidth - 1)); // Fill the line with '*' characters
            Console.WriteLine("*" + new string(' ', padding - 1) + welcomeMessage + new string(' ', padding - 1) + "*");
            Console.WriteLine(new string('*', screenWidth - 1)); // Fill the line with '*' characters

            Console.ResetColor(); // Reset colors to default

            commandProcessor = new CommandProcessor(history);
        }

        protected override void Run()
        {
            Console.Write(">>> ");
            var input = Console.ReadLine();
            commandProcessor.ProcessCommand(input);
        }
    }
}
