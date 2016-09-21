using System;

namespace TextEncryptor.Engine.Commands
{
    public class CommandProcessor
    {
        private static CommandProcessor _instance;

        public static CommandProcessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommandProcessor();
                }

                return _instance;
            }
        }

        public void ProcessCommand(string command, string[] commandParams)
        {
            switch (command)
            {
                case Constants.Help:
                    this.DisplayCommands();
                    break;
                case Constants.EncryptString:
                    this.EncryptString();
                    break;
                case Constants.DecryptStryng:
                    this.DecryptString();
                    break;
                case Constants.EncryptTxtFile:
                    this.EncryptTxtFile();
                    break;
                case Constants.DecryptTxtFile:
                    this.DecryptTxtFile();
                    break;
                case Constants.ClearConsole:
                    this.ClearConsole();
                    break;
                default:
                    Console.WriteLine(@"Unknown command. Type ""help"" for a list of commands.");
                    break;
            }
        }

        private void ClearConsole()
        {
            throw new NotImplementedException();
        }

        private void DecryptTxtFile()
        {
            throw new NotImplementedException();
        }

        private void EncryptTxtFile()
        {
            throw new NotImplementedException();
        }

        private void DecryptString()
        {
            throw new NotImplementedException();
        }

        private void EncryptString()
        {
            throw new NotImplementedException();
        }

        private void DisplayCommands()
        {
            throw new NotImplementedException();
        }
    }
}
