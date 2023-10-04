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
            Console.ForegroundColor = ConsoleColor.Cyan; // Set text color to Cyan
            Console.BackgroundColor = ConsoleColor.DarkBlue; // Set background color to Dark Blue

            Console.WriteLine("**************************************");
            Console.WriteLine("*     Welcome to ZeroOS-Horizon      *");
            Console.WriteLine("**************************************");

            Console.ResetColor(); // Reset colors to default

            commandProcessor = new CommandProcessor(history);
        }

        protected override void Run()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            commandProcessor.ProcessCommand(input);
        }
    }
}
