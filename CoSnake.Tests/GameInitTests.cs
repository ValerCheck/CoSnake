using NUnit.Framework;

namespace CoSnake.Tests
{
    [TestFixture]
    public class GameInitTests
    {
        const int WIDTH = 30;
        const int HEIGHT = 20;

        [Test]
        public void GameDisplayWelcomeMessageCorrect()
        {
            var game = new ConsoleGame("CoSnake");
            Assert.IsTrue(game.CurrentState.Contains("Welcome, player!"));
            Assert.IsTrue(game.CurrentState.Contains("This is CoSnake"));
            Assert.IsTrue(game.CurrentState.Contains("Press Enter to start game"));
        }

        [Test]
        public void GameFieldInitializedWhenPressedEnter()
        {
            var game = new ConsoleGame("CoSnake",WIDTH, HEIGHT);
            game.DrawField();
            Assert.IsTrue(game.CurrentState.Length == WIDTH * HEIGHT);
            Assert.IsTrue(game.CurrentState.Contains("@"));
        }
    }
}
