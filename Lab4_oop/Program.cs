using Lab4_oop.DB.Services;
using Lab4_oop.DB;
using Lab4_oop.UI;
using System.Text;

namespace Lab4_oop
{
    public class Program
    {
        static void Main(string[] args)
        {

            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);

            Console.OutputEncoding = Encoding.UTF8;

            var startOptions = new StartOptionsUI(accountService, gameService);
            startOptions.Action();
        }

    }
}
