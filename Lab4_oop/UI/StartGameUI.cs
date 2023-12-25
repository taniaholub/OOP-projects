﻿using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Services.Base;
using System.Text;


namespace Lab4_oop.UI
{
    public class StartGameUI
    {
        IGameAccountService _accountService;
        GameAccount _player1;
        GameAccount _player2;
        IGameService _gameService;
        public StartGameUI(IGameAccountService accountService, IGameService gameService)
        {
            _accountService = accountService;
            _gameService = gameService;
        }
        public void Action()
        {
            _player1 = _accountService.GetById(_accountService.GetAll().Count - 2);
            _player2 = _accountService.GetById(_accountService.GetAll().Count - 1);
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть ім'я першого гравця: ");
            _player1.UserName = Console.ReadLine().Trim();

            Console.Write("Введіть ім'я другого гравця: ");
            _player2.UserName = Console.ReadLine().Trim();
            var game = _gameService.GetById(_gameService.GetAll().Count - 1);
            game.player1 = _player1;
            game.player2 = _player2;
            _gameService.Update(game);
            _accountService.Update(_player1);
            _accountService.Update(_player2);
        }
    }
}
