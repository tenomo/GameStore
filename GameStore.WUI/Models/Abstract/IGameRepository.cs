using System.Collections.Generic;

namespace GameStore.WUI.Models.Abstract
{
    public interface IGameRepository
    {
             IEnumerable<Game> Games { get; }
             void SaveGame(Game game);
    }
}