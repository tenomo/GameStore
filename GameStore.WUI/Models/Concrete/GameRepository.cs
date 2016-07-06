using System.Collections.Generic;
using System.Configuration;
using GameStore.WUI.Models.Abstract;

namespace GameStore.WUI.Models.Concrete
{

    public class GameRepository : IGameRepository
    {
      private  GameStoreDataBaseEntities context;
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
       }
    }
