using GameStore.WUI.Models.Abstract;
using System.Linq;
using System.Web.Mvc;
using GameStore.WUI.Models;

namespace GameStore.WUI.Controllers
{
    public class GameController : Controller
    {
       private IGameRepository repository;
        public int totalPagesCount = 4;

        public GameController(IGameRepository repo)
        {
            // Initialisation across DI controller ninject
            repository = repo;
        }

        

        public ViewResult List(string Category = null, int curemtPageNumber = 1)
        {


            GamesListViewModel gamesListViewModel = new GamesListViewModel
            (
                repository.Games
                .Where(p => Category == null || p.Category == Category)
                .OrderBy(game => game.Id)
                .Skip((curemtPageNumber - 1) * totalPagesCount)
                .Take(totalPagesCount),

                new PagingInfo
                (
                   curemtPageNumber,
                   totalPagesCount,
                  Category == null? repository.Games.Count():
                  repository.Games.Where(game => game.Category == Category).Count()
                ),

                Category
            );


            return View(gamesListViewModel);
        }
    }
}