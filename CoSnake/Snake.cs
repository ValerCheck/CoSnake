using System;
using System.Collections.Generic;

namespace CoSnake
{
    public class Snake
    {
        private Dictionary<MoveDirection,Func<SnakeCell, SnakeCell, SnakeCell>> _pushMethods = 
            new Dictionary<MoveDirection, Func<SnakeCell, SnakeCell, SnakeCell>>()
            {
                {MoveDirection.Up, (growthCell, tail) =>
                {
                    growthCell.X = tail.X;
                    growthCell.Y = tail.Y + 1;
                    return growthCell;
                }},
                {MoveDirection.Down, (growthCell, tail) =>
                {
                    growthCell.X = tail.X;
                    growthCell.Y = tail.Y -1;
                    return growthCell;
                }},
                {MoveDirection.Left, (growthCell, tail) =>
                {
                    growthCell.X = tail.X + 1;
                    growthCell.Y = tail.Y;
                    return growthCell;
                }},
                {MoveDirection.Right, (growthCell, tail) =>
                {
                    growthCell.X = tail.X - 1;
                    growthCell.Y = tail.Y;
                    return growthCell;
                }}
            }; 

        private List<SnakeCell> _body = new List<SnakeCell>();
        private SnakeCell _head;
        private SnakeCell _tail;

        public int SnakeLength
        {
            get { return _body.Count; }
        }

        public SnakeCell Head
        {
            get { return _head; }
        }

        public SnakeCell Tail
        {
            get { return _tail; }
        }

        public void ChangeDirection(MoveDirection direction)
        {
            if (direction != MoveDirection.Default) _head.Direction = direction;
        }

        public Snake(int stX, int stY)
        {
            _head = new SnakeCell {X = stX, Y = stY};
            _tail = _head;
            _body.Add(_head);
            _head.Direction = MoveDirection.Down;
            _tail.Direction = _head.Direction;
        }

        public void Eat()
        {
            var growthCell = new SnakeCell(_tail);
            if (_head.Direction == MoveDirection.Stop || _tail.Direction == MoveDirection.Stop) return;
            growthCell = _pushMethods[_tail.Direction](growthCell, _tail);
            _body.Add(growthCell);
            _tail = growthCell;
        }

        public void Move()
        {
            var toReplace = _tail;
            _tail = _tail.Next ?? _head;
            switch (_head.Direction)
            {
                case MoveDirection.Up:
                    SetXY(toReplace, _head.X, _head.Y - 1);
                    break;
                case MoveDirection.Down:
                    SetXY(toReplace, _head.X, _head.Y + 1);
                    break;
                case MoveDirection.Left:
                    SetXY(toReplace, _head.X - 1, _head.Y);
                    break;
                case MoveDirection.Right:
                    SetXY(toReplace, _head.X + 1, _head.Y);
                    break;
                default:
                    SetXY(toReplace, _head.X, _head.Y);
                    break;
            }
            _head.Next = toReplace.Next == null ? null : toReplace;
            toReplace.Direction = _head.Direction;
            _head = toReplace;
            
        }

        private void MoveXY(SnakeCell cell, int dX, int dY)
        {
            cell.X += dX;
            cell.Y += dY;
        }

        private void SetXY(SnakeCell cell, int x, int y)
        {
            cell.X = x;
            cell.Y = y;
        }
    }
}
