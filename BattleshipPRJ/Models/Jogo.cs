﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BattleshipPRJ.Models
{
    public class Jogo
    {
        private static int heidi = 0;

        [Required(ErrorMessage = "Por favor preenche o campo Nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor seleciona a missão pretendida!")]
        public string Missao { get; set; }

        public int ID { get; set; }

        public int Misseis { get; set; }

        public double Score { get; set; }

        public int Coordx { get; set; }

        public int Coordy { get; set; }

        public int Portaavioesrest { get; set; }

        public int Quatrocanosrest { get; set; }

        public int Trescanosrest { get; set; }

        public int Doiscanosrest { get; set; }

        public int Submanrinosrest { get; set; }

        public int Quadradosabater { get; set; }

        public int UltimoTiroDisparado { get; set; }

        public int NumeroDeJogadas { get; set; }

        public bool Barcoaofundo { get; set; }

        public bool TiroNaMesmaCoord { get; set; }

        public string ResultadoJogada { get; set; }

        public string FimdoJogo { get; set; }



        private int[,] grelha;



        public int[,] Grelha
        {
            get
            {
                return grelha;
            }

        }


        public string ReceberResult(Resultado result)
        {

            if (result == Resultado.SuccessHit)
            {
                return "Tiro num barco de ";

            }
            else if (result == Resultado.SuccessMiss)
            {
                return "Água!";
            }
            else if (result == Resultado.SuccessSink)
            {
                return "Afundaste um barco de ";
            }
            else if (result == Resultado.SuccessRepeat)
            {
                return "Tiro em coordenadas repetidas!";
            }
            else if (result == Resultado.SuccessVictory)
            {
                return "Ganhaste ao afundar o último barco, parabéns!";
            }
            else if (result == Resultado.InvalidShot)
            {
                return "Tiro Inválido!";
            }
            else
            {
                return "Começa por disparar num quadrado!";
            }

        }


        public void AltMissao()
        {
            if (Missao == "Antiaérea")
            {
                Misseis = 20;
                Quadradosabater = 5;

            }
            else
            {

                Misseis = 50;
                Quadradosabater = 25;

            }

        }
        
        public Jogo()
        {
            heidi++;
            

            ID = heidi;

            Portaavioesrest = 1;
            Quatrocanosrest = 1;
            Trescanosrest = 2;
            Doiscanosrest = 3;
            Submanrinosrest = 4;


            grelha = new int[10, 10]
            {
                //valores reservados:
                //-1=desconhecido (jogador não atirou aqui)
                //0=água; 1,2,3,4,5=barco de n canos
                //outros valores: não usados (pode definir o que quiser caso necessite)


                //nesta grelha de teste mostramos alguns quadrados marcados com água e outros com barcos
                //esta disposição não apareceria no jogo pois não há barcos de 4 canos com este formato
                { -1,-1,-1,-1,-1,-1,-1,-1,-1, -1},
                {-1, -1,-1,-1,-1,-1,-1,-1, -1,-1},
                {-1,-1, -1, -1, -1, -1, -1, -1,-1,-1},
                {-1,-1, -1,-1,-1,-1,-1, -1,-1,-1},
                {-1,-1, -1,-1, -1, -1,-1, -1,-1,-1},
                {-1,-1, -1,-1, -1, -1,-1, -1,-1,-1},
                {-1,-1, -1,-1,-1,-1,-1, -1,-1,-1},
                {-1,-1, -1, -1, -1, -1, -1, -1,-1,-1},
                {-1, -1,-1,-1,-1,-1,-1,-1, -1,-1},
                { -1,-1,-1,-1,-1,-1,-1,-1,-1, -1}
            };

        }

        public void Disparou(int Tiro, bool ganho,bool BarcoAoFundo)
        {
            Misseis = Misseis - 1;
            UltimoTiroDisparado = Tiro;
            NumeroDeJogadas = NumeroDeJogadas + 1;
            if (Tiro == 1 || Tiro == 2 || Tiro == 3 || Tiro == 4 || Tiro==5)
            {
                if (ganho == false)
                {
                    Hi_score.AdicionarJogada(true, BarcoAoFundo, false, false, 0);
                    Quadradosabater = Quadradosabater - 1;
                }
                else
                {
                    Hi_score.AdicionarJogada(true, BarcoAoFundo, false, true, Misseis);
                    Quadradosabater = Quadradosabater - 1;
                }
            }
            else
            {
                Hi_score.AdicionarJogada(false, false, false, false, 0);
            }
            Score = Hi_score.Receber();
            Barcoaofundo = BarcoAoFundo;
        }

        public void DisparouNasMesmasCoords()
        {
            Misseis = Misseis - 1;
            NumeroDeJogadas = NumeroDeJogadas + 1;
            Hi_score.AdicionarJogada(false, false, true, false, 0);
            Score = Hi_score.Receber();
            Barcoaofundo = false;
        }

        
    }
}
