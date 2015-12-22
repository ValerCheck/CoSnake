using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoSnake
{
    public class Game
    {
        private FieldComponent<ICell> _gameField;
        private Dictionary<string, ICell> _gameObjects; 
        private GameState _gameState;

        public FieldComponent<ICell> GameField
        {
            get { return _gameField; } private set { _gameField = value; }
        } 

        public Game(FieldComponent<ICell> gameField, ICell player)
        {
            GameField = gameField;
            _gameObjects = new Dictionary<string, ICell> {{"player", player}};

            //GameField.SetPlayerObject(player);
            _gameState = GameState.Created;
        }

        public Game(FieldComponent<ICell> gameField, ICell player, ICell border, ICell space)
        {
            GameField = gameField;

            _gameObjects = new Dictionary<string, ICell> {{"player", player}, {"border", border}, {"space", space}};

            _gameState = GameState.Created;
        }

        public void FillFieldWithEmptySpace()
        {
            if (!_gameObjects.ContainsKey("space")) throw new InvalidOperationException("Space entity is not instantiated");
            for (int y = 0; y < _gameField.Height; y++)
            {
                for (int x = 0; x < _gameField.Width; x++)
                {
                    _gameField.InsertCell(x, y, _gameObjects["space"]);
                }
            }
        }

        public void InsertBordersToMap()
        {
            FillFieldWithEmptySpace();
            if (!_gameObjects.ContainsKey("border")) throw new InvalidOperationException("Border entity is not instantiated");
            for (int y = 0; y < _gameField.Height; y++)
            {
                for (int x = 0; x < _gameField.Width; x++)
                {
                    if ((y > 0 && y < _gameField.Height - 1) && (x > 0 && x < _gameField.Width - 1)) continue;
                    _gameField.InsertCell(x, y, _gameObjects["border"]);
                }
            }
        }

        public void InsertBordersToMap(bool top, bool right, bool bottom, bool left)
        {
            if (top && left && bottom && right) InsertBordersToMap();

            var width = _gameField.Width;
            var height = _gameField.Height;

            if (top) for (int x = 0; x < width; x++) _gameField.InsertCell(x, 0, _gameObjects["border"]);
            if (bottom) for (int x = 0; x < width; x++) _gameField.InsertCell(x, height - 1, _gameObjects["border"]);
            if (left) for (int y = 0; y < height; y++) _gameField.InsertCell(0, y, _gameObjects["border"]);
            if (right) for (int y = 0; y < height; y++) _gameField.InsertCell(width - 1, y, _gameObjects["border"]);

        }

        public void SetPlayerPosition(int x, int y)
        {
            _gameField[x, y] = _gameObjects["player"];
        }

        public void StartGame()
        {
            _gameState = GameState.Running;
            while (_gameState == GameState.Running)
            {
                
            }
        }

        public void StopGame()
        {
            _gameState = GameState.Stopped;
        }

        public void PauseGame()
        {
            _gameState = GameState.Paused;
        }
    }
}
