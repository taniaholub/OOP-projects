using Lab4_oop.DB.Services;
using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Services.Base;

namespace Lab4_oop.Games
{
    public class Game
    {
        public int Id { get; set; }   
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public GameAccount Winner { get; set; }
        public int playRating { get; set; } = 0;
        public IGameService _service { get; set; }
        public int Indicator { get; set; }
        public Game(GameAccount player1, GameAccount player2, IGameService service, int indicator=0)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
            Indicator = indicator;
        }

        public virtual int getPlayRating(GameAccount player, int player1Number, int player2Number) { return playRating; }
        
        public virtual string Play()
        {
            var str = "";
            Random random = new Random();
            Console.WriteLine($"{player1.UserName}, введіть число від 1 до 20:");
            int player1Number = int.Parse(Console.ReadLine());
            int player2Number = random.Next(1, 21);
            str += $"{player2.UserName}, ввів число {player2Number}\n";

            if (player1Number > player2Number)
            {
                player1.WinGame(player2.UserName, this, player1Number, player2Number);
                player2.LoseGame(player1.UserName, this, player1Number, player2Number);
                Winner = player1;
                _service.Create(this);
                str += $"Переміг {player1.UserName}!\n";
                str += player1.GetStats();
                str += player2.GetStats();
            }
            else if (player1Number < player2Number)
            {
                player2.WinGame(player1.UserName, this, player1Number, player2Number);
                player1.LoseGame(player2.UserName, this, player1Number, player2Number);
                Winner = player2;
                _service.Create(this);
                str += $"Переміг {player2.UserName}!\n";
                str += player1.GetStats();
                str += player2.GetStats();
            }
            else if (player1Number == player2Number)
            {
                player1.Draw(player2.UserName);
                player2.Draw(player1.UserName);
                str += "Нічия";
            }
            return str;

        }
    }
}

