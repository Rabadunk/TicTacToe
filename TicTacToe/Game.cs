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
            const string endGame = "q";
            if (_input == endGame)
            {             
                _quit = true;
            }
            
            else
            {
                var gameState = _grid.Insert(_input, _player);    
                GameResponse(gameState);                    
            }
        }

        public bool Exit()
        {
            
            if(_quit) _display.Exit();
            
            return _quit;
        }

        private static void GameResponse(string gameState)
        {
            
            switch (gameState)
            {
                case "Winner":
                    _display.Victory(_grid);
                    _quit = true;
                    return;
                case "Success":
                    // Next turn
                    _display.ValidMove(_grid);
                    _player = !_player;
                    break;
                default:
                    _display.Error(gameState);
                    break;
            }

            _display.NextTurn(_player);
            _input = Console.ReadLine();
            Console.WriteLine();
            
        }

    }
}