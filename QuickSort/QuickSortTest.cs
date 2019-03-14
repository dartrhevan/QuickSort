using System;
using NUnit.Framework;

namespace QuickSort
{
    [TestFixture]
    public class QuickSortTest
    {
        /*Сортировка массива из трёх элементов. После сортировки второй элемент больше первого, третий больше второго*/
        [Test]
        public void SortSimpleArray()
        {
            var array = GenerateRandomArray(3);
            HoareSort.QuickSort(array);
            Assert.That(array[0] < array[1] && array[1] < array[2], "Simple array sorting");
        }
        /*Сортировка массива из 100 одинаковых числе работает корректно*/
        [Test]
        public void SortArrayEqualsElements()
        {
            var array = new int[100];
            HoareSort.QuickSort(array);
            foreach (var n in array)
                Assert.That(n == array[0]);
        }

        /*
         *  Сортировка массива из 1000 случайных элементов.
         *  Проверить что 10 случайных пар элементов массива после сортировки упорядочены
         *  (из пары больший тот, чей индекс больше)
         */
        [Test]
        public void SortNormalArray()
        {
            var array = GenerateRandomArray(1000);
            var indexes = GenerateRandomArray(20, array.Length);
            HoareSort.QuickSort(array);
            for (var i = 0; i < indexes.Length; i += 2)
                Assert.That((array[indexes[i]] < array[indexes[1 + i]] && indexes[i] < indexes[1 + i]) ||
                            (array[indexes[i]] > array[indexes[1 + i]] && indexes[i] > indexes[1 + i]), "Normal array sorting");
        }

        // Сортировка пустого массива работает корректно
        [Test]
        public void SortEmptyArray()
        {
            var array = new int[0];
            HoareSort.QuickSort(array);
        }

        //Сортировка массива из 1 500 000 000 элементов
        [Test]
        public void SortHugeArray()
        {
            var array = GenerateRandomArray(1500000000);
            HoareSort.QuickSort(array);
            for (var i = 1; i < array.Length ; i++)
                Assert.That(array[i - 1] < array[i]);
        }

        static int[] GenerateRandomArray(int lenght, int maxEl = int.MaxValue)
        {
            var random = new Random(DateTime.Now.Millisecond);
            var array = new int[lenght];
            for (var i = 0; i < lenght; ++i)
                array[i] = random.Next(maxEl);
            return array;
        }
    }
}