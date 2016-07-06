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
       private IGameRepository repository;
        public int pageSize = 4;
        public GameController(IGameRepository repo)
        {
            repository = repo;
        }

        // GET: TwoGame
        public ActionResult List(int page)
        {
            //List<GameStore.WUI.Models.Game> games = new
            //    List<Models.Game>( repository.Games);


            return View(
                repository.Games
                .OrderBy(game=>game.Id)
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                );
        }
    }
}