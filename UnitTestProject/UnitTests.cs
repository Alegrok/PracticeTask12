using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static PracticeTask12.Program;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array1 = CreateRandomArray(100);
            int[] array2 = (int[])array1.Clone();
            Assert.AreEqual(array1.ToString(), array2.ToString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            int[] array1 = CreateRandomArray(100);
            int[] array2 = (int[])array1.Clone();
            Sort(array1);
            Array.Sort(array2);
            Assert.AreEqual(array1.ToString(), array2.ToString());
        }

        [TestMethod]
        public void TestMethod3()
        {
            int[] array1 = CreateRandomArray(100);
            int[] array2 = (int[])array1.Clone();
            Reverse(array1);
            Reverse(array2);
            Assert.AreEqual(array1.ToString(), array2.ToString());
        }

        [TestMethod]
        public void TestMethod4()
        {
            ulong movings, comparisons = movings = 0;
            int[] array1 = CreateRandomArray(100);
            int[] array2 = Sort((int[])array1.Clone());
            ShellSort(array1, ref movings, ref comparisons);
            Assert.AreEqual(array1.ToString(), array2.ToString());
        }

        [TestMethod]
        public void TestMethod5()
        {
            ulong movings, comparisons = movings = 0;
            int[] array1 = CreateRandomArray(100);
            int[] array2 = Reverse(Sort((int[])array1.Clone()));
            QuickSort(array1, 0, array1.Length - 1, ref movings, ref comparisons);
            Reverse(array1);
            Assert.AreEqual(array1.ToString(), array2.ToString());
        }
    }
}
