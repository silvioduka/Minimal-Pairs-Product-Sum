/*
Minimal Pairs Product Sum from Coding Challenges
by Silvio Duka

Last modified date: 2018-03-08

Write a function that receives an array of integers and returns the minimal sum of the array (sum of products of each two adjacent numbers). 

For Example: 
Without sorting the array [40,25,10,5,1], the sum is: 
(40*25) + (25*10) + (10*5) + (5*1) = 1305 

The challenge is to find the best possible sort of the array elements, to have the minimal sum result. 

The expected output for the array [40,25,10,5,1]  is 225. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalPairsProductSum
{
    class Program
    {
        static int[] elements = { 40, 25, 5, 1, 10 };  // Insert a integer numbers into array

        static void Main(string[] args)
        {
            sort();

            int[] tmp = new int[elements.Length];
            int mpps = 0;
            string s = "";

            if (elements.Length == 3)
            {
                tmp[0] = elements[2];
                tmp[1] = elements[0];
                tmp[2] = elements[1];

                mpps = tmp[0] * tmp[1] + tmp[1] * tmp[2];
                s = tmp[0].ToString() + ", " + tmp[1].ToString() + ", " + tmp[2].ToString();
            }
            else
            {
                for (int i = 0; i < elements.Length / 2; i++)
                {
                    if (i % 2 == 0)
                    {
                        tmp[i] = elements[elements.Length - i - 1];
                        tmp[i + 1] = elements[i];
                    }
                    else
                    {
                        tmp[elements.Length - i] = elements[elements.Length - i - 1];
                        tmp[elements.Length - i - 1] = elements[i];
                    }
                }

                if (elements.Length % 2 == 1) tmp[elements.Length / 2] = elements[elements.Length / 2];

                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    mpps += tmp[i] * tmp[i + 1];
                    s += tmp[i].ToString() + ", ";
                }

                s += tmp[tmp.Length - 1].ToString();
            }

            Console.WriteLine($"Minimal Pairs Product Sum\nof [{s.Trim().TrimEnd(',')}] is {mpps}");
        }

        static void sort()
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    if (elements[j] > elements[j + 1]) swap(j, j + 1);
                }
            }
        }

        static void swap(int a, int b)
        {
            int t = elements[b];

            elements[b] = elements[a];
            elements[a] = t;
        }
    }
}
