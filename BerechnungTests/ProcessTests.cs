using Microsoft.VisualStudio.TestTools.UnitTesting;
using Berechnung;
using System;
using System.Collections.Generic;
using System.Text;

namespace Berechnung.Tests
{
    [TestClass()]
    public class ProcessTests
    {
        [TestMethod()]
        public void calcFAZTest()
        {
            Process process = new Process(0, "test", 5);
            process.calcFAZ();
            Assert.AreEqual(0, process.faz);
        }
        [TestMethod()]
        public void calcFazNotNullTest()
        {
            Process process = new Process(0, "test1", 5);
            process.AddPredecessor(new Process(1, "test1", 10));
            process.AddPredecessor(new Process(2, "test2", 1));
            process.AddPredecessor(new Process(3, "test3", 5));
            process.AddPredecessor(new Process(4, "test4", 15));
            process.AddPredecessor(new Process(5, "test5", 25));
            process.AddPredecessor(new Process(6, "test6", 30));
            process.AddPredecessor(new Process(7, "test7", 5));
            process.AddPredecessor(new Process(8, "test8", 7));
            process.AddPredecessor(new Process(9, "test9", 4));
            process.AddPredecessor(new Process(10, "test10", 6));
            process.AddPredecessor(new Process(11, "test11", 10));
            process.AddPredecessor(new Process(12, "test12", 2));
            process.AddPredecessor(new Process(13, "test13", 1));
            process.AddPredecessor(new Process(14, "test14", 3));
            process.AddPredecessor(new Process(15, "test15", 50));
            process.AddPredecessor(new Process(16, "test16", 20));
            process.AddPredecessor(new Process(17, "test17", 14));
            process.calcFAZ();
            Assert.AreEqual(50, process.faz);
        }

        [TestMethod()]
        public void calcSEZTest()
        {
            Process process = new Process(0, "test", 10);
            process.calcSEZ();
            Assert.AreEqual(10, process.sez);
        }
        [TestMethod()]
        public void calcSEZNotLastTest()
        {
            Process process = new Process(0, "test1", 10);
            process.AddSuccessor(new Process(1, "test2", 10));
            process.AddSuccessor(new Process(2, "test3", 5));
            process.AddPredecessor(new Process(3, "test4", 20));
            process.calcFAZ();
            process.succProcesses[0].calcSEZ();
            process.succProcesses[1].calcSEZ();
            int Process1Saz = process.succProcesses[0].saz;
            int Process2Saz = process.succProcesses[1].saz;
            int expectedFez;
            if(Process1Saz >= Process2Saz)
            {
                expectedFez = Process1Saz;
            }
            else
            {
                expectedFez = Process2Saz;
            }
            Assert.AreEqual(expectedFez, process.fez);

        }

    }
}