using System;

namespace TicTacToe
{
    internal class Program
    {
        private static bool _player = true;
        private static bool _quit = false;
        private static string input = "ll";
        
        public static void Main(string[] args)
        {
            var grid = new Grid();
            var game = new View(grid);
            
            game.NextTurn(_player);
            input = Console.ReadLine();
            Console.WriteLine();
            

            while (!_quit)
            {
                
                // If user inputs 'q', quit game.
                if (input == "q")
                {             
                    _quit = true;
                }
                
                // Continue with game.
                else
                {

                    if (grid.Insert(input, _player))
                    {
                        // Next turn
                        game.ValidMove(grid);
                        _player = !_player;
                        game.NextTurn(_player);
                        input = Console.ReadLine();
                        Console.WriteLine();

                    }
                    else
                    {
                        game.Error("InvalidInput");
                        game.NextTurn(_player);
                        input = Console.ReadLine();
                    }
                    
                }
            }

        }
    }
}