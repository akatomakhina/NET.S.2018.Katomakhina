using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatomakhinaAlgoritnmTask
{
    public class MazeGenerator
    {
        private Stack<Cell> visitedCells = new Stack<Cell>();
        private Neighbors neighbors;
        private Maze maze;
        private Cell current;
        private int rows;
        private int cols;

        public MazeGenerator()
        {

        }

        public MazeGenerator(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            GenerateCells();
            current = maze.MazeProperty[0][0];
            neighbors = new Neighbors(maze);
        }

        public Maze getMaze()
        {
            return maze;
        }

        public Cell Current
        {
            get;
        }

        public void GenerateMaze()
        {
            do
            {
                current.SetVisited(true);
                Cell next = neighbors.Check(current);

                if (next != null)
                {
                    visitedCells.Push(current);
                    next.SetVisited(true);
                    RemoveWalls(current, next);
                    current = next;
                }
                else if (visitedCells.Count != 0)
                {
                    current = visitedCells.Pop();
                }

                neighbors = new Neighbors(maze);
            } while (visitedCells.Count != 0);
        }

        public bool IsGenerated()
        {
            return current.I == 0 && current.J == 0;
        }

        //инициализируем все ячейки для лабиринта со всеми границами и непосещенными
        private void GenerateCells()
        {
            Cell[][] cells = new Cell[rows][];
            for (int j = 0; j < rows; j++)
            {
                cells[j] = new Cell[cols];
                for (int i = 0; i < cols; i++)
                {
                    cells[j][i] = new Cell(i, j, new bool[] { true, true, true, true }, false);
                }
            }
            maze = new Maze(cells);
        }

        //x - границы слева и справа, y - стены сверху и снизу
        private void RemoveWalls(Cell current, Cell neighbor)
        {
            int x = current.I - neighbor.I;

            if (x == 1)
            {
                current.Walls[3] = false;
                neighbor.Walls[1] = false;
                return;
            }
            else if (x == -1)
            {
                current.Walls[1] = false;
                neighbor.Walls[3] = false;
                return;
            }

            int y = current.J - neighbor.J;
            if (y == 1)
            {
                current.Walls[0] = false;
                neighbor.Walls[2] = false;
            }
            else if (y == -1)
            {
                current.Walls[2] = false;
                neighbor.Walls[0] = false;
            }
        }
    }
}
