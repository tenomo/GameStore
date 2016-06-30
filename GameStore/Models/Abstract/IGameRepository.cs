using GameStore.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Models.Abstract
{
    public interface IGameRepository
    {
            IEnumerable<Game> Games { get; }
    }
}