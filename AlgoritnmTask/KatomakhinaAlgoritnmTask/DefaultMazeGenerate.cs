using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatomakhinaAlgoritnmTask
{
    class DefaultMazeGenerate
    {
        private Stack<Cell> visitedCells = new Stack<Cell>();
        private Neighbors neighbors;
        private Maze maze;
        private Cell current;
        private int rows = 6;
        private int cols = 6;

        public DefaultMazeGenerate()
        {

        }

        public DefaultMazeGenerate(int rows, int cols)
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

        //по строкам
        private void GenerateCells()
        {
            Cell[][] cells = new Cell[rows][];
            for (int j = 0; j < rows; j++)
            {
                cells[j] = new Cell[cols];
            }
            cells[0][0] = new Cell(0, 0, new bool[] { true, true, false, false }, false);
            cells[1][0] = new Cell(0, 0, new bool[] { true, false, false, true }, false);
            cells[2][0] = new Cell(0, 0, new bool[] { true, false, true, false }, false);
            cells[3][0] = new Cell(0, 0, new bool[] { true, true, false, false }, false);
            cells[4][0] = new Cell(0, 0, new bool[] { true, false, true, true }, false);
            cells[5][0] = new Cell(0, 0, new bool[] { true, true, false, false }, false);

            cells[0][1] = new Cell(0, 0, new bool[] { false, true, false, true }, false);
            cells[1][1] = new Cell(0, 0, new bool[] { false, false, true, true }, false);
            cells[2][1] = new Cell(0, 0, new bool[] { true, true, false, false }, false);
            cells[3][1] = new Cell(0, 0, new bool[] { false, false, true, true }, false);
            cells[4][1] = new Cell(0, 0, new bool[] { true, false, true, false }, false);
            cells[5][1] = new Cell(0, 0, new bool[] { false, true, true, false }, false);

            cells[0][2] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[1][2] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[2][2] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[3][1] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[4][2] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[5][2] = new Cell(0, 0, new bool[] { true, true, true, true }, false);

            cells[0][3] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[1][3] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[2][3] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[3][3] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[4][3] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[5][3] = new Cell(0, 0, new bool[] { true, true, true, true }, false);

            cells[0][4] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[1][4] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[2][4] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[3][4] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[4][4] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[5][4] = new Cell(0, 0, new bool[] { true, true, true, true }, false);

            cells[0][5] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[1][5] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[2][5] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[3][5] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[4][5] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            cells[5][5] = new Cell(0, 0, new bool[] { true, true, true, true }, false);
            maze = new Maze(cells);
        }
    }
}
