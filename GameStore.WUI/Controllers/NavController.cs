using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GameStore.WUI.Models.Abstract;
namespace GameStore.WUI.Controllers
{
    public class NavController : Controller
    {
        IGameRepository gameRepositorye;

        public NavController(IGameRepository gameRepository)
        {
            // Initialisation across DI controller ninject
            this.gameRepositorye = gameRepository;
        }
        

        // GET: Nav

            /// <summary>
            /// Selected, sorted and returned catego
            /// </summary>
            /// <param name="category"></param>
            /// <returns></returns>
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;


            IEnumerable<string> categories = gameRepositorye.Games
              .Select(game => game.Category)
              .Distinct()
              .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}