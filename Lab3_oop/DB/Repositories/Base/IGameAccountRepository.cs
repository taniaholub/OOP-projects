﻿using Lab3oop.DB.Entity.GameAccounts;
using Lab3oop.DB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3oop.DB.Repositories.Base
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
