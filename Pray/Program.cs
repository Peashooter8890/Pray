using System;
using System.Collections.Generic;
using System.Text;

namespace Pray
{
    class Program
    {
        static Dictionary<string, string> commandMappings = new Dictionary<string, string>
        {
            { "/pray", "We pray." },
            { "/thanks", "We thank God for His blessings." },   
            { "/help", "Available commands: /pray, /thanks, /help, /clear" },
            { "/clear", "" } // Special command for clearing the screen
        };

        static string defaultCommandMessage = "We process this request and forward it appropriately.";
        static string standardPrayerMessage = "We now request that the Holy Spirit receives such a prayer and communicates it to God for us, if the prayer is appropriate. We also request, regardless of the contents of the prayer, that God's will is prioritized.";

        static void Main(string[] args)
        {
            Console.Title = "Pray";
            Console.Clear();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("> ");
                string input = ReadLineWithCtrlL();

                if (input.ToLower() == "exit" || input.ToLower() == "quit")
                {
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;

                if (input.StartsWith("/"))
                {
                    string command = input.Split(' ')[0].ToLower();

                    if (command == "/clear")
                    {
                        Console.Clear();
                        continue;
                    }

                    if (commandMappings.ContainsKey(command))
                    {
                        Console.WriteLine(commandMappings[command]);
                    }
                    else
                    {
                        Console.WriteLine(defaultCommandMessage);
                    }
                }
                else
                {
                    Console.WriteLine(standardPrayerMessage);
                }
            }
        }

        static string ReadLineWithCtrlL()
        {
            StringBuilder input = new StringBuilder();
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.L && key.Modifiers == ConsoleModifiers.Control)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("> ");
                    input.Clear();
                    continue;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return input.ToString();
                }

                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.Write("\b \b");
                    continue;
                }

                if (!char.IsControl(key.KeyChar))
                {
                    input.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
        }
    }
}