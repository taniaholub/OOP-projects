﻿using System;

namespace Lab4_oop.DB.Entity
{
    public class GameAccountEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public int CurrentRating { get; set; } 
        public int GamesCount { get; set; } = 0; 
        public List<GameResultEntity> GameHistory { get; set; }
        public int Indicator { get; set; }
    }
}
