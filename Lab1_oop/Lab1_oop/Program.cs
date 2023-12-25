using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lab1_oop
{
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

            Console.WriteLine("За перемогу +50 очків, за поразку -50 очків:");
            while (continuePlaying)
            {
                // Гравці грають один проти одного
                player1.PlayGame(player2);

                Console.WriteLine("Продовжити гру? (Y/N)");
                string input = Console.ReadLine().Trim();
                if (input.ToUpper() != "Y")
                {
                    continuePlaying = false;
                }
            }

            // Статистика для обох гравців після гри
            player1.GetStats(player2);
        }
    }

    public class GameAccount
    {
        public string UserName { get; set; }
        public int CurrentRating { get; set; }
        private List<GameResult> gameHistory;
        public int GamesCount { get; private set; }

        public GameAccount(string userName)
        {
            UserName = userName;
            CurrentRating = 100;
            gameHistory = new List<GameResult>();
            GamesCount = 0; // Кількість зіграних партій
        }

        public void PlayGame(GameAccount opponent)
        {
            // Остаточний результат гри для поточного користувача
            int userResult = 0;

            Console.WriteLine($"{UserName}, введіть число від 1 до 20:");
            int userNumber = int.Parse(Console.ReadLine());
            int opponentNumber = GenerateRandomNumber();

            Console.WriteLine($"{opponent.UserName} ввів число {opponentNumber}.");

            if (userNumber > opponentNumber)
            {
                userResult = 1; // Гравець переміг
            }
            else if (userNumber < opponentNumber)
            {
                userResult = -1; // Гравець програв
            }
            else
            {
                Console.WriteLine("Нічия! Без змін у рейтингу.");
            }

            // Оновлення рейтингів обох гравців
            if (userResult == 1)
            {
                WinGame(50);
                opponent.LoseGame(50);
            }
            else if (userResult == -1)
            {
                LoseGame(50);
                opponent.WinGame(50);
            }

            gameHistory.Add(new GameResult(opponent.UserName, userNumber, opponentNumber));
            GamesCount++;
        }


        public void WinGame(int Rating)
        {
            CurrentRating += Rating;
            Console.WriteLine($"Гравець {UserName} виграв! Поточний рейтинг: {CurrentRating}");
            
        }

        public void LoseGame(int Rating)
        {
            if (CurrentRating > 1)
            {
                CurrentRating -= Rating;
            }
            Console.WriteLine($"Гравець {UserName} програв! Поточний рейтинг: {CurrentRating}");
        }

        public void GetStats(GameAccount oppent)
        {
            Console.WriteLine($"Рейтинг користувача {UserName}: {CurrentRating}");
            Console.WriteLine($"Рейтинг користувача {oppent.UserName}: {oppent.CurrentRating}");
            Console.WriteLine($"Історія ігор:");

            // Виведення кількості зіграних партій
            Console.WriteLine($"Зіграно партій: {GamesCount}");

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
}
