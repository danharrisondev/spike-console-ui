using System;
using System.Collections.Generic;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();

            int selectedMenuItem = 0;

            Console.WriteLine("Here is some text. Choose an option");
            var options = new List<string> {"Option 1", "Option 2", "Option 3"};

            int cursorX, cursorY;
            cursorX = Console.CursorLeft;
            cursorY = Console.CursorTop;

            ShowMenuItems(options);

            var key = Console.ReadKey();

            if (key.Key == System.ConsoleKey.DownArrow)
            {
                selectedMenuItem++;
            }

            if (key.Key == System.ConsoleKey.UpArrow)
            {
                selectedMenuItem--;
            }

            ShowMenuItems(options);

            key = Console.ReadKey();

            if (key.Key == System.ConsoleKey.DownArrow)
            {
                selectedMenuItem++;
            }
            
            if (key.Key == System.ConsoleKey.UpArrow)
            {
                selectedMenuItem--;
            }

            ShowMenuItems(options);

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
