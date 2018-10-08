using LiarsDice.BE.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiarsDice.BE.Data
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
        #region Account
        public async void SaveAccountAsync(Account obj)
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
        public async Task<Account> FindAccountAsync(int pk)
        {
            return await CTX.AccountDB.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<Account>> FindAllAccountsAsync()
        {
            return await CTX.AccountDB.ToListAsync();
        }
        public async void DeleteOneAccountAsync(Account obj)
        {
            CTX.AccountDB.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #region Die
        public async void SaveDieAsync(Die obj)
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
        public async Task<Die> FindDieAsync(int pk)
        {
            return await CTX.DieDB.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<Die>> FindAllDiesAsync()
        {
            return await CTX.DieDB.ToListAsync();
        }
        public async void DeleteOneDieAsync(Die obj)
        {
            CTX.DieDB.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #region Player
        public async void SavePlayerAsync(Player obj)
        {
            try
            {
                CTX.Player.Add(obj);
                await CTX.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                CTX.Player.Update(obj);
                await CTX.SaveChangesAsync();
            }
        }
        public async Task<Player> FindPlayerAsync(int pk)
        {
            return await CTX.Player.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<Player>> FindAllPlayersAsync()
        {
            return await CTX.Player.ToListAsync();
        }
        public async void DeleteOnePlayerAsync(Player obj)
        {
            CTX.Player.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #region Game
        public async void SaveGameAsync(Game obj)
        {
            try
            {
                CTX.Game.Add(obj);
                await CTX.SaveChangesAsync();
            }
            catch (ArgumentException)
            {
                CTX.Game.Update(obj);
                await CTX.SaveChangesAsync();
            }
        }
        public async Task<Game> FindGameAsync(int pk)
        {
            return await CTX.Game.SingleOrDefaultAsync(n => n.PK == pk);
        }
        public async Task<List<Game>> FindAllGamesAsync()
        {
            return await CTX.Game.ToListAsync();
        }
        public async void DeleteOneGameAsync(Game obj)
        {
            CTX.Game.Remove(obj);
            await CTX.SaveChangesAsync();
        }
        #endregion
        #endregion
    }
}
