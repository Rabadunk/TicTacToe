﻿using System;

namespace TicTacToe
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            
            var game = new Game();
            
            game.Start();

            while (!game.Exit())
            {
                game.NextTurn();
            }

        }
    }
}