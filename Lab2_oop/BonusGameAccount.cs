class BonusGameAccount : GameAccount
{
    public BonusGameAccount(string userName, string gameType) : base(userName, gameType) { }

    public override int CalculateRatingChange(int ratingChange, int userNumber, int opponentNumber)
    {
        if (userNumber > opponentNumber)
        {
            return ratingChange + ratingChange / 2;
        }
        if (opponentNumber > userNumber)
        {
            return ratingChange / 2;
        }

        // default return statement
        return 0;
    }
    public override string AccountType => "BonusGameAccount";
}
