using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace App
{
    class DialogJson
    {
        public SpeakerNode Dialog { get; set; }
    }

    class SpeakerNode
    {
        public string SpeakerText { get; set; }
        public List<Response> Responses { get; set; }
    }

    class Response
    {
        public SpeakerNode Next { get; set; }
        public string ResponseText { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();

            int cursorX, cursorY;
            cursorX = Console.CursorLeft;
            cursorY = Console.CursorTop;

            var dialog = System.Text.Json.JsonSerializer.Deserialize<DialogJson>(
                Encoding.ASCII.GetBytes(File.ReadAllText("./SampleDialog.json")))
                .Dialog;

            bool endOfConversation = false;
            while(!endOfConversation)
            {
                var answer = ShowMenu(dialog.SpeakerText,
                    dialog.Responses.Select(x => x.ResponseText).ToList());

                if (answer == DialogOptions.EndConversationToken)
                {
                    endOfConversation = true;
                    break;
                }
                
                dialog = dialog.Responses.Single(x => x.ResponseText == answer).Next;
                if (dialog == null)
                {
                    throw new NullReferenceException("Conversation terminated prematurely. No continuation found.");
                }
            }

            string ShowMenu(string prompt, List<string> options)
            {
                int selectedMenuItem = 0;

                Console.Clear();
                Console.WriteLine($"> {prompt}");

                while(true)
                {
                    ShowMenuItems(options);

                    var key = Console.ReadKey();

                    if (key.Key == System.ConsoleKey.DownArrow
                        && selectedMenuItem < options.Count - 1)
                    {
                        selectedMenuItem++;
                    }

                    if (key.Key == System.ConsoleKey.UpArrow
                        && selectedMenuItem > 0)
                    {
                        selectedMenuItem--;
                    }

                    if (key.Key == System.ConsoleKey.Enter)
                    {
                        return options[selectedMenuItem];
                    }
                }

                void ShowMenuItems(List<string> options)
                {
                    Console.SetCursorPosition(cursorX, cursorY);

                    for(int i = 0; i < options.Count; i++)
                    {
                        if (i == selectedMenuItem)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.WriteLine(options[i]);
                        Console.ResetColor();
                    }
                }
            }
        }

        public sealed class DialogOptions
        {
            public const string EndConversationToken = "[End Conversation]";

            public static List<string> List(params string[] options)
            {
                var list = new List<string>();
                if (options.Length > 0)
                    list.AddRange(options);
                list.Add(EndConversationToken);
                return list;
            }

            public static List<string> None()
            {
                return new List<string> { EndConversationToken };
            }
        }
    }
}
