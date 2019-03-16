
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuickSort
{
    public class HoareSort
    {
        /// <summary>
        /// Реализация алгоритма быстрой сортировки
        /// </summary>
        /// <param name="array"></param>
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static void QuickSort(int[] array, int begin, int end)
        {
            if (begin >= end) return;
            var selectedElement = array[end];
            var currentInd = begin;
            for (var i = begin; i < end; ++i)
            {
                if (array[i] <= selectedElement)
                    Swap(ref array[i], ref array[currentInd++]);
            }
            Swap(ref array[currentInd], ref array[end]);
            if (begin == 0 && end == array.Length)
            {
                Parallel.Invoke((() => {
                    if (currentInd > begin) QuickSort(array, begin, currentInd - 1);
                }), (() => {
                    if (currentInd < end) QuickSort(array, currentInd + 1, end);
                }));
            }
            else
            {
                if (currentInd > begin) QuickSort(array, begin, currentInd - 1);
                if (currentInd < end) QuickSort(array, currentInd + 1, end);
            }
        }

        /// <summary>
        /// Замена значений 2 переменных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element1"></param>
        /// <param name="element2"></param>
        static void Swap<T>(ref T element1, ref T element2)
        {
            var temp = element1;
            element1 = element2;
            element2 = temp;
        }
    }
}