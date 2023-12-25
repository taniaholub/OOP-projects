using System;

namespace Lab4_oop.DB.Entity.Games
{
    public class GameEntity
    {
        public int Id { get; set; }
        public GameAccount Player1 { get; set; }
        public GameAccount Player2 { get; set; }
        public int PlayRating { get; set; }
        public int Indicator { get; set; }
    }
}
