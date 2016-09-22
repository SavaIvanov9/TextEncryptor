using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            List<List<string>> text = new List<List<string>>();

            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    text.Add(new List<string>(line.Split(' ')).Select(
                        t => StringCipher.Encrypt(t, password)).ToList());
                    
                    line = reader.ReadLine();
                }
            }

            

            CheckDirectory("EncryptedFiles");
            DirectoryInfo dir = new DirectoryInfo(".");
            String dirName = dir.FullName;
            string newFilePath = Path.Combine(dirName, "EncryptedFiles");
            string newFileName = "";

            if (path.Contains(@"\"))
            {
                newFileName = path.Substring(path.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
            }
            else
            {
                newFileName = path;
            }
            
            if (!CheckFile(newFilePath, newFileName))
            {
                using (StreamWriter file = File.CreateText(Path.Combine(newFilePath, newFileName)))
                {
                    for (int i = 0; i < text.Count; i++)
                    {
                        file.WriteLine(string.Join(" ", text[i]));
                    }

                    Console.WriteLine($"File {newFileName} encrypted.");
                }
            }
            else
            {
                Console.WriteLine("file alredy exists");
            }
        }

        private void CheckDirectory(string name)
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            String dirName = dir.FullName;
            string pathString = System.IO.Path.Combine(dirName, name);

            if (!Directory.Exists(pathString))
            {
                Directory.CreateDirectory(pathString);
            }
        }

        private bool CheckFile(string directory, string file)
        {
            string[] filePaths = Directory.GetFiles(directory, "*.txt");
            string[] fileNames = filePaths.Select(x => x.Substring(x.LastIndexOf(@"\", StringComparison.Ordinal) + 1)).ToArray();

            return fileNames.Contains(file);
        }

        private char[,] ReadMap(string path)
        {
            StreamReader reader = new StreamReader(path);

            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();

                int cols = line.Length;

                List<string> elements = new List<string>();

                while (line != null)
                {
                    elements.Add(line);
                    lineNumber++;
                    line = reader.ReadLine();
                }

                int rows = lineNumber;
                char[,] mapMatrix = new char[rows, cols];

                int counterRows = 0;
                int counterCols = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (counterCols == cols)
                            counterCols = 0;

                        mapMatrix[row, col] = elements[counterRows][counterCols];
                        counterCols++;
                    }
                    counterRows++;
                }
                return mapMatrix;
            }

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
