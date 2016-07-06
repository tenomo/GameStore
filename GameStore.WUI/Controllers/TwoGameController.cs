using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.WUI.Controllers
{
    public class TwoGameController : Controller
    {
        GameStore.WUI.Models.GameStoreDataBaseEntities context = new Models.GameStoreDataBaseEntities();
        // GET: TwoGame
        public ActionResult Index()
        {
            List<GameStore.WUI.Models.Game> games = new
                List<Models.Game>(context.Game);
            return View(games);
        }
    }
}