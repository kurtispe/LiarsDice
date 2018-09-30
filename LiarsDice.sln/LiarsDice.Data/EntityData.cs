using LiarsDice.Data.DataModels;
using LiarsDice.Library.Interfaces;
using LiarsDice.Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiarsDice.Data
{
    public class EntityData
    {
        #region Constructor
        public EntityData()
        {
            
        }
       
        private static  MockDB CTX = new MockDB();
        #endregion

        #region Functions
        public async void SaveAsync<T>(T obj) where T : SaveHelper
        {
            switch (obj.CaseID)
            {
                case 0:
                    CTX.Bet.Add(obj as Data_Bet);
                    await CTX.SaveChangesAsync();
                    break;
                case 1:
                    CTX.Die.Add(obj as Data_Die);
                    await CTX.SaveChangesAsync();
                    break;
                case 2:
                    CTX.Game.Add(obj as Data_Game);
                    await CTX.SaveChangesAsync();
                    break;
                case 3:
                    CTX.Player.Add(obj as Data_Player);
                    await CTX.SaveChangesAsync();
                    break;
                default:
                    throw new TypeAccessException();
            }
        }

        public async Task<G> FindAsync<T, G>(T obj) where G : class where T : SaveHelper 
        {
            switch (obj.CaseID)
            {
                case 0:
                    return await CTX.Bet.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                case 1:
                    return await CTX.Bet.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                case 2:
                    return await CTX.Bet.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                case 3:
                    return await CTX.Bet.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                default:
                    return default(G);
            }
        }
        #endregion
    }
}
