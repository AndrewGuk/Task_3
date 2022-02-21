using System;
using static System.Console;

namespace Task_3
{
    class Program
    {
        public delegate void myDeligate();
        static void Main(string[] args)
        {
            Dictionary<string, myDeligate> dic = new Dictionary<string, myDeligate>()
            {
                { "help", new myDeligate(Help) },
                { "info", new myDeligate(Info)},
                { "auto", new myDeligate(Autocomplete) },
                { "manual", new myDeligate(Manualcomplete) },
                { "exit", new myDeligate(Exit) },
            };
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine("\t\tHello! This program calculates the GCD of numbers.");
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("\tEnter \"help\" to see list of possible commands" +
                      "\n\tIf you want to end your work enter <exit>.");
            ResetColor();
            string userEnter = ReadLine().ToLower();
            ForegroundColor = ConsoleColor.Cyan;
            if (dic.ContainsKey(userEnter))
            {
                dic[userEnter]();
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("You have entered incorrect data, please read:");
                ResetColor();
                Help();
            }
            void Autocomplete()
            {
                WriteLine("\t\tAutocomplete program generates a random number of digits and calculates their GCD");
                Random random = new Random();
                int arraySize = random.Next(2, 50);
                int[] dataForGCD = new int[arraySize];
                for (int i = 0; i < dataForGCD.Length; i++)
                {
                    dataForGCD[i] = random.Next();
                }
                WriteLine("The program generated the following numbers:");
                ForegroundColor = ConsoleColor.DarkMagenta;
                for (int i = 0; i < dataForGCD.Length; i++)
                {
                    Write($"{dataForGCD[i]} | ");
                }
                int resultOfTwo = GCD(dataForGCD[0], dataForGCD[1]);
                int result = 0;
                for (int i = 1; i < dataForGCD.Length; i++)
                {
                    result = GCD(dataForGCD[i], resultOfTwo);
                }
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\nThe GCD of the above number is <{result}>");
                StartMenu();
            }
            void Manualcomplete()
            {
                WriteLine("\t\tManualcomplete program will find the GCD from the numbers you specified" +
                    "\nRemember that you can only use natural numbers (>0)");
                WriteLine("Enter the number of digits whose GCD you want to find:");
                int arraySize = Validation();
                int[] dataForGCD = new int[arraySize];
                for (int i = 0; i < dataForGCD.Length; i++)
                {
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    WriteLine($"Enter number # {i + 1}");
                    dataForGCD[i] = Validation();
                }
                int resultOfTwo = GCD(dataForGCD[0], dataForGCD[1]);
                int result = 0;
                for (int i = 1; i < dataForGCD.Length; i++)
                {
                    result = GCD(dataForGCD[i], resultOfTwo);
                }
                ForegroundColor = ConsoleColor.Green;
                WriteLine($"\nThe GCD of the above number is <{result}>");
                StartMenu();
            }
            void Info()
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Please select a language (English / Russian)" +
                          "\nYou can enter EN or RU");
                ResetColor();
                string language = ReadLine().ToLower();
                if (language == "english" || language == "en")
                    InfoEN();
                if (language == "russian" || language == "ru")
                    InfoRU();
                else
                {
                    NotCorrect();
                    Info();
                }
            }
            int Validation()
            {
                bool usEnterIsInt;
                int receivedValue;
                string usEnter;
                do
                {
                    ResetColor();
                    usEnter = ReadLine();
                    usEnterIsInt = Int32.TryParse(usEnter, out receivedValue);
                    if (!usEnterIsInt)
                    {
                        NotCorrect();
                    }
                }
                while (!usEnterIsInt);
                receivedValue = int.Parse(usEnter);
                if (receivedValue < 0)
                {
                    NotCorrect();
                    Validation();
                }
                ForegroundColor = ConsoleColor.Green;
                return receivedValue;
            }
            void NotCorrect()
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("You have entered incorrect data! try again.");
                ResetColor();
            }
            void Exit()
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Goodbye!");
                ResetColor();
            }
            void StartMenu()
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("If you want to continue, please enter \"yes\" or \"y\":");
                ResetColor();
                string answer = ReadLine().ToLower();
                if (answer == "yes" || answer == "y")
                    Main(args);
                Exit();
            }
            void InfoEN()
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("\t A common divisor of several integers is a number that can be a divisor of each number from the specified set." +
                    "\nThe greatest common divisor of two numbers a and b is the largest number by which a and b are divisible without a remainder.\nThe abbreviation GSD may be used for recording. For two numbers, you can write like this: gcd (a, b)." +
                    "\nThe greatest common divisor of three or more numbers is the largest integer that divides all those numbers at the same time.");
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\t\tEuclid's algorithm");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("\tEuclid's method helps to find GCD through successive division." +
                    "\nEuclid's algorithm is as follows: if the larger of two numbers is divisible by the smaller, the smallest number will be their greatest common divisor." +
                    "\nTo find the greatest common divisor of two numbers, follow this procedure:");
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("\t1) Divide the larger number by the smaller number;" +
                    "\n\t2) Divide the smaller number by the remainder, which is obtained after division;" +
                    "\n\t3) Divide the first remainder by the second remainder;" +
                    "\n\t4) Divide the second remainder by the third, etc.;" +
                    "\n\t5) The division continues until the remainder is zero. The last divisor is the greatest common divisor.");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("To find the greatest common divisor of three or more numbers, do the following:");
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("\t1) Find the greatest common divisor of any two numbers from the data;" +
                    "\n\t2) Find the GCD of the found divisor and the third number;" +
                    "\n\t3) Find the GCD of the last found divisor and the fourth number, etc.");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("\t\tGreatest Common Divisor Properties:");
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Black;
                PropertyColour("Property 1:");
                WriteLine(" The greatest common divisor of the numbers a and b is equal to the greatest common divisor of the numbers b and a, that is, gcd (a, b) = gcd (b, a). Changing the places of numbers does not affect the final result.");
                PropertyColour("Property 2:");
                WriteLine(" If a is divisible by b, then the set of common divisors of the numbers a and b coincides with the set of divisors of the number b, so gcd (a, b) = b.");
                PropertyColour("Property 3:");
                WriteLine(" If a = bq + c, where a, b, c and q are integers, then the set of common divisors of the numbers a and b coincides with the set of common divisors of the numbers b and c. The equality gcd (a, b) = gcd (b, c) is valid.");
                PropertyColour("Property 4:");
                WriteLine(" If m is any natural number, then gcd(ma, mb) = m * gcd(a, b).");
                PropertyColour("Property 5:");
                WriteLine(" Let p be any common divisor of numbers a and b, then gcd (a : p, b : p) = gcd (a, b) : p. Namely, if p = gcd (a, b) we have gcd (a : gcd (a, b), b : gcd (a, b)) = 1, that is, the numbers a : gcd (a, b) and b : gcd (a, b) are coprime.");
                StartMenu();
            }
            void InfoRU()
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("\t Общий делитель нескольких целых чисел — это такое число, которое может быть делителем каждого числа из указанного множества." +
                    "\nНаибольшим общим делителем двух чисел a и b называется наибольшее число, на которое a и b делятся без остатка. \nДля записи может использоваться аббревиатура НОД. Для двух чисел можно записать вот так: НОД (a, b)." +
                    "\nНаибольшим общим делителем трех чисел и более будет самое большое целое число, которое будет делить все эти числа одновременно.");
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\t\tАлгоритм Евклида");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("\tСпособ Евклида помогает найти НОД через последовательное деление." +
                    "\nАлгоритм Евклида заключается в следующем: если большее из двух чисел делится на меньшее — наименьшее число и будет их наибольшим общим делителем." +
                    "\nНахождения наибольшего общего делителя двух чисел нужно соблюдать такой порядок действий:");
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("\t1)Большее число поделить на меньшее;" +
                    "\n\t2)Меньшее число поделить на остаток, который получается после деления;" +
                    "\n\t3)Первый остаток поделить на второй остаток;" +
                    "\n\t4)Второй остаток поделить на третий и т. д;" +
                    "\n\t5)Деление продолжается до тех пор, пока в остатке не получится нуль. Последний делитель и есть наибольший общий делитель.");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("Чтобы найти наибольший общий делитель трех и более чисел, делаем в такой последовательности:");
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("\t1)Найти наибольший общий делитель любых двух чисел из данных;" +
                    "\n\t2)Найти НОД найденного делителя и третьего числа;" +
                    "\n\t3)Найти НОД последнего найденного делителя и четвёртого числа и т. д.");
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("\t\tСвойства наибольшего общего делителя:");
                PropertyColour("Свойство 1:");
                WriteLine(" Наибольший общий делитель чисел а и b равен наибольшему общему делителю чисел b и а, то есть НОД (a, b) = НОД (b, a). Перемена мест чисел не влияет на конечный результат.");
                PropertyColour("Свойство 2:");
                WriteLine(" Если а делится на b, то множество общих делителей чисел а и b совпадает со множеством делителей числа b, поэтому НОД (a, b) = b.");
                PropertyColour("Свойство 3:");
                WriteLine(" Если a = bq + c, где а, b, с и q — целые числа, то множество общих делителей чисел а и b совпадает со множеством общих делителей чисел b и с. Равенство НОД (a, b) = НОД (b, c) справедливо.");
                PropertyColour("Свойство 4:");
                WriteLine(" Если m — любое натуральное число, то НОД (mа, mb) = m * НОД(а, b).");
                PropertyColour("Свойство 5:");
                WriteLine(" Пусть р — любой общий делитель чисел а и b, тогда НОД (а : p, b : p) = НОД (а, b) : p. А именно, если p = НОД (a, b) имеем НОД (a : НОД (a, b), b: НОД (a, b)) = 1, то есть, числа a : НОД (a, b) и b : НОД (a, b) — взаимно простые.");
                StartMenu();
            }
            void PropertyColour(string x)
            {
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Black;
                Write(x);
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.Magenta;
            }
            void Help()
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("\t\tYou can use the possible commands:");
                PropertyColour("<info>");
                WriteLine("\t If you want to see theoretical information (eng / rus)");
                PropertyColour("<auto>");
                WriteLine("\t If you want to find GCD of randomly generated numbers.");
                PropertyColour("<manua>");
                WriteLine("\t If you want to find the GCD of the given numbers.");
                PropertyColour("<exit>");
                WriteLine("\t If you want to exit the application.");
                Main(args);
            }
            int GCD(int valueOne, int valueTwo)
            {
                while (valueTwo != 0)
                {
                    int temporary = valueTwo;
                    valueTwo = valueOne % valueTwo;
                    valueOne = temporary;
                }
                return valueOne;
            }
        }
    }
}