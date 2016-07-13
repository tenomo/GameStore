using GameStore.WUI.Models;
using GameStore.WUI.Models.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace GameStore.WUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
       private IGameRepository gameRepository;

        public AdminController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        // GET: Admin
        public ViewResult Index()
        {
            return View(this.gameRepository.Games);
        }

        /// <summary>
        /// Edit item GameRepository by id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ViewResult Edit(int Id)
        {
            Game game = gameRepository.Games
                .FirstOrDefault(g => g.Id == Id);
            return View(game);
        }

        //The supercharged version Edit() to save the changes
        /// <summary>
        /// Edit item GameRepository by incoming specimens of objects.
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                gameRepository.SaveGame(game);
                TempData["message"] = string.Format("Изменения в игре \"{0}\" были сохранены", game.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(game);
            }
        }

        // Метод Create создает новый обьект  Game и делегирует дальнейшую работу с ним методу Edit 
        public ViewResult Create ( )
        {
            return View("Edit", new Game());
        }


        [HttpPost]
        public ActionResult Delete(int gameId)
        {
            Game deletedGame = this.gameRepository.DeleteGame(gameId);
            if (deletedGame != null)
            {
                TempData["message"] = string.Format("Игра \"{0}\" была удалена",
                    deletedGame.Name);
            }
            return RedirectToAction("Index");
        }
    }
}