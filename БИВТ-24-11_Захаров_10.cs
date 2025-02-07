// Variant_10

using System;
using System.Data.SqlTypes;
using System.Linq;

namespace Exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            System.Console.WriteLine("Task1");
            Console.WriteLine(program.Task_1(4, 6, 22));
            System.Console.WriteLine();
            // Task_1:
            // Input: S = 4, A = 6, N = 22
            // Output: time = 18
            System.Console.WriteLine("Task2");
            Console.WriteLine(program.Task_2(4, 6, 22));
            System.Console.WriteLine();
            // Task_2:
            // Input: GPU = 4, RAM = 6, CPU = 22
            // Output: fps = 13,200000000000003
            var A = new int[] { 17, 17, 2, -10, -1, -20 };
            var M = new int[,] { {23,   7, -13,  24, -21,  18 },
                 { 2,   0,  12, -16, -20, -17 },
                 { 22,  21,  -6,  19, -22,  -4 },
                 { -13, 13,  18, -15, -20,  -2 },
                 { 3,   7,   1, -20,  22,  -8 },
                { -22, -11,  13,  -2,   0, -14} };
            System.Console.WriteLine("Task3");
            program.Print(M);
            System.Console.WriteLine();
            program.Task_3(M);
            program.Print(M);
            System.Console.WriteLine();
            System.Console.WriteLine("Task4");
            program.Print(A);
            program.Task_4(ref A);
            System.Console.WriteLine();
            program.Print(A);
            System.Console.WriteLine();
            System.Console.WriteLine();
            // Task_3:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 -13, 13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            // Output:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                 22,  21,  18,  19, -22,  -4, 
                  2,   0,   1, -16, -20, -17, 
                 23,   7,  13,  24, -21,  18 */

            // Task_4:
            // Input:
            /*   17,  17,   2, -10,  -1, -20 */
            // Output:
            /*    2, -10, -20 */

            System.Console.WriteLine("task5");
            program.Print(M);
            System.Console.WriteLine();
            //program.Task_5(M, program.SortAscending);
            //program.Task_5(M, arr, program.ReplaceColumn);
            program.Print(M);
            System.Console.WriteLine();
            // Task_5:
            // Input:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*   17,  17,   2, -10,  -1, -20 */
            // Output 1:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */

            /*  -20, -10,  -1,   2,  17,  17, -15, -14,  -6,   0,  22,  23 */
            // Output 2:
            /*   23,   7, -13,  24, -21,  18, 
                  2,   0,  12, -16, -20, -17, 
                 22,  21,  -6,  19, -22,  -4, 
                -13,  13,  18, -15, -20,  -2, 
                  3,   7,   1, -20,  22,  -8, 
                -22, -11,  13,  -2,   0, -14 */
            /*   17,  17,   2,  -1, -10, -20,  23,  22,   0,  -6, -14, -15 */

        }
        public double Task_1(double S, double A, double N)
        {
            if (S <= 0 || A <= 0 || N <= 0) return 0;
            double ready = 0;
            double i = 0;

            while (ready < N)
            {
                i++;
                ready += Math.Sqrt(i);
                if (i % 5 == 0)
                {
                    ready -= S;
                    if (ready < 0)
                    {
                        ready = 0;
                    }
                }
                if (i % A == 0)
                {
                    if (ready > 0)
                    {
                        ready /= 1.5;
                    }
                }
            }
            return i;
        }
        public double Task_2(double GPU, double RAM, double CPU)
        {
            if (GPU <= 0 || RAM <= 0 || CPU <= 0) return 0;
            double gpuLoad = 10, ramLoad = 1, cpuLoad = 1, fps = 200;
            while (fps > 20)
            {
                if (gpuLoad < GPU)
                {
                    gpuLoad *= 1.1;
                }
                if (ramLoad < RAM)
                {
                    ramLoad *= 2;
                }
                else
                {
                    ramLoad /= 1.5;
                    cpuLoad++;
                }
                if (cpuLoad > CPU)
                {
                    cpuLoad = CPU;
                    gpuLoad = GPU;
                }
                fps = (GPU / gpuLoad) * (RAM / ramLoad) * (CPU / cpuLoad);
            }
            return fps;
        }
        public void Task_3(int[,] M)
        {
            if (M == null || M.GetLength(0) != M.GetLength(1)) return;
            int n = M.GetLength(0);
            int minP = 999999;
            int Column = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (M[i, j] > 0 && M[i, j] < minP)
                    {
                        minP = M[i, j];
                        Column = j;
                    }
                }
            }
            int middle = n / 2;
            for (int j = 0; j < n; j++)
            {
                if (j == Column)
                {
                    continue;
                }

                for (int i = 0; i < middle; i++)
                {
                    M[n - 1 - i, j] = M[i, j];
                }
            }
        }
        public void Task_4(ref int[] A)
        {
            if (A == null) return;
            int mi = 99999999;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < mi && A[i] > 0)
                {
                    mi = A[i];
                }
            }
            bool isEven = mi % 2 == 0;
            int[] itog = GetArraySequence(A, isEven);
        }
        public int[] GetArraySequence(int[] array, bool isEven)
        {
            int k = 0;
            if (!isEven) k = 1;
            int j = 0;
            foreach (int i in array) { if (i % 2 == k) { j++; } }
            int[] narray = new int[j];
            j = 0;
            foreach (int i in array) { if (i % 2 == k) { narray[j] = i; j++; } }
            return narray;
        }
        public void Task_5(ref int[,] M, ref int[] A, SortArray Op)
        {
            if (M == null && A == null) return;
            int n = M.GetLength(0);
            if (n != M.GetLength(1))
            {
                int[] diagonal = new int[n];
                for (int i = 0; i < n; i++)
                {
                    diagonal[i] = M[i, i];
                }
                Op(diagonal);
                Op(A);
            }
        }
        public delegate void SortArray(int[] array);
        public void SortAscending(int[] array)
        {
            if (array != null)
            {
                Array.Sort(array);
            }
        }   
        public void SortDescending(int[] array)
        {
            if (array != null)
            {
                Array.Sort(array);
                Array.Reverse(array);
            }

        }
        public int[] Concat(int[] array1, int[] array2)
        {
            if (array1 == null || array2 == null) return null;
            int[] result = new int[array1.Length + array2.Length];
            Array.Copy(array1, result, array1.Length);
            Array.Copy(array2, 0, result, array1.Length, array2.Length);
            return result;
        }

        public void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void Print(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
