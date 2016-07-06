using GameStore.WUI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.WUI.Controllers
{
    public class GameController : Controller
    {
        GameStore.WUI.Models.Abstract.IGameRepository repository;// = new Models.GameStoreDataBaseEntities();
        public GameController(IGameRepository repo)
        {
            repository = repo;
        }

        // GET: TwoGame
        public ActionResult List()
        {
            List<GameStore.WUI.Models.Game> games = new
                List<Models.Game>( repository.Games);
            return View(games);
        }
    }
}