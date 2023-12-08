using System;
using Lab3oop.DB.Services;
using Lab3oop.DB.Entity;

namespace Lab3oop.GameAccounts
{
    public class StreakGameAccount : GameAccount
    {
        GameAccountService _service;
        public StreakGameAccount(GameAccountService service, int ID, int gamesCount = 0) : base(service, ID, gamesCount)
        {
            _service = service;
            Id = ID;
        }

        public override int CalculateRatingChange(int ratingChange)
        {
            if (WinStreak <= 2)
            {
                return ratingChange;
            }

            else
            {
                return ratingChange + WinStreak * 10;
            }
           
        }
    }
}
