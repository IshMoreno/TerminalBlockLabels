using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.IsNeutral"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetIsNeutral
    {
        [TestMethod]
        public void ShouldReturnTrueIfWireIsWhiteNeutral()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1173";
            string layerName = "WHT_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsNeutral);
        }

        [TestMethod]
        public void ShouldReturnTrueIfWireIsWhiteOrangeNeutral()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1173";
            string layerName = "WHT_ORG_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsNeutral);
        }

        [TestMethod]
        public void ShouldReturnFalseIfWireIsWhiteBlue()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "3112";
            string layerName = "WHT_BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.IsNeutral);
        }

        [TestMethod]
        public void ShouldReturnFalseIfWireIsOtherColor()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.IsNeutral);
        }
    }
}