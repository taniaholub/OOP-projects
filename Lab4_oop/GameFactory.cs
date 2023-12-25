using System;
using Lab4_oop.DB.Services;
using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Services.Base;
using Lab4_oop.Games;

namespace Lab4_oop
{
    public class GameFactory
    {
        public Game CreateGame(GameAccount player1, GameAccount player2, IGameService service)
        {
            return new Game(player1, player2, service);
        }
        public Game CreateTrainingGame(GameAccount player1, GameAccount player2, IGameService service)
        {
            return new TrainingGame(player1, player2, service);
        }

        public Game CreateAllinGame(GameAccount player1, GameAccount player2, IGameService service)
        {
            return new AllinGame(player1, player2, service);
        }

    }
}
