using System;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        // True if player 1 and false for player 2
        private static bool _player;
        
        
        private static bool _quit;
        private static string _input;
        private static Grid _grid;
        private static View _display;

        
        public Game()
        {
            _player = true;
            _quit = false;
        }

        public void Start()
        {
            _grid = new Grid();
            _display = new View(_grid);
            
            _display.NextTurn(_player);
            _input = Console.ReadLine();
            Console.WriteLine();
            
        }

        public void NextTurn()
        {
            
            // If user inputs 'q', quit game.
            if (_input == "q")
            {             
                _quit = true;
            }
                
            // Continue with game.
            else
            {

                var gameState = _grid.Insert(_input, _player);
                
                if (gameState == "Winner")
                {
                    _display.Victory(_grid);
                    _quit = true;
                }
                else
                {
                    GameResponse(gameState);
                }
                    
            }
            
        }

        public bool Exit()
        {
            return _quit;
        }

        private static void GameResponse(string gameState)
        {
            
            if (gameState == "Success")
            {
                // Next turn
                _display.ValidMove(_grid);
                _player = !_player;

            }
            else
            {
                _display.Error(gameState);
            }
            
            _display.NextTurn(_player);
            _input = Console.ReadLine();
            Console.WriteLine();
            
        }

    }
}