﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStore.Controllers
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
