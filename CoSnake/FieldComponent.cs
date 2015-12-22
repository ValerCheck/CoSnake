using System;
using System.Collections.Generic;

namespace CoSnake
{
    public class FieldComponent<T> where T: ICell
    {
        private int _width;
        private int _height;

        public T[,] Field;

        public int Width
        {
            get { return _width; }
            private set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            private set { _height = value; }
        }

        public FieldComponent(int width, int height)
        {
            Field = new T[height, width];
            Width = width;
            Height = height;
        }

        public T this[int x, int y]
        {
            get { return Field[y, x]; }
            set { Field[y, x] = value; }

        }

        public T GetCell(int x, int y)
        {
            return Field[x, y];
        }

        public void InsertCell(int x, int y, T value)
        {
            Field[y,x] = value;
        }

        public void AddRow(int y, List<T> row)
        {
            for (int x=0; x < _width; x++)
            {
                InsertCell(x,y,row[x]);
            }
        }
    }
}
