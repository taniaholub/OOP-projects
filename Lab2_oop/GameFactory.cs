class GameFactory
{
    public static Game CreateGame(string gameType) // містить метод CreateGame, який приймає gameType і повертає об'єкт класу Game.
    {
        switch (gameType)
        {
            case "1":
                return new StandardGame();
            case "2":
                return new TrainingGame();
            case "3":
                return new AllinGame();
            default:
                throw new ArgumentException("Невідомий тип гри");
        }
    }
}


class GameSelection
{
    public string? SelectedGameType { get; private set; }
    public string? SelectedAccountType { get; private set; }

    public void SelectGame()
    {
        Console.WriteLine("Початковий рейтинг: 100");
        Console.WriteLine("Standard - стандартна гра, Training - гра без змін рейтингу, All-In - гра на всі очки");
        Console.WriteLine("Виберіть тип гри (1-Standard/ 2-Training/ 3-All-In):");
        SelectedGameType = Console.ReadLine();
    }

    public void SelectAccountType()
    {
        Console.WriteLine("Виберіть тип гри аккаунт (1-StandardGameAccount/ 2-BonusGameAccount/ 3-StreakGameAccount):");
        SelectedAccountType = Console.ReadLine();
    }
}
