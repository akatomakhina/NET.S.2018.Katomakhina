using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatomakhinaAlgoritnmTask
{
    //класс, описывающий сущность Лабиринт - это граф
    //состоит из ячеек - вершин

    public class Maze
    {
        private Cell[][] cells;

        public Maze()
        {
        }

        public Maze(Cell[][] cells)
        {
            this.cells = cells;
        }

        public Cell[][] MazeProperty
        {
            get;
            set;
        }
    }
}
