using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Services.Base;
using Lab4_oop.UI.Base;

namespace Lab4_oop.UI
{
    public class PlayGameUI
    {
        IGameAccountService _accountService;
        GameAccount _player1;
        GameAccount _player2;
        IGameService _gameService;
        public PlayGameUI(IGameAccountService accountService, IGameService gameService)
        {
            _accountService = accountService;
            _gameService = gameService;
        }
        public void Action()
        {
            _player1 = _accountService.GetById(_accountService.GetAll().Count - 2);
            _player2 = _accountService.GetById(_accountService.GetAll().Count - 1);

            var game = _gameService.GetById(_gameService.GetAll().Count - 1);
            if (game.Indicator == 0 || game.Indicator == 1)
            {
                var enterPlayrating = new EnterPlayratingUI(_gameService);
                enterPlayrating.Action();
            }

            else { }
            game = _gameService.GetById(_gameService.GetAll().Count - 1);
            Console.WriteLine(game.Play());
            Console.Write("\nПродовжити гру? (Y/N): ");
            string continuePlayingResponse = Console.ReadLine().Trim();

            bool continuePlaying = true;
            if (!continuePlayingResponse.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                continuePlaying = false;
            }
            if (continuePlaying) Action();
        }
    }
}
