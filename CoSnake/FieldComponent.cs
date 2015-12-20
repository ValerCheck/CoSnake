using System;
using System.Collections.Generic;

namespace CoSnake
{
    public class FieldComponent<T> where T: ICell
    {
        private int _width;
        private int _height;

        public T[,] Field;

        public T GetCell(int x, int y)
        {
            return Field[x, y];
        }

        public void SetCell(int x, int y, T value)
        {
            Field[y,x] = value;
        }

        public void AddRow(int y, List<T> row)
        {
            for (int x=0; x < _width; x++)
            {
                SetCell(x,y,row[x]);
            }
        }

        public FieldComponent(int width, int height)
        {
            Field = new T[height,width];
            _width = width;
            _height = height;
        }

        public void SetBorders(T borderCell)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if ( (y > 0 && y <_height - 1) && (x > 0 && x < _width - 1)) continue;
                    SetCell(x,y,borderCell);
                }
            }
        }

        public void SetBorders(T borderCell, bool top, bool right, bool bottom, bool left)
        {
            if (top && left && bottom && right) SetBorders(borderCell);

            if (top) for (int x = 0; x < _width; x++) SetCell(x, 0, borderCell);
            if (bottom) for (int x = 0; x < _width; x++) SetCell(x, _height - 1, borderCell);
            if (left) for (int y = 0; y < _height; y++) SetCell(0, y, borderCell);
            if (right) for (int y = 0; y < _height; y++) SetCell(_width - 1, y, borderCell);
            
        }
    }
}
