using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoSnake
{
    public class GameCell : ICell
    {
        private object _content;

        public GameCell(object content)
        {
            _content = content;
        }

        public object Content()
        {
            return _content;
        }
    }
}
