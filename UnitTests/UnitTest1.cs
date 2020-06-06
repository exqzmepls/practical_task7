using System;
using System.IO;
using practical_task7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestIntInput()
        {
            Console.SetIn(new StreamReader("input.txt"));
            double result = 2;

            double input = Program.IntInput(lBound: 0, uBound: 100, info: "some info");

            Assert.AreEqual(result, input);
        }

        [TestMethod]
        public void TestPrintSelectionNEqualsK()
        {
            StreamWriter os = new StreamWriter("output.txt", false);
            Console.SetOut(os);

            int n = 4;
            int k = 4;
            int[] elements = new int[n];
            for (int i = 0; i < n; i++) elements[i] = i + 1;

            Program.PrintSelections(elements, n, k);
            os.Close();

            bool result = true;
            StreamReader actual = new StreamReader("output.txt");
            StreamReader expected = new StreamReader("selections44.txt");

            for (int i = 0; !actual.EndOfStream; i++)
            {
                string[] actualLine = actual.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] expectedLine = expected.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < k; j++) if (actualLine[j] != expectedLine[j]) result = false;
            }

            actual.Close();
            expected.Close();

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestPrintSelectionNNotEqualsK()
        {
            StreamWriter os = new StreamWriter("output.txt", false);
            Console.SetOut(os);

            int n = 10;
            int k = 6;
            int[] elements = new int[n];
            for (int i = 0; i < n; i++) elements[i] = i + 1;

            Program.PrintSelections(elements, n, k);
            os.Close();

            bool result = true;
            StreamReader actual = new StreamReader("output.txt");
            StreamReader expected = new StreamReader("selections106.txt");

            for (int i = 0; !actual.EndOfStream; i++)
            {
                string[] actualLine = actual.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] expectedLine = expected.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < k; j++) if (actualLine[j] != expectedLine[j]) result = false;
            }

            actual.Close();
            expected.Close();

            Assert.AreEqual(true, result);
        }
    }
}
