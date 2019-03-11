using System;
using NUnit.Framework;

namespace QuickSort
{
    [TestFixture]
    public class QuickSortTest
    {
        [Test]
        public void SortSimpleArray()
        {
            var array = GenerateRandomArray(3);
            HoareSort.QuickSort(array);
            Assert.That(array[0] < array[1] && array[1] < array[2], "Simple array sorting");
        }

        [Test]
        public void SortArrayEqualsElements()
        {
            var array = new int[100];
            HoareSort.QuickSort(array);
        }

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

        [Test]
        public void SortEmptyArray()
        {
            var array = new int[0];
            HoareSort.QuickSort(array);
        }

        [Test]
        public void SortHugeArray()
        {
            var array = GenerateRandomArray(1500000000);
            HoareSort.QuickSort(array);
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