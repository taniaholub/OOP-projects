using Lab4_oop.DB.Entity.GameAccounts;
using Lab4_oop.DB.Services;
using Lab4_oop.Accounts;
using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Services.Base;

namespace Lab4_oop.UI
{
    public class ChoosePlayerAccountUI : IUserInterface
    {
        IGameAccountService _accountService;
        public ChoosePlayerAccountUI(IGameAccountService accountService)
        {
            _accountService = accountService;
        }
        public void Action()
        {
            Console.WriteLine("Виберіть тип аккаунта (1-StandardGameAccount/ 2-BonusGameAccount/ 3-StreakGameAccount):");
            int temp = Convert.ToInt32(Console.ReadLine());
            var id = _accountService.GetAll().Count();

            switch (temp)
            {
                case 1:
                    var standardGameAccount = new GameAccount(_accountService, id);
                    _accountService.Create(standardGameAccount);
                    break;

                case 2:
                    var bonusGameAccount = new BonusGameAccount(_accountService, id);
                    _accountService.Create(bonusGameAccount);
                    break;

                case 3:
                    var streakGameAccount = new StreakGameAccount(_accountService, id);
                    _accountService.Create(streakGameAccount);
                    break;

                default:
                    Console.WriteLine("\nВведене некоректне значення!");
                    Action();
                    break;
            }
        }

    }
}
