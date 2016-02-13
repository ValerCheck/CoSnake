using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CoSnake.Tests
{
    [TestFixture]
    public class SnakeTests
    {
        [Test]
        public void SnakeCreationInDefaultPositionWithHead()
        {
            var snake = new Snake(0, 0);
            Assert.IsTrue(snake.Head.X == 0);
            Assert.IsTrue(snake.Head.Y == 0);
            Assert.IsNull(snake.Head.Next);
        }

        [TestCase(MoveDirection.Right,2,1)]
        [TestCase(MoveDirection.Up,1,0)]
        [TestCase(MoveDirection.Left,0,1)]
        [TestCase(MoveDirection.Down,1,2)]
        public void SnakeMoveInEachDirectionCorrect(MoveDirection changeDirection, int resultX, int resultY)
        {
            var snake = new Snake(1, 1);

            snake.ChangeDirection(changeDirection);
            snake.Move();
            Assert.IsTrue(snake.Head.X == resultX);
            Assert.IsTrue(snake.Head.Y == resultY);
            Assert.IsNull(snake.Head.Next);
        }

        [Test]
        public void SnakeEatAndGrowth()
        {
            var snake = new Snake(0, 0);
            snake.Move();
            snake.Eat();
            Assert.IsTrue(snake.Head.X == 0);
            Assert.IsTrue(snake.Head.Y == 1);
            Assert.IsTrue(snake.Tail.X == 0);
            Assert.IsTrue(snake.Tail.Y == 0);
        }

        [Test]
        public void SnakeEatGrowthAndMove()
        {
            var snake = new Snake(0, 0);
            snake.Move();
            snake.Eat();
            snake.Move();
            Assert.IsTrue(snake.Head.X == 0);
            Assert.IsTrue(snake.Head.Y == 2);
            Assert.IsTrue(snake.Tail.X == 0);
            Assert.IsTrue(snake.Tail.Y == 1);
        }

        [Test]
        public void SnakeEatTwiceGrowthMoveAndChangeDirection()
        {
            var snake = new Snake(0, 0);
            snake.Move();
            snake.Eat();
            snake.Move();
            snake.Eat();
            snake.ChangeDirection(MoveDirection.Right);
            snake.Move();
            Assert.IsTrue(snake.Head.X == 1);
            Assert.IsTrue(snake.Head.Y == 2);
            Assert.IsTrue(snake.Tail.X == 0);
            Assert.IsTrue(snake.Tail.Y == 1);
        }
    }
}
