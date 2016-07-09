using GameStore.WUI.Models;
using GameStore.WUI.Models.Abstract;
using GameStore.WUI.Models.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GameStore.WUI.Controllers
{
    public class CartController : Controller
    {
        private IGameRepository repository;

        public CartController(IGameRepository repo)
        {
            // Initialisation across DI controller ninject
            repository = repo;
        }


        // Cart инициализируеться с использованием CartModelBinder в  
        // Global в методе Application_Start() класа MvcApplication 

        public ViewResult Index( Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel(cart, returnUrl));             
        }

        /// <summary>
        /// Added element in cart wich id and returns url sesion client.
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games.FirstOrDefault(g => g.Id == gameId);

            if (game != null)
            {
                cart.AddItem(game, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Removes element in cart wich id and returns url sesion client.
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(Cart cart, int gameId, string returnUrl)
        {
            Game game = repository.Games.FirstOrDefault(g => g.Id == gameId);

            if (game != null)
            {
                cart.RemoveLine(game);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}
