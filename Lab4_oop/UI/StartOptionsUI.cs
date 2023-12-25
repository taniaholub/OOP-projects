using Lab4_oop.DB.Services.Base;
using System;

namespace Lab4_oop.UI
{
    public class StartOptionsUI : IUserInterface
    {
        ChooseGameTypeUI gameUI;
        ChoosePlayerAccountUI playerUI;
        PlayGameUI playGameUI;
        ShowPlayersUI showPlayersUI;
        StartGameUI startGameUI;
        IGameAccountService _accountService;
        IGameService _gameService;
        public StartOptionsUI(IGameAccountService accountService, IGameService gameService) 
        {
            _accountService= accountService;
            _gameService= gameService;
            gameUI = new ChooseGameTypeUI(_gameService, _accountService);
            playerUI = new ChoosePlayerAccountUI(_accountService);
            playGameUI = new PlayGameUI(_accountService, _gameService);
            showPlayersUI = new ShowPlayersUI(_accountService);
            startGameUI = new StartGameUI(_accountService, _gameService);
        }
        public void Action()
        {
            Console.WriteLine("1) розпочати гру;");
            Console.WriteLine("2) вивести список гравців;");
            Console.WriteLine("3) вивести гравця по айді;\n");

            int response = Convert.ToInt32(Console.ReadLine());

            if (response == 1)
            {
                playerUI.Action();
                playerUI.Action();
                gameUI.Action();
                startGameUI.Action();
                playGameUI.Action();
            }
            else if (response == 2)
            {
                showPlayersUI.Action();
            }
            else if (response == 3)
            {
                Console.Write("Id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var showPlayerByIdUI = new ShowPlayerByIdUI(_accountService, id);
                showPlayerByIdUI.Action();
            }
            else
            {
                Console.WriteLine("\nВведене некоректне значення!");
                Action();
            }

            Action();
        }
    }
}
