using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            MConsole mConsole = new MConsole();

            int i = 0;
            mConsole.GetInteger("размер матрицы:", ref i);
            if (i > 0)
            {
                Math math = new Math(i);
                int[,] matrixResult = math.MatrixMult(math.matrix1, math.matrix2);

                math.PrintMatrix(math.matrix1, "\nПервая матрица");
                math.PrintMatrix(math.matrix2, "\nВторая матрица");
                math.PrintMatrix(matrixResult, "\nпроизведение матриц");

                Console.WriteLine($"\nВремя выполнения: {math.timeElapsed}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите значение больше 0");
            }


            Console.ReadKey();
        }
    }

    class MConsole
    {
        public Boolean GetInteger(string Question, ref int ResInt)
        {
            string s = GetString(Question);
            if (int.TryParse(s, out ResInt))
            {
                return true;
            }
            else
            {
                ConsoleColor cfc = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Введите валидные значения - {s}!");
                Console.ForegroundColor = cfc;
                Console.ReadKey();
                return false;
            }
        }

        public string GetString(string Question)
        {
            try
            {
                Console.Write(Question);
                return Console.ReadLine();
            }
            catch
            {
                return "";
            }
        }
    }

    public class Math
    {
        //Размер матрицы ixj
        readonly int mLen;

        public readonly int[,] matrix1;
        public readonly int[,] matrix2;
        public int[,] matrixResult;

        public TimeSpan timeElapsed { get; set; }

        static Random rnd = new Random();

        DateTime ts;
        DateTime te;

        public Math(int mSize)
        {
            mLen = mSize;
            matrix1 = new int[mSize, mSize];
            matrix2 = new int[mSize, mSize];
            matrixResult = new int[mSize, mSize];

            //создаем 2 матрицы
            for (int i = 0; i < mSize; i++)
            {
                for (int j = 0; j < mSize; j++)
                {
                    matrix1[i, j] = rnd.Next(0, 11);
                    matrix2[i, j] = rnd.Next(0, 11);
                }
            }
        }

        public int[,] MatrixMult(int[,] matrix1, int[,] matrix2)
        {
            ts = DateTime.Now;


            Parallel.For(0, mLen, iline => {
                Parallel.For(0, mLen, i => Multiply(matrixResult, i, iline, mLen));
            });
            timeElapsed = DateTime.Now - ts;
            return matrixResult;
            
        }

        private void Multiply(int[,] result, int i, int line, int len)
        {
            for (int j = 0; j < len; j++)
            {
                result[line, i] += matrix1[line, j] * matrix2[j, i];
            }
        }

        private void MatrixGo(int line)
        {
            Parallel.For(0, mLen, i => Multiply(matrixResult, i, line, mLen));
        }


        public void PrintMatrix(int[,] matrix, string name)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(name + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine("");
            }
        }
    }
}