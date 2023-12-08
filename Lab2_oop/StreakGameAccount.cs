using System.ComponentModel;

class StreakGameAccount : GameAccount
{
    public StreakGameAccount(string userName, string gameType) : base(userName, gameType) { }

    public override int CalculateRatingChange(int ratingChange)
    {
        if (WinStreak <= 2)
        {
            return ratingChange;
        }

        else
        {
            return ratingChange + WinStreak*10;
        }
    }
    public override string AccountType => "StreakGameAccount";
}
