using Lab3oop.DB.Services;
using Lab3oop.DB;
using Lab3oop.DB.Entity;
using Lab3oop.Games;
using System.Text;
using Lab3oop.GameAccounts;
using System;

namespace Lab3oop
{
    public class Program
    {
        static void Main(string[] args)
        {

            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);
            
            Console.OutputEncoding = Encoding.UTF8;

            Start(accountService, gameService);
        }
        public static void Start(GameAccountService accountService, GameService gameService)
        {

            GameAccount player1 = SelectedAccountType(accountService);
            // always create a standard account for player2
            var player2 = new GameAccount(accountService, accountService.GetAll().Count());
            accountService.Create(player2);

            Game game = GameType(player1, player2, gameService);

            // start game
            game.GameStart();

            // display player statistics after the game is over.
            Show(accountService);

        }
        public static void Show(GameAccountService accountService)
        {
            var listAccounts = accountService.GetAll();
            foreach (var account in listAccounts)
            {
                if (account != null)
                {
                    account.GetStats();
                }

            }
        }
        private static GameAccount SelectedAccountType(GameAccountService service)
        {
            Console.WriteLine("Виберіть тип аккаунта (1-StandardGameAccount/ 2-BonusGameAccount/ 3-StreakGameAccount):");
            int response = Convert.ToInt32(Console.ReadLine());
            var id = service.GetAll().Count();

            switch (response)
            {
                case 1:
                    var standardGameAccount = new GameAccount(service, id);
                    service.Create(standardGameAccount);
                    return standardGameAccount;
                case 2:
                    var bonusGameAccount = new BonusGameAccount(service, id);
                    service.Create(bonusGameAccount);
                    return bonusGameAccount;

                case 3:
                    var streakGameAccount = new StreakGameAccount(service, id);
                    service.Create(streakGameAccount);
                    return streakGameAccount;

                default:
                    Console.WriteLine("\nВведене некоректне значення!");
                    return SelectedAccountType(service);
            }
        }

        private static Game GameType(GameAccount player1, GameAccount player2, GameService service)
        {
            Console.WriteLine("Standard - стандартна гра, Training - гра без змін рейтингу, All-In - гра на всі очки");
            Console.WriteLine("Виберіть тип гри (1-Standard/ 2-Training/ 3-All-In):");
            int temp = Convert.ToInt32(Console.ReadLine());
            GameFactory gameFactory = new GameFactory();

            switch (temp)
            {
                case 1:
                    return gameFactory.CreateGame(player1, player2, service);

                case 2:
                    return gameFactory.CreateTrainingGame(player1, player2, service);

                case 3:
                    return gameFactory.CreateAllinGame(player1, player2, service);

                default:
                    Console.WriteLine("\nВведене некоректне значення!");
                    return GameType(player1, player2, service);
            }
        }


    }
}
