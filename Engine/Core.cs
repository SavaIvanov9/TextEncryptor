using System.IO;

namespace TextEncryptor.Engine
{
    using System;
    using Commands;

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

            Console.WriteLine("Enter command:");
            var command = Console.ReadLine();

            while (command != "end")
            {
                if (!string.IsNullOrEmpty(command))
                {
                    try
                    {
                        CommandProcessor.Instance.ProcessCommand(command);
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("File not found.");
                    }
                }
                else
                {
                    Console.WriteLine(@"Unknown command. Type ""help"" for a list of commands.");
                }

                Console.WriteLine("Enter command:");
                command= Console.ReadLine();
            }
        }
    }
}
