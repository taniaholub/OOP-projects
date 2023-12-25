using Lab4_oop.DB.Services.Base;

namespace Lab4_oop.UI.Base
{
    public class EnterPlayratingUI : IUserInterface
    {
        IGameService _gameService;
        public EnterPlayratingUI(IGameService gameService) 
        { 
            _gameService = gameService;
        }
        public void Action()
        {
            var game = _gameService.GetById(_gameService.GetAll().Count - 1);
            Console.Write($"Рейтинг на який граєте: ");
            game.playRating = 10;

            if (game.playRating > game.player1.CurrentRating - 1 || game.playRating > game.player2.CurrentRating - 1)
            {
                Console.WriteLine("У одного з гравців недостатньо рейтингу.");
                Action();
            }
            Console.WriteLine(game.playRating);
            _gameService.Update(game);
        }
    }
}
