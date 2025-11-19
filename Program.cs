using System;
using System.Net.Http.Headers;
using TagLib;
using System.IO;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CommandEntry> commandsToExecute = getCommandsToExecute(args);
            executeCommands(commandsToExecute);
        }

        private static void executeCommands(List<CommandEntry> commandsToExecute)
        {
            string[] fileNames = Directory.GetFiles(".", "*.mp3");
            foreach (string fileName in fileNames)
            {
                Console.WriteLine($"editing file {fileName}");
                
                foreach (CommandEntry command in commandsToExecute)
                {
                    Globals.commandsMap[command.name](fileName, command.arguments);
                }
            }
        }

        private static List<CommandEntry> getCommandsToExecute(string[] args)
        {
            
            List<CommandEntry> commandsToExecute = new ();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i][0] == '-')
                {
                    string command = args[i].Substring(1);
                    if (!Globals.commandsMap.ContainsKey(command))
                    {
                        Console.WriteLine($"error: unknown command: {command}");
                        Environment.Exit(1);
                    }
                    commandsToExecute.Add(new CommandEntry(command, new List<string> {}));
                } 
                else
                {
                    commandsToExecute[commandsToExecute.Count - 1].arguments.Add(args[i]); 
                }
            }
            return commandsToExecute;
        }

        public static void printCommands(List<CommandEntry> commands)
        {
            Console.WriteLine("Commands to execute:");

            foreach (var cmd in commands)
            {
                Console.Write($"- {cmd.name}");

                if (cmd.arguments.Count > 0)
                {
                    Console.Write(": ");
                    Console.WriteLine(string.Join(", ", cmd.arguments));
                }
                else
                {
                    Console.WriteLine(" (no arguments)");
                }
            }
        }
    }

    public class CommandEntry
    {
        public string name { get; set; }
        public List<string> arguments { get; set; }

        public CommandEntry(string name, List<string> arguments)
        {
            this.name = name;
            this.arguments = arguments;
        }
    }

    
}