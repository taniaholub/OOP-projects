using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Services.Base;

namespace Lab4_oop.UI
{
    public class ChooseGameTypeUI : IUserInterface
    {
        IGameService _gameService;
        IGameAccountService _accountService;
        GameAccount _player1;
        GameAccount _player2;

        public ChooseGameTypeUI(IGameService gameService, IGameAccountService accountService)
        {
            _gameService = gameService;
            _accountService = accountService;
        }
        public void Action()
        {
            _player1 = _accountService.GetById(_accountService.GetAll().Count - 2);
            _player2 = _accountService.GetById(_accountService.GetAll().Count - 1);

            Console.WriteLine("Standard - стандартна гра, Training - гра без змін рейтингу, All-In - гра на всі очки");
            Console.WriteLine("Виберіть тип гри (1-Standard/ 2-Training/ 3-All-In):");

            int temp = Convert.ToInt32(Console.ReadLine());
            GameFactory gameFactory = new GameFactory();

            switch (temp)
            {
                case 1:
                    _gameService.Create(gameFactory.CreateGame(_player1, _player2, _gameService));
                    break;

                case 2:
                    _gameService.Create(gameFactory.CreateTrainingGame(_player1, _player2, _gameService));
                    break;

                case 3:
                    _gameService.Create(gameFactory.CreateAllinGame(_player1, _player2, _gameService));
                    break;

                default:
                    Console.WriteLine("\nВведене некоректне значення!");
                    Action();
                    break;
            }
        }

    }
}
