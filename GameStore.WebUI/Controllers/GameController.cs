using System;
using System.Web.Mvc;

namespace GameStore.WebUI
{
    public class GameController : Controller
    {
        // GET: Game

        GameStore.Models.Abstract.IGameRepository gameRepository;

         
        public GameController(GameStore.Models.Abstract.IGameRepository repo)
        {
            gameRepository = repo;
        }

        public ViewResult List()
        {

            if (gameRepository == null)
                throw new Exception(gameRepository.ToString());
            return View(this.gameRepository);
        }
    }
}
