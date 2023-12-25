using System.Text;
using Lab4_oop.DB.Services.Base;
using Lab4_oop.Games;

namespace Lab4_oop.DB.Entity
{
    public class GameAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public int CurrentRating { get; set; } = 100; 
        public List<GameResult> GameHistory; 
        public int GamesCount { get; set; } 
        public int WinStreak { get; set; } = 0;
        public IGameAccountService _service { get; set; }
        public int Indicator { get; set; }


        // Constructor of the GameAccount class, where it is possible to specify the initial number of games (default - 0).
        public GameAccount(IGameAccountService service, int ID, int gamesCount = 0, int indicator = 0)
        {
            _service = service;
            GamesCount = gamesCount;
            GameHistory = _service.GetHistory(this);
            Id = ID;
            Indicator = indicator;
        }

        public void WinGame(string opponentName, Game game, int player1Number, int player2Number)
        {
            int ratingChange = CalculateRatingChange(game.getPlayRating(this, player1Number, player2Number), player1Number, player2Number);
            GamesCount++;
            CurrentRating += ratingChange;
            var result = new GameResult(opponentName, "Перемога", ratingChange);
            GameHistory.Add(result);
            WinStreak++;
            _service.Update(this);
        }

        public void LoseGame(string opponentName, Game game, int player1Number, int player2Number)
        {
            int ratingChange = CalculateRatingChange(game.getPlayRating(this, player1Number, player2Number), player1Number, player2Number);
            GamesCount++;
            CurrentRating -= ratingChange;
            var result = new GameResult(opponentName, "Поразка", ratingChange);
            GameHistory.Add(result);
            WinStreak = 0;
            _service.Update(this);
        }
        public void Draw(string opponentName) 
        {
            GamesCount++;
            var result = new GameResult(opponentName, "Нічия");
            GameHistory.Add(result);
            _service.Update(this);
        }

        public string GetStats()
        {
            var stats = "";
            Console.OutputEncoding = Encoding.UTF8;
            stats += "\n Історія ігор:\n";
            if (GameHistory == null) 
            {
                Console.WriteLine($"Ім'я: {UserName}, Id: {Id}");
                return "";
            }

            stats += $"Ім'я: {UserName}, Id: {Id}\n";
            for (int i = 0; i < GameHistory.Count; i++)
            {
                
                var result = _service.GetHistory(this)[i];
                String matchResult;
                if (result.Won == null) 
                {
                    stats += $"Партія {i + 1}: \n" +
                  $"Результат: Нічия, опонент: {result.OpponentName}, зміна рейтингу: {result.RatingChange}\n";
        }
                stats += $"Партія {i + 1}: \n" +
                                  $"Опонент: {result.OpponentName}, {(result.Won)}, зміна рейтингу: {result.RatingChange}\n";
        }
            stats += $"Рейтинг гравця {UserName}: {CurrentRating}\n" +
                              $"Кількість ігор: {GamesCount}\n";
            return stats;
        }

        public virtual int CalculateRatingChange(int ratingChange)
        {
            return ratingChange;
        }

        // calculation of points for the BonusGameAccount
        public virtual int CalculateRatingChange(int ratingChange, int player1Number, int player2Number)
        {
            return ratingChange;
        }
    }
}
