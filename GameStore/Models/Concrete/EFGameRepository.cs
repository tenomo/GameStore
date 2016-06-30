using GameStore.Models.Abstract;
using System.Collections.Generic;
using System;

namespace GameStore.Models.Concrete
{

    public class EFGameRepository : IGameRepository
    {
        //public EFGameRepository()
        //{
        //     context = new GamestoredbEntities();
        //}
        //GamestoredbEntities context;

        //public IEnumerable<Game> Games
        //{
        //    get
        //    {
        //        return context.games;
        //    }
        //}
        public IEnumerable<Game> Games
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}