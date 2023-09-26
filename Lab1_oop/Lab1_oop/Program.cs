using System;
using System.Collections.Generic;

namespace Lab1_oop
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        private List<GameResult> gameHistory;

        public GameAccount(string userName)
        {
            UserName = userName;
            CurrentRating = 100; 
            gameHistory = new List<GameResult>();
        }

        public void PlayGame(GameAccount opponent)
        {
            Console.WriteLine($"{UserName}, введіть число від 1 до 20:");
            int userNumber = int.Parse(Console.ReadLine());
            int opponentNumber = GenerateRandomNumber();

            Console.WriteLine($"{opponent.UserName} ввів число {opponentNumber}.");

            if (userNumber > opponentNumber)
            {
                Console.WriteLine($"Ви виграли! +10 очок.");
                CurrentRating += 10;
                opponent.CurrentRating -= 10;
            }
            else if (userNumber < opponentNumber)
            {
                Console.WriteLine($"{opponent.UserName} виграв! +10 очок.");
                CurrentRating -= 10;
                opponent.CurrentRating += 10;
            }
            else
            {
                Console.WriteLine("Нічия! Без змін у рейтингу.");
            }

            gameHistory.Add(new GameResult(opponent.UserName, userNumber, opponentNumber));
        }

        public void GetStats()
        {
            Console.WriteLine($"Рейтинг користувача {UserName}: {CurrentRating}");
            Console.WriteLine($"Історія ігор:");

            foreach (var result in gameHistory)
            {
                string outcome = result.UserNumber > result.OpponentNumber ? "перемога" :
                                result.UserNumber < result.OpponentNumber ? "поразка" : "нічия";

                Console.WriteLine($"Проти {result.OpponentName}, Ваше число: {result.UserNumber}, " +
                                  $"{result.OpponentName}'s число: {result.OpponentNumber}, Результат: {outcome}");
            }
        }

        private int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 21); 
        }

        private class GameResult
        {
            public string OpponentName { get; }
            public int UserNumber { get; }
            public int OpponentNumber { get; }

            public GameResult(string opponentName, int userNumber, int opponentNumber)
            {
                OpponentName = opponentName;
                UserNumber = userNumber;
                OpponentNumber = opponentNumber;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення першого гравця
            GameAccount player1 = new GameAccount("Tania");

            // Створення другого гравця
            GameAccount player2 = new GameAccount("Vania");

            bool continuePlaying = true;

            while (continuePlaying)
            {
                player1.PlayGame(player2);

                Console.WriteLine("Продовжити гру? (Y/N)");
                string input = Console.ReadLine().Trim();
                if (input.ToUpper() != "Y")
                {
                    continuePlaying = false;
                }
            }

            // Виведення статистики для обох гравців
            player1.GetStats();
            player2.GetStats();
        }
    }
}