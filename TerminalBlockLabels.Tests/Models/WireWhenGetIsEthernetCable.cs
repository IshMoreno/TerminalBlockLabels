using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.IsEthernetCable"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetIsEthernetCable
    {
        [TestMethod]
        public void ShouldReturnFalseIfWireIsNotEthernetCable()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.IsEthernetCable);
        }

        [TestMethod]
        public void ShouldReturnTrueIfWireIsEthernetCable()
        {
            string firstLocation = "CP DOOR";
            string secondLocation = "CP POWER";
            string number = "3011";
            string layerName = "ETHERNET_CABLE_22AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsEthernetCable);
        }
    }
}