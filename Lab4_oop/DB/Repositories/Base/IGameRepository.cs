using Lab4_oop.DB.Entity.Games;

namespace Lab4_oop.DB.Repositories.Base
{
    public interface IGameRepository
    {
        public void Create(GameEntity entity);
        public List<GameEntity> GetAll();
        public GameEntity GetById(int Id);
        public void Update(GameEntity entity);
        public void Delete(GameEntity entity);
    }
}
