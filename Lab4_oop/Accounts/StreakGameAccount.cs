using Lab4_oop.DB.Services.Base;

namespace Lab4_oop.DB.Entity.GameAccounts
{
    public class StreakGameAccount : GameAccount
    {
        IGameAccountService _service;
        public StreakGameAccount(IGameAccountService service, int ID, int gamesCount = 0, int indicator = 2) : base(service, ID, gamesCount, indicator)
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
