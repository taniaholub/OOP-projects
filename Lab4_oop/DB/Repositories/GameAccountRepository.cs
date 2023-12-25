﻿using Lab4_oop.DB.Entity;
using Lab4_oop.DB.Repositories.Base;

namespace Lab4_oop.DB.Repositories
{
    public class GameAccountRepository : IGameAccountRepository
    {
        DbContext context;
        public GameAccountRepository(DbContext context) 
        { 
            this.context = context; 
        }
        public void AddGameResult(GameResultEntity gameResult, GameAccountEntity entity)
        {
            context.Accounts[entity.Id].GameHistory.Add(gameResult);
        }

        public void Create(GameAccountEntity entity)
        {
            context.Accounts.Add(entity);
        }
        public void Delete(GameAccountEntity entity)
        {
            context.Accounts.RemoveAt(entity.Id);
            int ID = 1;
            foreach (var gameAccount in context.Accounts) { context.Accounts[ID].Id = ID; ID++; }
        }
        public List<GameAccountEntity> GetAll()
        {
            return context.Accounts;
        }
        public GameAccountEntity GetById(int id)
        {
            return context.Accounts[id];
        }
        public List<GameResultEntity> GetHistory(GameAccountEntity entity)
        {
            return entity.GameHistory;
        }
        public void Update(GameAccountEntity entity)
        {
            context.Accounts.RemoveAt(entity.Id);
            context.Accounts.Insert(entity.Id, entity);
        }
    }
}
