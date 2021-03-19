using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();

            int cursorX, cursorY;
            cursorX = Console.CursorLeft;
            cursorY = Console.CursorTop;

            var answer = ShowMenu("Hey, what can I do for you?",
                DialogOptions.List(
                    "What can you tell me about this part of the world?",
                    "What do you sell?",
                    "Who is that man over there?"
                ));

            if (answer.StartsWith("What can you tell me"))
            {
                answer = ShowMenu(
                    "Well, not much happens around here. We're a quiet village. We keep to ourselves. But recently strange things have been happening, things we cannot explain..",
                    DialogOptions.List(
                        "Like what?",
                        "Is somebody investigating?"
                    ));

                if (answer.StartsWith("Like what?"))
                {
                    answer = ShowMenu("Well, ...", DialogOptions.None());
                } else if (answer.StartsWith("Is somebody investigating?"))
                {
                    answer = ShowMenu("When we started carrying out investigations the strange activities stopped. We suspect there's an insider.",
                        DialogOptions.List(
                            "Maybe I can help out. A new, unknown face. I'll keep a look out."
                        ));
                }

            } else if (answer.StartsWith("What do you sell"))
            {
                answer = ShowMenu(
                    "I sell trinkets, odds and ends and adventuring equipment.",
                    DialogOptions.List(
                        "Show me your wares."
                    ));
            }
            else if (answer.StartsWith("Who is that man"))
            {
                answer = ShowMenu(
                    "That man goes by the name of Strider. He's a ranger. Legends say he was descended from the ancient kings of men.",
                    DialogOptions.List(
                        "Wow.. What is he doing here then?"
                    ));
            }

            Console.WriteLine($"You chose: {answer}");

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
                            Console.BackgroundColor = ConsoleColor.Red;
                        }

                        Console.WriteLine(options[i]);
                        Console.ResetColor();
                    }
                }
            }
        }

        public sealed class DialogOptions
        {
            public static List<string> List(params string[] options)
            {
                var list = new List<string>();
                if (options.Length > 0)
                    list.AddRange(options);
                list.Add("[End Conversation]");
                return list;
            }

            public static List<string> None()
            {
                return new List<string> { "[End Conversation]" };
            }
        }
    }
}
