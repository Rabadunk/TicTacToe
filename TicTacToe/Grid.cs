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

        public string Insert(string coordinate, bool player)
        {
            if (!ValidInput(coordinate)) return "InvalidInput";
             
            var i = int.Parse(coordinate[0].ToString()) - 1;
            var j = int.Parse(coordinate[2].ToString()) - 1;

            if (this._grid[i, j] != ".") return "Occupied";
                
            if (player)
            {
                _grid[i, j] = "X";
            }

            else
            {
                this._grid[i, j] = "O";
            }
            
            return WinCheck() ? "Winner" : "Success";
        }

        private bool ValidInput(string coordinate)
        {
            if (coordinate.Length != 3)
            {
                return false;
            }

            if (!int.TryParse(coordinate[0].ToString(), out var i) ||
                !int.TryParse(coordinate[2].ToString(), out var j))
            {
                return false;
            }

            // Checking if the coordinate is within valid range
            return Enumerable.Range(1, 3).Contains(i) && Enumerable.Range(1, 3).Contains(j);
        }

        private bool RowCheck()
        {
            for (var i = 0; i < 3; i++)
            {
                var list = new[] {this._grid[i, 0], this._grid[i, 1], this._grid[i, 2]};
                var allAreSame = list.All(x => x == list.First() && x != ".");
                
                if (allAreSame) return true;
            }

            return false;
        }

        private bool ColCheck()
        {
            for (var j = 0; j < 3; j++)
            {
                var list = new[] {this._grid[0, j], this._grid[1, j], this._grid[2, j]};
                var allAreSame = list.All(x => x == list.First() && x != ".");

                if (allAreSame) return true;
            }

            return false;
        }

        private bool DiagonalCheck()
        {
            var list = new[] {this._grid[0, 0], this._grid[1, 1], this._grid[2, 2]};
            var allAreSame = list.All(x => x == list.First() && x != ".");
    
            if (allAreSame) return true;

            var nextList = new[] {this._grid[0, 2], this._grid[1, 1], this._grid[2, 0]};
            var nextAllAreSame = nextList.All(x => x == nextList.First() && x != ".");
            
            return nextAllAreSame;
        }

        private bool WinCheck()
        {
            return ColCheck() || RowCheck() || DiagonalCheck();
        }



    }
}