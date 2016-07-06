using GameStore.Domian.DataBaseProvider;
using System.Collections.Generic;
    using System.Configuration;
using GameStore.Models.Abstract;

namespace GameStore.Domian.Concrete
{

    public class GameRepository : IGameRepository
    {
        GameStoreDataBaseEntities context;
        public GameRepository()
        {
            context = new GameStoreDataBaseEntities(
                ConfigurationManager.ConnectionStrings[0].ConnectionString);
        }
        public GameRepository( string connectionString)
        {
            context = new GameStoreDataBaseEntities(connectionString);
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
