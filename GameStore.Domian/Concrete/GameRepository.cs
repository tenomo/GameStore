using GameStore.Domian.DataBaseProvider;
using System.Collections.Generic;
using GameStore.Models.Abstract;

namespace GameStore.Domian.Concrete
{

    public class GameRepository : IGameRepository
    {
        GameStoreDataBaseEntities context;
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
