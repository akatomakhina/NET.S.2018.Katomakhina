using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatomakhinaAlgoritnmTask
{
    public class DepthSearch
    {
        private Maze maze;
        //стек нужен для того, чтобы мы могли возвращаться к предыдущей ячейке, когда соседи закончились
        private Stack<Cell> visitedCells = new Stack<Cell>();
        private Cell current;
        private Neighbors neighbors;

        public DepthSearch()
        {
        }

        public DepthSearch(Maze maze)
        {
            this.maze = maze;
            DoVisitedFalse();
            current = maze.MazeProperty[0][0];
            neighbors = new Neighbors(maze);
            neighbors.SetSearching(true);
        }

        public Cell GetCurrent()
        {
            return current;
        }

        public Stack<Cell> GetVisitedCells()
        {
            return visitedCells;
        }

        public void DoSearching()
        {
            //текущей ячейке сетаем, что она посещена
            current.SetVisited(true);
            
            //проверяем соседей для нее
            Cell next = neighbors.Check(current);

            //если соседи есть, то помещаем в стек посещенных первого попавшегося соседа
            if (next != null)
            {
                visitedCells.Push(current);
                next.SetVisited(true);
                current = next;
            }
            //иначе - удаляем текущего, у котрого нет соседей
            else
            {
                current = visitedCells.Pop();
            }

            neighbors = new Neighbors(maze);
            neighbors.SetSearching(true);
        }

        public bool IsEnd()
        {
            return current.I == maze.MazeProperty[0].Length - 1 && current.J == maze.MazeProperty.Length - 1;
        }

        //Сетаем всем ячейкам ложь в качестве статуса посещенности
        private void DoVisitedFalse()
        {
            Cell[][] cells = maze.MazeProperty;
            int rows = cells.Length;
            int cols = cells[0].Length;

            for (int j = 0; j < rows; ++j)
            {
                for (int i = 0; i < cols; ++i)
                {
                    cells[j][i].SetVisited(false);
                }
            }
        }

    }
}
