class StandardGame : Game
{
    public override int getPlayRating(int userNumber, int opponentNumber, GameAccount user, GameAccount opponent)
    {
        if (userNumber > opponentNumber)
        {
            opponent.CurrentRating -= playRating;
            return playRating;
        }
        else
        {
            opponent.CurrentRating += playRating;
            return -playRating;
        }

    }

    public override string GameType => "Standard"; // Властивість для отримання типу гри
}