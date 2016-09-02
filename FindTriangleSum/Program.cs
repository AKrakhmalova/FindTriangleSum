using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindTriangleSum
{
    class Program
    {
        const string smallTriangleFilePath=@"triangleSmall.txt";
        const string bigTriangleFilePath = @"triangleBig.txt";
        const char numberSeparator = ' ';

        private static int[] ConvertStringToNumberArray(string numberString)
        {
            string[] stringArray = numberString.Split(numberSeparator);
            int[] numberArray = Array.ConvertAll(stringArray, int.Parse);
            return numberArray;
        }

        static void Main(string[] args)
        {
            string numberLine;
            int sum = 0;
            //string filePath = smallTriangleFilePath;
            string filePath = bigTriangleFilePath;

            if (File.Exists(filePath))
            {
                Console.WriteLine("Triangle max path is: ");
                // Reading lines of triangle from text file line by line:
                StreamReader file = new StreamReader(filePath);
                while ((numberLine = file.ReadLine()) != null)
                {
                    // Converting string to array of numbers
                    int[] numberArray = ConvertStringToNumberArray(numberLine);

                    // Sorting numbers by descending
                    Array.Sort<int>(numberArray,
                        new Comparison<int>
                        (
                            (n1, n2) => n2.CompareTo(n1)
                        ));

                    //Finding sum of the max sum of path in the triangle (first el. in line number array now is the max el.)
                    sum += numberArray[0];
                    Console.Write(numberArray[0]+" ");
                }
                file.Close();
                Console.WriteLine();

                Console.WriteLine("Max path sum in the given triangle is " + sum);
            }
            else
                Console.WriteLine("Given file: \"{0}\" does no exist in current working drectory of the program: {1}",filePath, Directory.GetCurrentDirectory());
            
            Console.ReadKey();
        }

    }
}
