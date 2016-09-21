namespace TextEncryptor.Engine.Commands
{
    using System;
    using System.Text;
    using Cipher;

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

        private void EncryptString()
        {
            Console.WriteLine("Enter a password to use:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter a string to encrypt:");
            string text = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Your encrypted string is:");
            string encryptedstring = StringCipher.Encrypt(text, password);
            Console.WriteLine(encryptedstring);
            Console.WriteLine("");
        }

        private void DecryptString()
        {
            Console.WriteLine("Enter a password to use:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter a string to decrypt:");
            string text = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Your decrypted string is:");
            string decryptedstring = StringCipher.Decrypt(text, password);
            Console.WriteLine(decryptedstring);
            Console.WriteLine("");
        }

        private void EncryptTxtFile()
        {
            throw new NotImplementedException();
        }

        private void DecryptTxtFile()
        {
            throw new NotImplementedException();
        }

        private void DisplayCommands()
        {
            StringBuilder commandsDescription = new StringBuilder();

            commandsDescription.AppendLine("--------------------------------" + Environment.NewLine +
                                           "COMMANDS: " + Environment.NewLine +
                                           "encrypt string" + Environment.NewLine +
                                           "decrypt string" + Environment.NewLine +
                                           "encrypt txt file" + Environment.NewLine +
                                           "decrypt txt file" + Environment.NewLine +
                                           "--------------------------------");

            Console.Write(commandsDescription);
        }

        private void ClearConsole()
        {
            Console.Clear();
        }
    }
}
