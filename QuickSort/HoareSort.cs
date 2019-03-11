
using System;
using System.Threading;

namespace QuickSort
{
    public class HoareSort
    {
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
            if (currentInd > begin) QuickSort(array, begin, currentInd - 1);
            if (currentInd < end) QuickSort(array, currentInd + 1, end);
        }

        static void Swap<T>(ref T element1, ref T element2)
        {
            var temp = element1;
            element1 = element2;
            element2 = temp;
        }
    }
}