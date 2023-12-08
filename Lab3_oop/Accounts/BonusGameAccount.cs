using Lab3oop.DB.Services;
using System;

namespace Lab3oop.DB.Entity
{
    public class BonusGameAccount : GameAccount
    {
        GameAccountService _service;
        public BonusGameAccount(GameAccountService service, int ID, int gamesCount = 0) : base(service, ID, gamesCount)
        {
            _service = service;
            Id = ID;
        }

        public override int CalculateRatingChange(int ratingChange, int player1Number, int player2Number)
        {

            if (player1Number > player2Number)
            {
                return ratingChange + ratingChange / 2;
            }
            if (player2Number > player1Number)
            {
                return ratingChange / 2;
            }

            // default return statement
            return 0;
        }
    }
}
