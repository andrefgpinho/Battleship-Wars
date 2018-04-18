﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BattleshipPRJ.Models;



namespace BattleshipPRJ.Controllers
{

    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult NovoJogo()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult NovoJogo(Jogo jogo)
        {
            

            //jogo.Grelha[5,5] = 0;
            

            if (ModelState.IsValid)
            {
                return View("Game", jogo);
            }
            else
            {
                return View();
            }

            

        }
        

        [HttpGet]
        public IActionResult Game()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Game(Jogo jogo)
        {
            return View(jogo);

        }



        public IActionResult HiScores()
        {
            return View();
        }

        
    }
}