using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        GameSelection gameSelection = new GameSelection();
        gameSelection.SelectGame();
        gameSelection.SelectAccountType();

        // Оголошуються змінні для представлення гравців (об'єктів класу GameAccount).
        GameAccount player1;
        GameAccount player2;

        string gameType = gameSelection.SelectedGameType;
        string accountType = gameSelection.SelectedAccountType;

        // Створення гравців на основі вибраного типу аккаунта
        if (accountType == "1")
        {
            player1 = new StandardGameAccount("Таня", gameType);
            player2 = new StandardGameAccount("Ваня", gameType);
        }
        else if (accountType == "2")
        {
            player1 = new BonusGameAccount("Таня", gameType);
            player2 = new StandardGameAccount("Ваня", gameType);
        }
        else
        {
            player1 = new StreakGameAccount("Таня", gameType);
            player2 = new StandardGameAccount("Ваня", gameType);
        }

        bool continuePlaying = true;

        while (continuePlaying)
        {
            // Граємо гру з вибраним типом
            player1.PlayGame(player1, player2);

            Console.WriteLine("Продовжити гру? (Y/N)");
            string input = Console.ReadLine().Trim();
            if (input.ToUpper() != "Y")
            {
                continuePlaying = false;
            }
        }

        player1.GetStats(player2);
    }

}
