using System;
using static System.Console;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("\tHey! This lesson on the concept of increment and decrement!");
            int x = 14;
            int y = 1;
            int z = 5;
            string[] numbers = {"First formula:","Second formula:","Third formula:",
                                "Fourth formela:","Fifth formula:"};
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"Initial value of variables: x = {x}, y = {y}, z = {z};");
            x += y - x++ * z;
            PrintFormula("x += y - x++ * z", 'x', x, 0);
            z = --x - y * 2;
            PrintFormula("z = --x – y * 2", 'z', z, 1);
            y /= x + 5 % z;
            PrintFormula("y /= x + 5 % z", 'y', y, 2);
            z = x++ + y * 5;
            PrintFormula("z = x++ + y * 5", 'z', z, 3);
            x = y - x++ * z;
            PrintFormula("x = y - x++ * z", 'x', x, 4);
            void PrintFormula(string formula, char letter, int value, int count)
            {
                ForegroundColor = ConsoleColor.DarkYellow;
                Write(numbers[count]);
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine($"\t{formula}");
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"{letter} = {value}");
                ResetColor();
            }
        }
    }
}