using System;

namespace TicTacToe
{
    public class View
    {

        public View(Grid grid)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();
            Console.WriteLine("Here's the current board: ");
            Console.WriteLine();
            grid.PrintGrid();
            Console.WriteLine();
        }

        public void NextTurn(bool player)
        {
            switch (player)
            {
                case true:
                    Console.Write("Player 1 enter a coord x,y to place your X or enter 'q' to give up: ");
                    break;
                case false:
                    Console.Write("Player 2 enter a coord x,y to place your O or enter 'q' to give up: ");
                    break;
                default:
                    Console.Write("Sorry, an error has occured! Contact game dev.");
                    break;
            }
        }

        public void Error(string error)
        {
            if (error == "InvalidInput")
            {
                Console.WriteLine("Sorry that is an invalid coordinate!");
                Console.WriteLine("Your coordinates must be between 1 and 3.");
                Console.WriteLine("An example coordinate is \"1,3\", please try again... ");
                Console.WriteLine();
            }
            
            else if (error == "Occupied")
            {
                Console.WriteLine("Oh no, a piece is already at this place! Try again...");
                Console.WriteLine();
            }
        }

        public void ValidMove(Grid grid)
        {
            Console.WriteLine("Move accepted, here's the current board: ");
            Console.WriteLine();
            grid.PrintGrid();
            Console.WriteLine();
        }

        public void Victory(Grid grid)
        {
            Console.WriteLine("Move accepted, well done you've won the game!");
            Console.WriteLine();
            grid.PrintGrid();
        }

    }
}