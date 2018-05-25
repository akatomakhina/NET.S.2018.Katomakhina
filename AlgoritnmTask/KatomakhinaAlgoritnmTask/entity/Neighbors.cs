using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatomakhinaAlgoritnmTask
{
    //класс описывает сущность Соседи
    //содержит массив ячеек, могут быть ячейки с четырех сторон: сверху, справа, снизу, слева
    //список содержит соседей ячейки

    public class Neighbors
    {
        private bool isSearching;
        private Cell[][] cells;
        private Cell top;
        private Cell right;
        private Cell bottom;
        private Cell left;
        private List<Cell> neighbors = new ArrayList<Cell>();

        public Neighbors()
        {
        }

        public Neighbors(Maze maze)
        {
            cells = maze.MazeProperty;
        }

        public void SetSearching(bool searching)
        {
            isSearching = searching;
        }

        //метод добавляет соседей для ячейки (сверху, справа, снизу, слева)
        private void InitNeighborCells(Cell cell)
        {
            int i = cell.I;
            int j = cell.J;            
            int rows = cells.Length;
            int cols = cells[0].Length;

            if (!isSearching)
            {
                if (IsValidNeighbors(j - 1, i, rows, cols))
                {
                    top = cells[j - 1][i];
                }
                if (IsValidNeighbors(j, i + 1, rows, cols))
                {
                    right = cells[j][i + 1];
                }
                if (IsValidNeighbors(j + 1, i, rows, cols))
                {
                    bottom = cells[j + 1][i];
                }
                if (IsValidNeighbors(j, i - 1, rows, cols))
                {
                    left = cells[j][i - 1];
                }
            }
            else
            {
                if (IsValidNeighbors(j - 1, i, rows, cols) && !cell.Walls[0])
                {
                    top = cells[j - 1][i];
                }
                if (IsValidNeighbors(j, i + 1, rows, cols) && !cell.Walls[1])
                {
                    right = cells[j][i + 1];
                }
                if (IsValidNeighbors(j + 1, i, rows, cols) && !cell.Walls[2])
                {
                    bottom = cells[j + 1][i];
                }
                if (IsValidNeighbors(j, i - 1, rows, cols) && !cell.Walls[3])
                {
                    left = cells[j][i - 1];
                }
            }
        }

        public Cell Check(Cell cell)
        {
            InitNeighborCells(cell);

            AddNeighbor(top);
            AddNeighbor(right);
            AddNeighbor(bottom);
            AddNeighbor(left);

            int size = neighbors.Count;

            if (size > 0)
            {
                int r = new Random().Next(size);
                return neighbors[r];
            }
            else
            {
                return null;
            }
        }

        //валидация ячейки-соседа (чтобы не выходила за границы)
        private bool IsValidNeighbors(int i, int j, int rows, int cols)
        {
            return !(i < 0 || j < 0 || i > cols - 1 || j > rows - 1);
        }

        //добавление соседа
        //если не равна нулю и если посещена
        private void AddNeighbor(Cell cell)
        {
            if (cell != null && !cell.IsVisited())
            {
                neighbors.Add(cell);
            }
        }

        private class ArrayList<T> : List<Cell>
        {
        }
    }
}
