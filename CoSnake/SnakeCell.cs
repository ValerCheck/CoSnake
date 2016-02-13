namespace CoSnake
{
    public class SnakeCell
    {
        public int X;
        public int Y;
        private SnakeCell _nextCell;
        private MoveDirection _direction;

        public MoveDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public SnakeCell Next
        {
            get { return _nextCell; }
            set { _nextCell = value; }
        }

        public SnakeCell()
        {
            _nextCell = null;
        }

        public SnakeCell(SnakeCell nextCell)
        {
            _nextCell = nextCell;
        }

        public SnakeCell(int x, int y, SnakeCell nextCell):this(nextCell)
        {
            X = x;
            Y = y;
        }
    }
}
