using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPractice
{
    class Program
    {

        public static string Path { get; set; }
        public static float[] MoistureData { get; set; }
        public static float[] SortedMoistureData { get; set; }

        static void Main(string[] args)
        {
            Path = @"C:\Users\9950230\AlgorithmPractice\AlgorithmPractice\Moisture_Data.txt";

            ImportData();

            //for (int i = 0; i < MoistureData.Length; i++)
            //Console.WriteLine(MoistureData[i]);

            while (true)
            {
                int input = 0;

                Console.WriteLine("\n\nHow many maximums do you want to find? ");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Stopwatch sw = new Stopwatch();
                sw.Start();
                Display(FindMaximum(input));
                sw.Stop();
                Console.WriteLine();
                Console.WriteLine("Find Maximum: " + sw.ElapsedTicks + " ticks");

                Console.WriteLine();

                sw.Restart();
                SortedMoistureData = SelectionSort();
                Console.WriteLine("### Original");
                Display(MoistureData);
                Console.WriteLine("\n\n### Sorted");
                Display(SortedMoistureData);
                Console.WriteLine("\n\nMax: " + SortedMoistureData[SortedMoistureData.Length-1]);
                Console.WriteLine("\nMin: " + SortedMoistureData[0]);
                Console.WriteLine("\nAverage: " + SortedMoistureData.Average());
                sw.Stop();
                Console.WriteLine();
                Console.WriteLine("\nSelection Sort: " + sw.ElapsedTicks + " ticks");

            }
            
        }

        static void Display(float[] toDisplay)
        {
            for (int i = 0; i < toDisplay.Length; i++)
                Console.Write(toDisplay[i] + " ");
        }

        static void ImportData()
        {
            string[] data = File.ReadAllLines(Path);

            MoistureData = new float[data.Length];
            for (int i = 0; i < MoistureData.Length; i++)
                MoistureData[i] = float.Parse(data[i]);
        }

        static float[] SelectionSort()
        {
            float[] arr = new float[MoistureData.Length];
            Array.Copy(MoistureData, arr, MoistureData.Length);

            for (int outter = 0; outter < arr.Length; outter++)
            {
                int min = outter;//Create a starting point for the lowest number.
                for (int inner = outter + 1; inner < arr.Length; inner++)//Linear search the rest of the data for the lowest value
                {
                    if (arr[inner] < arr[min])
                        min = inner;//Store the lowest number in the min variable
                }
                float temp = arr[outter];//Once the lowest value is found perform the swap.
                arr[outter] = arr[min];
                arr[min] = temp;
            }

            return arr;
        }

        static float[] FindMaximum(int findAmount)
        {
            float[] found = new float[findAmount];
            float[] moistureDataCopy = new float[MoistureData.Length];
            Array.Copy(MoistureData, moistureDataCopy, MoistureData.Length);

            int index = 0;
            for (int i = 0; i < findAmount; i++)
            {
                for (int x = 0; x < moistureDataCopy.Length; x++)
                {
                    if (moistureDataCopy[index] < moistureDataCopy[x])
                        index = x;
                }
                found[i] = moistureDataCopy[index];
                moistureDataCopy[index] = float.MinValue;
            }

            return found;
        }
    }
}
