using GameStore.WUI.Models;
using GameStore.WUI.Models.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace GameStore.WUI.Controllers
{
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
        public ViewResult Edit(int gameId)
        {
            Game game = gameRepository.Games
                .FirstOrDefault(g => g.Id == gameId);
            return View(game);
        }

        // Перегруженная версия Edit() для сохранения изменений
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

    }
}