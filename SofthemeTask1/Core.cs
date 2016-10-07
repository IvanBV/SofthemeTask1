using System;
using System.IO;
using System.Text;

namespace SofthemeTask1
{
    class Core
    {
        private int[][] triangle;
        //Делаем копию для того, чтобы не изменять исходный массив и можно было восстановить маршрут
        private int[][] copy;
        private MainForm console;

        public Core(MainForm form)
        {
            console = form;
        }

        /// <summary>
        /// Main method
        /// </summary>
        public void Run()
        {
            LoadTriangleFromFile("../../triangle.txt"); // "../../triangle.txt" or "../../triangleBig.txt"
            PrintTriangle();
            FindPath();
        }

        /// <summary>
        /// Finds maximum sum of numbers in triangle from top to bottom
        /// </summary>
        private void FindPath()
        {
            if (triangle == null)
            {
                console.PrintLine("Cant find path. Triangle is null\n");
                return;
            }
            copy = new int[triangle.Length][];
            for (int i = 0; i < triangle.Length; i++)
            {
                copy[i] = new int[triangle[i].Length];
                for (int j = 0; j < copy[i].Length; j++)
                {
                    copy[i][j] = triangle[i][j];
                }
            }
            //Проход по всем уровням снизу вверх
            for (int i = copy.Length - 2; i >= 0; i--)
            {
                //Суммируем элемент и максимального соседа на нижнем уровне
                for (int j = 0; j < copy[i].Length; j++)
                {
                    try
                    {
                        copy[i][j] += Math.Max(copy[i + 1][j], copy[i + 1][j + 1]);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        console.PrintLine("Index out of range. Possibly bad triangle");
                        return;
                    }
                }      
            }

            //Восстановим путь
            StringBuilder pathString = new StringBuilder();
            pathString.AppendFormat("{0} -> ", triangle[0][0]);
            int k = 0;
            for (int i = 1; i < copy.Length; i++)
            {
                if (copy[i][k] < copy[i][k + 1])
                {
                    k++;
                }
                pathString.AppendFormat("{0} -> ", triangle[i][k]);
            }
            pathString.Remove(pathString.Length - 4, 4);
            console.PrintLine(pathString.ToString());
            console.PrintLine(String.Format("Max sum = {0}", copy[0][0]));
        }

        /// <summary>
        /// Loads number triangle from .txt file
        /// </summary>
        /// <param name="path">Path to file</param>
        private void LoadTriangleFromFile(String path)
        {
            if (File.Exists(path))
            {
                String[] lines = File.ReadAllLines(path);
                triangle = new int[lines.Length][];
                for (int i = 0; i < lines.Length; i++)
                {
                    String[] numbers = lines[i].Trim().Split(' ');
                    triangle[i] = new int[numbers.Length];
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        try
                        {
                            triangle[i][j] = Convert.ToInt32(numbers[j]);
                        }
                        catch (FormatException e)
                        {
                            console.PrintLine(e.Message);
                            triangle = null;
                        }
                    }
                }
            }
            else
            {
                console.PrintLine("File Not Found");
            }
        }

        /// <summary>
        /// Prints triangle in console window
        /// </summary>
        public void PrintTriangle()
        {
            if (triangle != null)
            {
                StringBuilder text = new StringBuilder();
                for (int i = 0; i < triangle.Length; i++)
                {
                    for (int j = 0; j < triangle[i].Length; j++)
                    {
                        text.AppendFormat("{0} ", triangle[i][j]);
                    }
                    text.Remove(text.Length - 1, 1);
                    text.Append("\n");
                }
                text.Remove(text.Length - 1, 1);
                console.PrintLine(text.ToString());
            }
            else
            {
                console.PrintLine("Triangle is null");
            }
        }
    }
}