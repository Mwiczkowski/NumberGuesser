using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();

            string userName = GetUserName();

            GreetUser(userName);

            Random random = new Random();
            int correctNumber = random.Next(1,11);

            bool correctAnswer = false;

            Console.WriteLine("Guess a number between 1 and 10.");

            while (!correctAnswer)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);

                if(!isNumber)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Please, introduce a number.");
                    continue;
                }

                if(guess < 1 || guess > 10)
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Please, introduce a number from 1 to 10.");
                    continue;
                }

                if (guess < correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Wrong answer. The number drawn is greater.");
                }
                else if (guess > correctNumber)
                {
                    PrintColorMessage(ConsoleColor.Red, "Wrong answer. The number drawn is smaller.");
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage(ConsoleColor.Green, "Congrats! Correct answer.");
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Number Guesser";
            int appVersion = 1;
            string appAuthor = "Miłosz Wiczkowski";

            string info = $"[{appName}], Version 0.0.{appVersion}, Author: {appAuthor}";

            PrintColorMessage(ConsoleColor.Magenta, info);

        }

        static string GetUserName()
        {
            Console.WriteLine("What's your name?");

            string inputUserName = Console.ReadLine();

            return inputUserName;
        }

        static void GreetUser(string userName)
        {
            string greet = $"Good luck {userName}, guess a number...";

            PrintColorMessage(ConsoleColor.Blue, greet);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
