using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.CarriesAlternatingCurrent"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetCarriesAlternatingCurrent
    {
        [TestMethod]
        public void ShouldReturnTrueIfWireIsRed()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.CarriesAlternatingCurrent);
        }

        [TestMethod]
        public void ShouldReturnTrueIfWireIsWhite()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1173";
            string layerName = "WHT_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.CarriesAlternatingCurrent);
        }

        [TestMethod]
        public void ShouldReturnTrueIfWireIsViolet()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "VT_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.CarriesAlternatingCurrent);
        }

        [TestMethod]
        public void ShouldReturnTrueIfWireIsOrange()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "2175";
            string layerName = "ORG_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.CarriesAlternatingCurrent);
        }

        [TestMethod]
        public void ShouldReturnTrueIfWireIsWhiteOrange()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "2176";
            string layerName = "WHT_ORG_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.CarriesAlternatingCurrent);
        }

        [TestMethod]
        public void ShouldReturnFalseIfWireDoesNotCarryAlternativeCurrent()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "3111";
            string layerName = "BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.CarriesAlternatingCurrent);
        }
    }
}