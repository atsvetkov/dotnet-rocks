using System;
using System.Collections.Generic;

namespace SurfingTheCode.DotNetRocks
{
    public static class ConsoleMenu
    {
        public static T Prompt<T>(List<T> items)
        {
            bool loopComplete = false;
            int topOffset = Console.CursorTop;
            int bottomOffset = 0;
            int selectedItem = 0;
            ConsoleKeyInfo kb;
            Console.CursorVisible = false;

            if (items.Count > Console.WindowHeight)
            {
                throw new Exception("Too many items to display");
            }

            while (!loopComplete)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (i == selectedItem)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(" - " + items[i]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine(" - " + items[i]);
                    }
                }

                bottomOffset = Console.CursorTop;

                kb = Console.ReadKey(true);

                switch (kb.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItem = selectedItem > 0 ? selectedItem - 1 : items.Count - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItem = selectedItem < items.Count - 1 ? selectedItem + 1 : 0;
                        break;
                    case ConsoleKey.Enter:
                        loopComplete = true;
                        break;
                }


                Console.SetCursorPosition(0, topOffset);
            }

            Console.SetCursorPosition(0, bottomOffset);
            Console.CursorVisible = true;

            return items[selectedItem];
        }
    }
}