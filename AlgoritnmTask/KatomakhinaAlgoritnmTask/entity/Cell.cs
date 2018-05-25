using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatomakhinaAlgoritnmTask
{
    //класс, описывающий сущность Ячейка
    //ячейка может иметь стену (с одной из четырех сторон)
    //может иметь состояние, когда мы проходим, - посещена она или нет

    public class Cell
    {
        private int i;
        private int j;
        private bool[] walls;
        private bool visited;

        public Cell()
        {
        }

        public Cell(int i, int j)
        {
            this.i = i;
            this.j = j;
        }

        public Cell(int i, int j, bool[] walls, bool visited)
        {
            this.i = i;
            this.j = j;
            this.walls = walls;
            this.visited = visited;
        }

        public int I
        {
            get;
            set;
        }

        public int J
        {
            get;
            set;
        }

        public bool[] Walls
        {
            get;
            set;
        }

        public bool IsVisited()
        {
            return visited;
        }

        public void SetVisited(bool visited)
        {
            this.visited = visited;
        }
    }
}
