using System;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class Grid
    {
        private readonly string[,] _grid;

        public Grid()
        {
            this._grid = new string[3, 3]
            {
                {".", ".", "."},
                {".", ".", "."},
                {".", ".", "."}
            };
        }

        public void PrintGrid()
        {
            for (var i = 0; i < 3; i++)
            {

                for (var j = 0; j < 3; j++)
                {
                    
                    Console.Write(this._grid[i, j]);
                    Console.Write(" ");
                    
                }
                
                Console.Write("\n");

            }
        }

        public bool Insert(string coordinate, bool player)
        {
            if (!Check(coordinate)) return false;
            
            var i = int.Parse(coordinate[0].ToString()) - 1;
            var j = int.Parse(coordinate[2].ToString()) - 1;
                
            if (player)
            {
                _grid[i, j] = "X";
            }

            else
            {
                this._grid[i, j] = "O";
            }

            return true;


        }

        private bool Check(string coordinate)
        {
            if (coordinate.Length != 3)
            {
                return false;
            }

            var i = int.Parse(coordinate[0].ToString());
            var j = int.Parse(coordinate[2].ToString());
            
            // Checking if there's an empty position
            // in the grid for the input.
            if (this._grid[i - 1, j - 1] != ".")
            {
                return false;
            }

            return Enumerable.Range(1, 3).Contains(i) && Enumerable.Range(1, 3).Contains(j);
        }


    }
}