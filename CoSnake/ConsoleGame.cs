using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CoSnake
{
    public class ConsoleGame
    {
        private string _gameName;
        private int _sceneWidth;
        private int _sceneHeight;
        private string _currentState = "";
        private List<string> _gameField = new List<string>();
        private Snake _player;
        private int _playerStartX = 0;
        private int _playerStartY = 0;
        private string _snakeCellView = "@";

        public ConsoleGame(string name, int sceneWidth = 100, int sceneHeight = 100)
        {
            _sceneHeight = sceneHeight;
            _sceneWidth = sceneWidth;
            _gameName = name;
            CreateWelcomeMessage();
            _currentState = _gameField.Aggregate((result, next) => result + "\n" + next);
            foreach (var line in _gameField) Console.WriteLine(line);
            _player = new Snake(_playerStartX, _playerStartY);
        }

        public string CurrentState
        {
            get { return _currentState; }
        }

        public void DrawField()
        {
            _gameField.Clear();
            for (int i = 0; i < _sceneHeight; i++)
            {
                _gameField.Add(new string(' ', _sceneWidth));
            }
            PutSnakeOnMap();
            _currentState = _gameField.Aggregate((result, next) => result + "\n" + next);
        }

        private void PutSnakeOnMap()
        {
            var snakeCell = _player.Tail;
            while (snakeCell != null)
            {
                var st1 = _gameField[snakeCell.Y].Remove(snakeCell.X,1);
                var st2 = st1.Insert(snakeCell.X, _snakeCellView);

                _gameField[snakeCell.Y] = st2;
                snakeCell = snakeCell.Next;
            }
        }

        public void StartGame()
        {
            while (true)
            {
                HandleKeyPress();
                _player.Move();
                DrawField();
                Console.Clear();
                foreach (var line in _gameField) Console.WriteLine(line);
                Thread.Sleep(500);
            }
        }

        private void HandleKeyPress()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        _player.ChangeDirection(MoveDirection.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        _player.ChangeDirection(MoveDirection.Left);
                        break;
                    case ConsoleKey.UpArrow:
                        _player.ChangeDirection(MoveDirection.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        _player.ChangeDirection(MoveDirection.Down);
                        break;
                    default:
                        _player.ChangeDirection(MoveDirection.Default);
                        break;
                }
            }
        }

        private void CreateWelcomeMessage()
        {
            string[] welcomeMessage =
            {
                "Welcome, player!",
                String.Format("This is {0}",_gameName),
                "\n",
                "Press Enter to start game",
                "Press Esc to quit"
            };

            int linesBefore = Convert.ToInt32(Math.Floor((_sceneHeight - 5)/2.0));
            
            for (int i = 0; i < linesBefore; i++) _gameField.Add(new string(' ', _sceneWidth));

            foreach (var line in welcomeMessage)
            {
                var output = "";
                var charsBefore = (_sceneWidth - line.Length) / 2;
                for (var i = 0; i < charsBefore; i++) output += " ";
                output += line;
                _gameField.Add(output);
            }

            for (int i = 0; i < _sceneHeight - linesBefore - 5; i++) _gameField.Add(new string(' ', _sceneWidth));
        }
    }
}
