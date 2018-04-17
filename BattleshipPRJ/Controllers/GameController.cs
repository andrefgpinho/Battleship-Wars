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
            
            //EspacoOcupado espacoOcupado = new EspacoOcupado();
            
           // ViewBag.Barcos = espacoOcupado.BarcosO;

            // grelhaTeste.Grelha[player.CoordY, player.CoordX] = espacoOcupado.BarcosO[player.CoordY, player.CoordX];
            

            if (ModelState.IsValid)
            {
                return View("Game", jogo);
            }
            else
            {
                return View();
            }

            

        }

        public IActionResult HiScores()
        {
            return View();
        }

        
    }
}