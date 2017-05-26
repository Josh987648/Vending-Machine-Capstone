using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTest
    {
        [TestMethod]
        public void Change75Cents()
        {
            //Arrange
            Change changeTest = new Change();

            //Act
            Dictionary<string, int> result = changeTest.MakeChange(1.00M, 0.75M);
            Dictionary<string, int> totalChange = new Dictionary<string, int>();
            totalChange.Add("Number of Quarters", 1);

            //Assert
            CollectionAssert.AreEqual(totalChange, result);
        }
        [TestMethod]
        public void Change95Cents()
        {
            Change changeTest = new Change();

            Dictionary<string, int> result = changeTest.MakeChange(2.00M, 1.05M);
            Dictionary<string, int> totalChange = new Dictionary<string, int>();
            totalChange.Add("Number of Quarters", 3);
            totalChange.Add("Number of Dimes", 2);

            CollectionAssert.AreEqual(totalChange, result);
        }
    }
}
