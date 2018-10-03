
using LiarsDice.Data.DataModels;
using LiarsDice.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiarsDice.Data
{
    public class EntityData
    {
        #region Constructor
        public EntityData(CommonContext db)
        {
            CTX = db;
        }

        private static CommonContext CTX;
        #endregion

        #region Functions
        #region Bet
        public async void SaveBet(BetDB obj)
        {
            try
            {
                CTX.BetDB.Add(obj);
                await CTX.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                CTX.BetDB.Update(obj);
                await CTX.SaveChangesAsync();
            }
        }
        public async Task<BetDB> FindBet(int pk)
        {
            return await CTX.BetDB.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<BetDB>> FindAllBets()
        {
            return await CTX.BetDB.ToListAsync();
        }
        public async void DeleteOneBet(BetDB obj)
        {
            CTX.BetDB.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #region Account
        public async void SaveAccount(AccountDB obj)
        {
            try
            {
                CTX.AccountDB.Add(obj);
                await CTX.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                CTX.AccountDB.Update(obj);
                await CTX.SaveChangesAsync();
            }
        }
        public async Task<AccountDB> FindAccount(int pk)
        {
            return await CTX.AccountDB.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<AccountDB>> FindAllAccounts()
        {
            return await CTX.AccountDB.ToListAsync();
        }
        public async void DeleteOneAccount(AccountDB obj)
        {
            CTX.AccountDB.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #region Die
        public async void SaveDie(DieDB obj)
        {
            try
            {
                CTX.DieDB.Add(obj);
                await CTX.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                CTX.DieDB.Update(obj);
                await CTX.SaveChangesAsync();
            }
        }
        public async Task<DieDB> FindDie(int pk)
        {
            return await CTX.DieDB.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<DieDB>> FindAllDies()
        {
            return await CTX.DieDB.ToListAsync();
        }
        public async void DeleteOneDie(DieDB obj)
        {
            CTX.DieDB.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #region Player
        public async void SavePlayer(PlayerDB obj)
        {
            try
            {
                CTX.PlayerDB.Add(obj);
                await CTX.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                CTX.PlayerDB.Update(obj);
                await CTX.SaveChangesAsync();
            }
        }
        public async Task<PlayerDB> FindPlayer(int pk)
        {
            return await CTX.PlayerDB.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<PlayerDB>> FindAllPlayers()
        {
            return await CTX.PlayerDB.ToListAsync();
        }
        public async void DeleteOnePlayer(PlayerDB obj)
        {
            CTX.PlayerDB.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #region Game
        public async void SaveGame(GameDB obj)
        {
            try
            {
                CTX.GameDB.Add(obj);
                await CTX.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                CTX.GameDB.Update(obj);
                await CTX.SaveChangesAsync();
            }
        }
        public async Task<GameDB> FindGame(int pk)
        {
            return await CTX.GameDB.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<GameDB>> FindAllGames()
        {
            return await CTX.GameDB.ToListAsync();
        }
        public async void DeleteOneGame(GameDB obj)
        {
            CTX.GameDB.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
    #endregion
    }
}
