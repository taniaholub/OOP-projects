using Lab4_oop.DB.Entity.Games;
using Lab4_oop.DB.Repositories;
using Lab4_oop.DB.Services.Base;
using Lab4_oop.Games;

namespace Lab4_oop.DB.Services
{
    public class GameService : IGameService
    {
        GameRepository repository;
        GameAccountService _serviceAcc;
        public GameService(DbContext context)
        {
            repository = new GameRepository(context);
            _serviceAcc= new GameAccountService(context);
        }
        public void Create(Game entity)
        {
            repository.Create(Map(entity));
        }
        public void Delete(Game entity)
        {
            repository.Delete(Map(entity));
        }
        public List<Game> GetAll()
        {
            var list = repository.GetAll().Select(x => Map(x)).ToList();
            return list;
        }
        public Game GetById(int id)
        {
            var game = Map(repository.GetById(id));
            return game;
        }
        public void Update(Game entity)
        {
            repository.Update(Map(entity));
        }
        private GameEntity Map(Game game)
        {
            return new GameEntity
            {
                Id = game.Id,
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,
                Indicator = game.Indicator,
            };
            
        }
        private Game Map(GameEntity game)
        {
           
            if (game.Indicator == 0)
            {
                return new Game(game.Player1, game.Player2, this)
                {
                    Id = game.Id,
                    player1 = game.Player1,
                    player2 = game.Player2,
                    playRating = game.PlayRating,
                    Indicator = game.Indicator,
                };
            }
            else if (game.Indicator == 1)
            {
                return new AllinGame(game.Player1, game.Player2, this)
                {
                    Id = game.Id,
                    player1 = game.Player1,
                    player2 = game.Player2,
                    playRating = game.PlayRating,
                    Indicator= game.Indicator,
                };
            }
            else
            {
                return new TrainingGame(game.Player1, game.Player2, this)
                {
                    Id = game.Id,
                    player1 = game.Player1,
                    player2 = game.Player2,
                    playRating = game.PlayRating,
                    Indicator= game.Indicator,
                };
            }
        }
       
    }
}
