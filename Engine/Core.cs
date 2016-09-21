using System;

namespace TextEncryptor.Engine
{
    public class Core
    {
        private static Core _instance;

        public static Core Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Core();
                }

                return _instance;
            }
        }

        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Title = "Encryptor";

            Console.WriteLine("Enter command :");
            var commandLine = Console.ReadLine();

            while (commandLine != "end")
            {
                if (!string.IsNullOrEmpty(commandLine))
                {
                    var commandParts = commandLine.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                    var command = commandParts[0];

                    CommandProcessor.Instance.ProcessCommand(command, commandParts);
                }
                else
                {
                    Console.WriteLine(@"Unknown command. Type ""help"" for a list of commands.");
                }

                Console.WriteLine("Enter command :");
                commandLine = Console.ReadLine();
            }
        }
    }
}
