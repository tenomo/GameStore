using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        // GET: Game

        GameStore.Models.Abstract.IGameRepository gameRepository =
            new GameStore.Models.Concrete.EFGameRepository();


        public ActionResult Index()
        {
            // test 
            ViewBag.text = "text";

            //
            return View();
        }
    }
}