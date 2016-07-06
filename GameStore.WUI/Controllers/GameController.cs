using System;
using System.Web.Mvc;

namespace GameStore.WebUI.Controllers
{
    public class GameController : Controller
    {
        // GET: Game

        GameStore.Models.Abstract.IGameRepository  gameRepository = 
            new GameStore.Domian.Concrete.GameRepository(
                System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString);

         
        public GameController(GameStore.Models.Abstract.IGameRepository repo)
        {
            gameRepository = repo;
        }

        public ActionResult List()
        {

            //if (gameRepository == null)
            //    gameRepository = new GameStore.Domian.Concrete.GameRepository();
           
            return View(this.gameRepository.Games);
        }
    }
}
