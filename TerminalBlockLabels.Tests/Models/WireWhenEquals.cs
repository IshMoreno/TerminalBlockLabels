using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.Equals(object?)"/> method.
    /// </summary>
    [TestClass]
    public class WireWhenEquals
    {
        [TestMethod]
        public void ShouldReturnFalseIfLocationsAreDifferent()
        {
            string firstLocation1 = "CONTROL PANEL";
            string secondLocation1 = "ENTRANCE PANEL";
            string number1 = "1171";
            string layerName1 = "RED_16AWG";
            Wire wire1 = new(firstLocation1, secondLocation1, number1, layerName1);

            string firstLocation2 = "CONTROL PANEL";
            string secondLocation2 = "FHJB";
            string number2 = "1171";
            string layerName2 = "RED_16AWG";
            Wire wire2 = new(firstLocation2, secondLocation2, number2, layerName2);

            Assert.IsFalse(wire1.Equals(wire2));
            Assert.IsFalse(wire2.Equals(wire1));
        }

        [TestMethod]
        public void ShouldReturnFalseIfWireNumbersAreDifferent()
        {
            string firstLocation1 = "CONTROL PANEL";
            string secondLocation1 = "CONTROL PANEL";
            string number1 = "1171";
            string layerName1 = "RED_16AWG";
            Wire wire1 = new(firstLocation1, secondLocation1, number1, layerName1);

            string firstLocation2 = "CONTROL PANEL";
            string secondLocation2 = "CONTROL PANEL";
            string number2 = "1172";
            string layerName2 = "RED_16AWG";
            Wire wire2 = new(firstLocation2, secondLocation2, number2, layerName2);

            Assert.IsFalse(wire1.Equals(wire2));
            Assert.IsFalse(wire2.Equals(wire1));
        }

        [TestMethod]
        public void ShouldReturnFalseIfLayerNamesAreDifferent()
        {
            string firstLocation1 = "CONTROL PANEL";
            string secondLocation1 = "CONTROL PANEL";
            string number1 = "1171";
            string layerName1 = "RED_16AWG";
            Wire wire1 = new(firstLocation1, secondLocation1, number1, layerName1);

            string firstLocation2 = "CONTROL PANEL";
            string secondLocation2 = "CONTROL PANEL";
            string number2 = "1171";
            string layerName2 = "FIELD_16AWG";
            Wire wire2 = new(firstLocation2, secondLocation2, number2, layerName2);

            Assert.IsFalse(wire1.Equals(wire2));
            Assert.IsFalse(wire2.Equals(wire1));
        }

        [TestMethod]
        public void ShouldReturnTrueIfSameLocationsAreEqual()
        {
            string firstLocation1 = "CONTROL PANEL";
            string secondLocation1 = "ENTRANCE PANEL";
            string number1 = "1171";
            string layerName1 = "RED_16AWG";
            Wire wire1 = new(firstLocation1, secondLocation1, number1, layerName1);

            string firstLocation2 = "CONTROL PANEL";
            string secondLocation2 = "ENTRANCE PANEL";
            string number2 = "1171";
            string layerName2 = "RED_16AWG";
            Wire wire2 = new(firstLocation2, secondLocation2, number2, layerName2);

            Assert.IsTrue(wire1.Equals(wire2));
            Assert.IsTrue(wire2.Equals(wire1));
        }

        [TestMethod]
        public void ShouldReturnTrueIfSOppositeLocationsAreEqual()
        {
            string firstLocation1 = "CONTROL PANEL";
            string secondLocation1 = "FHJB";
            string number1 = "1171";
            string layerName1 = "RED_16AWG";
            Wire wire1 = new(firstLocation1, secondLocation1, number1, layerName1);

            string firstLocation2 = "FHJB";
            string secondLocation2 = "CONTROL PANEL";
            string number2 = "1171";
            string layerName2 = "RED_16AWG";
            Wire wire2 = new(firstLocation2, secondLocation2, number2, layerName2);

            Assert.IsTrue(wire1.Equals(wire2));
            Assert.IsTrue(wire2.Equals(wire1));
        }
    }
}