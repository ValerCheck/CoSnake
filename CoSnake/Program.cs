﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int WIDTH = 30;
            const int HEIGHT = 20;
            Console.SetWindowSize(WIDTH + 1,HEIGHT + 1);
            Console.SetBufferSize(WIDTH + 1,HEIGHT + 1);

            var game = new Game(gameField : new FieldComponent<ICell>(WIDTH, HEIGHT), 
                                player : new GameCell('@'),
                                border: new GameCell('#'),
                                space: new GameCell(' '));

            game.InsertBordersToMap();
            game.SetPlayerPosition(1,1);

            //GameLoop();
            WriteArray(game.GameField.Field);
            Console.ReadLine();
        }

        static void GameLoop()
        {
            int spacesToAdd = 0;
            int returnToAdd = 0;
            string space = " ";
            string newLine = "\n";

            string head = "#";

            Console.WriteLine(head);

            while (true)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow)
                {
                    spacesToAdd++;
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    spacesToAdd--;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    returnToAdd--;
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    returnToAdd++;
                }

                StringBuilder bldr = new StringBuilder(head);
                for (int i = 0; i < spacesToAdd; i++) bldr.Insert(0, space);
                for (int i = 0; i < returnToAdd; i++) bldr.Insert(0, newLine);
                
                Console.Clear();
                Console.WriteLine(bldr.ToString());
            }
        }

        public static void WriteArray<T>(T[,] field) where T:ICell
        {
            for (int y = 0; y < field.GetLength(0); y++)
            {
                for (int x = 0; x < field.GetLength(1); x++)
                {
                    Console.Write(field[y,x].Content());
                }
                Console.WriteLine();
            }
        }
    }
}
