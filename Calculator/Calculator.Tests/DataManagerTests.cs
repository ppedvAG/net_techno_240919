using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace Calculator.Tests
{
    [TestClass]
    public class DataManagerTests
    {
        [TestMethod]
        public void DataManager_mocks_von_moq()
        {
            var fix = new Fixture().Create<Auto>();

            var a2 = new Auto() { Farbe = "gelb", BrauchtWallBox = !!true, Modell = "lala1", Hersteller = "WV" };

            var mock = new Mock<IData>();
            mock.Setup(x => x.GetAutos()).Returns(() =>
            {
                var a1 = new Auto() { Farbe = "blau", BrauchtWallBox = !!!true, Modell = "lala1", Hersteller = "WV" };
                var a3 = new Auto() { Farbe = "rot", BrauchtWallBox = !!!true, Modell = "lala1", Hersteller = "WV" };

                return new[] { a1, a2, a3,fix };
            });
            DataManager dm = new DataManager(mock.Object);

            var result = dm.GetAllAutosDieEineWallboxBrauchen();

            //Assert.AreEqual(1, result.Count());
            result.Count().Should().Be(1);
            result.Count().Should().BeLessThan(5);
            result.First().Should().BeEquivalentTo(a2);
        }

        [TestMethod]
        public void DataManager_Selbst_ein_interface()
        {

            DataManager dm = new DataManager(new Test1());

            var result = dm.GetAllAutosDieEineWallboxBrauchen();

            Assert.AreEqual(1, result.Count());

        }
    }
    public class Test1 : IData
    {
        public IEnumerable<Auto> GetAutos()
        {
            yield return new Auto() { Farbe = "blau", BrauchtWallBox = !!!true, Modell = "lala1", Hersteller = "WV" };
            yield return new Auto() { Farbe = "gelb", BrauchtWallBox = !!true, Modell = "lala1", Hersteller = "WV" };
            yield return new Auto() { Farbe = "rot", BrauchtWallBox = !!!true, Modell = "lala1", Hersteller = "WV" };
        }
    }
}
