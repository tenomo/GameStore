using System;
using System.Collections.Generic;
using System.Configuration;
using GameStore.WUI.Models.Abstract;

namespace GameStore.WUI.Models.Concrete
{

    public class GameRepository : IGameRepository
    {
        private GameStoreDataBaseEntities context;
        public GameRepository()
        {
            context = new GameStoreDataBaseEntities();
        }

        public IEnumerable<Game> Games
        {
            get
            {
                return context.Games;
            }
        }

        public void SaveGame(Game game)
        {
            if (game.Id == 0)
                context.Games.Add(game);
            else
            {
                Game dbEntry = context.Games.Find(game.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Description = game.Description;
                    dbEntry.Price = game.Price;
                    dbEntry.Category = game.Category;                    
                }
            }          
                context.SaveChanges();           
         
        }
    }
}

