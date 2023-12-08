﻿using System;


namespace Lab3oop
{
    public class GameResult
    {
        public string OpponentName { get; set; }
        public string Won { get; set; }
        public int RatingChange { get; set; }

        public GameResult(string opponentName, string won, int ratingChange)
        {
            OpponentName = opponentName;
            Won = won;
            RatingChange = ratingChange;
        }
        public GameResult(string opponentName, string won)
        {
            OpponentName = opponentName;
            Won = won;
        }
        public GameResult()
        {
        
        }
    }

}
