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
                new List<string> {
                    "What can you tell me about this part of the world?",
                    "What do you sell?",
                    "Who is that man over there?",
                    "[End Conversation]"
                });

            if (answer.StartsWith("What can you tell me"))
            {
                answer = ShowMenu(
                    "Well, not much happens around here. We're a quiet village. We keep to ourselves. But recently strange things have been happening, things we cannot explain..",
                    new List<string> {
                        "Like what?",
                        "Is somebody investigating?",
                        "[End Conversation]"
                    });

                if (answer.StartsWith("Like what?"))
                {
                    answer = ShowMenu("Well, ...",
                        new List<string> { "[End Conversation] "});
                } else if (answer.StartsWith("Is somebody investigating?"))
                {
                    answer = ShowMenu("When we started carrying out investigations the strange activities stopped. We suspect there's an insider.",
                        new List<string> {
                            "Maybe I can help out. A new, unknown face. I'll keep a look out.",
                            "[End Conversation]"
                        });
                }

            } else if (answer.StartsWith("What do you sell"))
            {
                answer = ShowMenu(
                    "I sell trinkets, odds and ends and adventuring equipment.",
                    new List<string> {
                        "Show me your wares.",
                        "[End Conversation]"});
            }
            else if (answer.StartsWith("Who is that man"))
            {
                answer = ShowMenu(
                    "That man goes by the name of Strider. He's a ranger. Legends say he was descended from the ancient kings of men.",
                    new List<string> {
                        "Wow.. What is he doing here then?",
                        "[End Conversation]"
                    });
            }

            Console.WriteLine($"You chose: {answer}");

            string ShowMenu(string prompt, List<string> options)
            {
                int selectedMenuItem = 0;

                Console.Clear();
                Console.WriteLine(prompt);

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
    }
}
