using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoSnake
{
    class Program
    {
        static void Main(string[] args)
        {
            //GameLoop();
            var output = new List<char[]>();
            output.Add(new []{'#','#','#'});
            output.Add(new[] { '#', ' ', '#' });
            output.Add(new[] { '#', '#', '#' });
            WriteArray(output);
            //Console.WriteLine(output);

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

        public static void WriteArray(List<char[]> field)
        {
            foreach (var row in field)
                Console.WriteLine(row);
            
        }
    }
}
