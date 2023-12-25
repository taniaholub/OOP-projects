using Lab4_oop.DB.Entity;

namespace Lab4_oop.DB.Repositories.Base
{
    public interface IGameAccountRepository
    {
        public void Create(GameAccountEntity entity);
        public List<GameAccountEntity> GetAll();
        public GameAccountEntity GetById(int id);
        public void Update(GameAccountEntity entity);
        public void Delete(GameAccountEntity entity);
        public List<GameResultEntity> GetHistory(GameAccountEntity entity);
        public void AddGameResult(GameResultEntity gameResult, GameAccountEntity entity);
    }
}
