﻿using Lab3oop.DB.Entity.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3oop.DB.Repositories.Base
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
