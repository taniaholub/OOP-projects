using Lab4_oop.DB.Services.Base;
using System;


namespace Lab4_oop.UI
{
    public class ShowPlayersUI
    {
        IGameAccountService _accountService;
        public ShowPlayersUI(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public void Action()
        {
            var listAccounts = _accountService.GetAll();
            foreach (var account in listAccounts)
            {
                if (account != null)
                {
                    Console.WriteLine(account.GetStats());
                }
            }
        }
    }
}
