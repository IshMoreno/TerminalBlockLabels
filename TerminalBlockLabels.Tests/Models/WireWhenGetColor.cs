using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing <see cref="Wire.Color"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetColor
    {
        [TestMethod]
        public void ShouldReturnNaForEthernetCable()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "ETHERNET_CABLE_22AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.AreEqual("NA", wire.Color);
        }

        [TestMethod]
        public void ShouldReturnNaForShieldedCable()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "SHIELDED_CABLE_22AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.AreEqual("NA", wire.Color);
        }

        [TestMethod]
        public void ShouldReturnNaForFieldWire()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "FIELD_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.AreEqual("NA", wire.Color);
        }

        [TestMethod]
        public void ShouldReturnColorForSolidWire()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.AreEqual("RED", wire.Color);
        }

        [TestMethod]
        public void ShouldReturnColorsForStripedWire()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "WHT_BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.AreEqual("WHT/BLU", wire.Color);
        }
    }
}