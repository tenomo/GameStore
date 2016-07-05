using GameStore.Domian.DataBaseProvider;
using System.Collections.Generic;

namespace GameStore.Models.Abstract
{
    public interface IGameRepository
    {
             IEnumerable<Game> Games { get; }
    }
}