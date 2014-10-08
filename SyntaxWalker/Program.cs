using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;

namespace SyntaxWalker
{
    class Program
    {
        static void Main(string[] args)
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(
                  @"using System;
                    using System.Collections.Generic;
                    using System.Linq;
                    using System.Text;
 
                    namespace Quicksort
                    {
                        class Sorter
                        {
                            public static int[] BubbleSort(int[] array)
                            {
                                int length = array.Length;

                                int temp = array[0];

                                for (int i = 0; i < length; i++)
                                {
                                    for (int j = i+1; j < length; j++)
                                    {
                                        if (array[i] > array[j])
                                        {
                                            temp = array[i];

                                            array[i] = array[j];

                                            array[j] = temp;
                                        }
                                    }
                                }

                                return array;        
                            }

                            public static void MergeSort<T>(T[] a, int low, int high)
                                where T : IComparable<T>
                            {
                                int N = high - low;
                                if (N <= 1)
                                    return;

                                int mid = low + N / 2;

                                sort(a, low, mid);
                                sort(a, mid, high);

                                T[] aux = new T[N];
                                int i = low, j = mid;
                                for (int k = 0; k < N; k++)
                                {
                                    if (i == mid) aux[k] = a[j++];
                                    else if (j == high) aux[k] = a[i++];
                                    else if (a[j].CompareTo(a[i]) < 0) aux[k] = a[j++];
                                    else aux[k] = a[i++];
                                }

                                for (int k = 0; k < N; k++)
                                {
                                    a[low + k] = aux[k];
                                }
                            }

                            public static void Quicksort(IComparable[] elements, int left, int right)
                            {
                                int i = left, j = right;
                                IComparable pivot = elements[(left + right) / 2];

                                while (i <= j)
                                {
                                    while (elements[i].CompareTo(pivot) < 0)
                                    {
                                        i++;
                                    }

                                    while (elements[j].CompareTo(pivot) > 0)
                                    {
                                        j--;
                                    }

                                    if (i <= j)
                                    {
                                        // Swap
                                        IComparable tmp = elements[i];
                                        elements[i] = elements[j];
                                        elements[j] = tmp;

                                        i++;
                                        j--;
                                    }
                                }

                                // Recursive calls
                                if (left < j)
                                {
                                    Quicksort(elements, left, j);
                                }

                                if (i < right)
                                {
                                    Quicksort(elements, i, right);
                                }
                            }

                        }
                    }");

            var root = (CompilationUnitSyntax)tree.GetRoot();

            var cyclomaticComplexityWalker = new CyclomaticComplexityWalker();
            cyclomaticComplexityWalker.Visit(root);

            Console.ReadLine();
                     
        }
    }
}
