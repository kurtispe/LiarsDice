﻿
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
                    try
                    {
                        CTX.Bet.Add(obj as Bet);
                        await CTX.SaveChangesAsync();
                    }
                    catch (ArgumentException)
                    {
                        CTX.Bet.Update(obj as Bet);
                        await CTX.SaveChangesAsync();
                    }
                    break;
                case 1:
                    try
                    {
                        CTX.Die.Add(obj as Die);
                        await CTX.SaveChangesAsync();
                    }
                    catch (ArgumentException)
                    {
                        CTX.Die.Update(obj as Die);
                        await CTX.SaveChangesAsync();
                    }
                    break;
                case 2:
                    try
                    {
                        CTX.Game.Add(obj as Game);
                        await CTX.SaveChangesAsync();
                    }
                    catch (ArgumentException)
                    {
                        CTX.Game.Update(obj as Game);
                        await CTX.SaveChangesAsync();
                    }
                    break;
                case 3:
                    try
                    {
                        CTX.Player.Add(obj as Player);
                        await CTX.SaveChangesAsync();
                    }
                    catch (ArgumentException)
                    {
                        CTX.Player.Update(obj as Player);
                        await CTX.SaveChangesAsync();
                    }
                    break;
                default:
                    throw new TypeAccessException();
            }
        }

        public async Task<G> FindAsync<G>(G findAble) where G: class 
        {
            SaveHelper obj = findAble as SaveHelper;
            switch (obj.CaseID)
            {
                case 0:
                    return await CTX.Bet.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                case 1:
                    return await CTX.Die.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                case 2:
                    return await CTX.Game.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                case 3:
                    return await CTX.Player.SingleOrDefaultAsync(n => n.PrimeKey == obj.PrimeKey) as G;
                default:
                    return default(G);
            }
        }
        public async Task<G> FindAsync<G>(int id) where G : class
        {
            var convertMe = Activator.CreateInstance(typeof(G)) as G;
            SaveHelper type = convertMe as SaveHelper;
            switch (type.CaseID)
            {
                case 0:
                    return await CTX.Bet.SingleOrDefaultAsync(n => n.PrimeKey == id) as G;
                case 1:
                    return await CTX.Die.SingleOrDefaultAsync(n => n.PrimeKey == id) as G;
                case 2:
                    return await CTX.Game.SingleOrDefaultAsync(n => n.PrimeKey == id) as G;
                case 3:
                    return await CTX.Player.SingleOrDefaultAsync(n => n.PrimeKey == id) as G;
                default:
                    return default(G);
            }
        }
        public async Task<List<G>> FindAllAsync<G>() where G : class
        {
            var convertMe = Activator.CreateInstance(typeof(G)) as G;
            SaveHelper type = convertMe as SaveHelper;
            switch (type.CaseID)
            {
                case 0:
                    return await CTX.Bet.ToListAsync() as List<G>;
                case 1:
                    return await CTX.Die.ToListAsync() as List<G>;
                case 2:
                    return await CTX.Game.ToListAsync() as List<G>;
                case 3:
                    return await CTX.Player.ToListAsync() as List<G>;
                default:
                    return default(List<G>);
            }
        }
        public async void DeleteOneAsync<G>(G obj) where G : class
        {
            SaveHelper deleteAble = obj as SaveHelper;
            switch (deleteAble.CaseID)
            {
                case 0:
                    CTX.Bet.Remove(obj as Bet);
                    await CTX.SaveChangesAsync();
                    break;
                case 1:
                    CTX.Die.Remove(obj as Die);
                    await CTX.SaveChangesAsync();
                    break;
                case 2:
                    CTX.Game.Remove(obj as Game);
                    await CTX.SaveChangesAsync();
                    break;
                case 3:
                    CTX.Player.Remove(obj as Player);
                    await CTX.SaveChangesAsync();
                    break;
                default:
                    throw new TypeAccessException();
            }     
        }
        #endregion
    }
}
