using Lab4_oop.DB.Entity;
using Lab4_oop.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_oop.DB.Services.Base
{
    public interface IGameService
    {
        public void Create(Game entity);
        public List<Game> GetAll();
        public Game GetById(int Id);
        public void Update(Game entity);
        public void Delete(Game entity);
    }
}
