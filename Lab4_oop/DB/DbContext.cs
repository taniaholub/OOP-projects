using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Entity.Games;

namespace Lab4_oop.DB
{
    public class DbContext
    {
        public List<GameEntity> Games { get; set; }
        public List<GameAccountEntity> Accounts { get; set; }

        public DbContext()
        {
            Games = new List<GameEntity>();
            Accounts = new List<GameAccountEntity>();
        }
    }
}