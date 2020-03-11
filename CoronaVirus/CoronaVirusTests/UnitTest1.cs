using System;
using CoronaVirus;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoronaVirusTests
{
    [TestClass]
    public class UnitTest1
    {
        private Coordinate coordinate;
        [TestInitialize]
        public void Initialize()
        {
            coordinate = new Coordinate((50, 2, 45.1), (15, 31, 21.3));
        }
        [TestMethod]
        public void GetKilometers()
        {
            Assert.AreEqual(2.03, coordinate.getKilometers(new Coordinate((50, 02, 09.7), (15, 32, 47.8))));
        }
    }
}
