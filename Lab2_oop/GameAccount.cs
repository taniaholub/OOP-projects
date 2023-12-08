using System;
using System.Collections.Generic;

abstract class GameAccount
{
    public string UserName { get; set; }
    public double CurrentRating { get; set; }
    private List<GameResult> gameHistory;
    public int GamesCount { get; private set; }
    public Game CurrentGame { get; set; }
    public abstract string AccountType { get; }
    public int WinStreak { get; set; } = 1;
    public int StartRating { get; set; } = 100;
    public GameAccount(string userName, string gameType)
    {
        UserName = userName;
        CurrentRating = StartRating;
        gameHistory = new List<GameResult>();
        GamesCount = 0;
        CurrentGame = GameFactory.CreateGame(gameType); // Створення нового екземпляра гри на основі вказаного типу гри
    }

    public void PlayGame(GameAccount user, GameAccount opponent)
    {
        // Перевірка на недостатній рейтинг перед грою
        if (CurrentRating < 1 || opponent.CurrentRating < 1)
        {
            Console.WriteLine("Недостатньо рейтингу для продовження гри.");
            return;
        }

        Console.WriteLine($"{UserName}, введіть число від 1 до 20:");
        int userNumber = int.Parse(Console.ReadLine());
        int opponentNumber = GenerateRandomNumber();

        Console.WriteLine($"{opponent.UserName} ввів число {opponentNumber}.");

        if (userNumber > opponentNumber)
        {
            user.WinGame(CurrentGame, opponent, userNumber, opponentNumber);
            opponent.LoseGame(CurrentGame, opponent, userNumber, opponentNumber);
        }
        else if (userNumber < opponentNumber)
        {
            opponent.WinGame(CurrentGame, opponent, userNumber, opponentNumber);
            user.LoseGame(CurrentGame, opponent, userNumber, opponentNumber);
        }
        else
        {
            Console.WriteLine("Нічия! Рейтинг не змінився.");
        }

        Console.WriteLine($"Поточний рейтинг користувача {UserName}: {CurrentRating}");
        Console.WriteLine($"Поточний рейтинг користувача {opponent.UserName}: {opponent.CurrentRating}");
    }

    public virtual int CalculateRatingChange(int ratingChange)
    {
        return ratingChange;
    }

    
    public virtual int CalculateRatingChange(int ratingChange, int userNumber, int opponentNumber) // обрахунок балів для бонусного аккаунта
    {
        return ratingChange;
    }

    public virtual void WinGame(Game game, GameAccount opponent, int userNumber, int opponentNumber)
    {
        double ratingChange = CalculateRatingChange(game.getPlayRating(userNumber, opponentNumber, this, opponent), userNumber, opponentNumber);
        CurrentRating += ratingChange;
        gameHistory.Add(new GameResult(opponent.UserName, userNumber, opponentNumber, "перемога"));
        GamesCount++;
        // збільшення winStreak для StreakGameAccount
        if (this is StreakGameAccount)
        {
            WinStreak++;
        }
    }

    public virtual void LoseGame(Game game, GameAccount opponent, int userNumber, int opponentNumber)
    {
        double ratingChange = CalculateRatingChange(game.getPlayRating(userNumber, opponentNumber, this, opponent), userNumber, opponentNumber);
        CurrentRating += ratingChange;  // Subtract rating change for a loss
        gameHistory.Add(new GameResult(opponent.UserName, userNumber, opponentNumber, "поразка"));
        GamesCount++;
        if (this is StreakGameAccount)
        {
            WinStreak = 0;
        }
    }


    public void GetStats(GameAccount opponent)
    {
        Console.WriteLine($"Історія ігор:");

        Console.WriteLine($"Зіграно партій: {GamesCount}");

        foreach (var result in gameHistory)
        {
            string outcome = result.UserNumber > result.OpponentNumber ? "перемога" :
                            result.UserNumber < result.OpponentNumber ? "поразка" : "нічия";

            Console.WriteLine($"Проти {result.OpponentName}, Ваше число: {result.UserNumber}, " +
                              $"{result.OpponentName}'s число: {result.OpponentNumber}, Результат: {outcome}");
        }

        Console.WriteLine($"Рейтинг користувача {UserName}: {CurrentRating}");
        Console.WriteLine($"Рейтинг користувача {opponent.UserName}: {opponent.CurrentRating}");
    }

    private int GenerateRandomNumber()
    {
        Random random = new Random();
        return random.Next(1, 21);
    }
}

class StandardGameAccount : GameAccount
{
    public StandardGameAccount(string userName, string gameType) : base(userName, gameType) { } //виклик конструктора базового класу з наданими параметрами

    public override int CalculateRatingChange(int ratingChange)
    {
        return ratingChange;
    }
    public override string AccountType => "StandardGameAccount"; // Перевизначте властивість AccountType, щоб надати певний тип аккаунта для StandardGameAccount
}

