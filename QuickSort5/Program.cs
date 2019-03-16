using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace QuickSort5
{
    class Program
    {
        static void QuickSort(int[] massive, int start, int end)
        {
            if (end == start) return;
            var mainIndex = start;
            for (int i = start; i < end; i++)
                if (massive[i] <= massive[end])
                {
                    var c = massive[i];
                    massive[i] = massive[mainIndex];
                    massive[mainIndex] = c;
                    mainIndex++;
                }
            var newAnd = massive[mainIndex];
            massive[mainIndex] = massive[end];
            massive[end] = newAnd;
            if (mainIndex > start) QuickSort(massive, start, mainIndex - 1);
            if (mainIndex < end) QuickSort(massive, mainIndex + 1, end);

        }

        public static void QuickSort(int[] array)
        {
            if (array.Length == 0)
                return;
            QuickSort(array, 0, array.Length - 1);
        }

        static void Main(string[] args)
        {
            return;
        }
    }
    [TestFixture]
    public class UnitTests
    {
        public readonly Random rnd = new Random();
        [Test]
        public void Test1()
        {
            bool first = false, second = false;
            var massive = new int[3];
            for (int i = 0; i < 3; i++)
            {
                massive[i] = rnd.Next(0, 5);
            }
            Program.QuickSort(massive);
            if (massive[1] >= massive[0])
                first = true;
            if (massive[1] <= massive[2])
                second = true;
            Assert.AreEqual(true, first);
            Assert.AreEqual(true, second);
        }
        [Test]
        public void Test2()
        {
            var e = rnd.Next(0, 5);
            var massive = new int[100];
            for (int i = 0; i < 100; i++)
            {
                massive[i] = e;
            }
            Program.QuickSort(massive);
            var counter = 0;
            for (int i = 0; i < 20; i++)
            {
                var check = rnd.Next(1, 99);
                if (massive[check - 1] <= massive[check])
                    counter++;
            }
            Assert.AreEqual(20, counter);
        }
        [Test]
        public void Test3()
        {
            var e = rnd.Next(0, 5);
            var massive = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                massive[i] = e;
            }
            Program.QuickSort(massive);
            var counter = 0;
            for (int i = 0; i < 10; i++)
            {
                var check = rnd.Next(1, 999);
                if (massive[check - 1] <= massive[check])
                    counter++;
            }
            Assert.AreEqual(10, counter);
        }
        [Test]
        public void Test4()
        {
            List<int> massive = new List<int>();
            var currentMassive = massive.ToArray();
            Program.QuickSort(currentMassive);
            Assert.AreEqual(0, currentMassive.Length);
        }

        [Test]
        public void Test5()
        {
            var massive = new int[150000000];
            for (int i = 0; i < 150000000; i++)
            {
                massive[i] = rnd.Next(0, 5); ;
            }
            Program.QuickSort(massive);
            var counter = 0;
            for (int i = 0; i < 3; i++)
            {
                var check = rnd.Next(1, 150000000 - 1);
                if (massive[check - 1] <= massive[check])
                    counter++;
            }
            Assert.AreEqual(3, counter);
        }
    }
}
