using System;

abstract class Game
{
    
    public abstract string GameType { get; } // властивість, яка повертає тип гри.
    public int playRating { get; set; } = 50;

    public virtual int getPlayRating(int userNumber, int opponentNumber, GameAccount user, GameAccount opponent) { return playRating; }
}

class TrainingGame : Game
{
    public override int getPlayRating(int userNumber, int opponentNumber, GameAccount user, GameAccount opponent)
    {
        return 0; // Навчальна ігра не впливає на рейтинги, завжди повертає 0
    }

    public override string GameType => "Training"; // повертає строку "Training", представляючи тип гри.
}

class AllinGame : Game
{
    public override int getPlayRating(int userNumber, int opponentNumber, GameAccount user, GameAccount opponent)
    {
        int playRating = user.StartRating;

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

    public override string GameType => "All-In";
}



class GameResult
{
    public string OpponentName { get; }
    public int UserNumber { get; }
    public int OpponentNumber { get; }
    public string Outcome { get; }

    public GameResult(string opponentName, int userNumber, int opponentNumber, string outcome)
    {
        OpponentName = opponentName;
        UserNumber = userNumber;
        OpponentNumber = opponentNumber;
        Outcome = outcome; // результат гри ("перемога", "поразка" або "нічия").
    }
}