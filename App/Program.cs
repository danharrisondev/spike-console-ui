﻿using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();

            int selectedMenuItem = 1;

            Console.WriteLine("Here is some text. Choose an option");

            int cursorX, cursorY;
            cursorX = Console.CursorLeft;
            cursorY = Console.CursorTop;

            if (selectedMenuItem == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 1");
            Console.ResetColor();

            if (selectedMenuItem == 2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 2");
            Console.ResetColor();
            
            if (selectedMenuItem == 3)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 3");
            Console.ResetColor();

            var key = Console.ReadKey();

            if (key.Key == System.ConsoleKey.DownArrow)
            {
                selectedMenuItem++;
            }

            Console.SetCursorPosition(cursorX, cursorY);

            if (selectedMenuItem == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 1");
            Console.ResetColor();

            if (selectedMenuItem == 2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 2");
            Console.ResetColor();
            
            if (selectedMenuItem == 3)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 3");
            Console.ResetColor();

            key = Console.ReadKey();

            if (key.Key == System.ConsoleKey.DownArrow)
            {
                selectedMenuItem++;
            }

            Console.SetCursorPosition(cursorX, cursorY);

            if (selectedMenuItem == 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 1");
            Console.ResetColor();

            if (selectedMenuItem == 2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 2");
            Console.ResetColor();
            
            if (selectedMenuItem == 3)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Option 3");
            Console.ResetColor();
        }
    }
}