using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.IsWagoJumper"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetIsWagoJumper
    {
        [TestMethod]
        public void ShouldReturnTrueIfBothLocationsAreControlPanel()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsWagoJumper);
        }

        [TestMethod]
        public void ShouldReturnTrueIfBothLocationsAreEntrancePanel()
        {
            string firstLocation = "ENTRANCE PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsWagoJumper);
        }

        [TestMethod]
        public void ShouldReturnTrueIfBothLocationsAreFHJB()
        {
            string firstLocation = "FHJB";
            string secondLocation = "FHJB";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsWagoJumper);
        }

        [TestMethod]
        public void ShouldReturnTrueIfBothLocationsAreHostPanel()
        {
            string firstLocation = "HOST PANEL";
            string secondLocation = "HOST PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsWagoJumper);
        }

        [TestMethod]
        public void ShouldReturnTrueIfBothLocationsAreAlternatingCurrentPanel()
        {
            string firstLocation = "VAC PANEL";
            string secondLocation = "VAC PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsWagoJumper);
        }

        [TestMethod]
        public void ShouldReturnTrueIfBothLocationsAreDirectCurrentPanel()
        {
            string firstLocation = "VDC PANEL";
            string secondLocation = "VDC PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsWagoJumper);
        }

        [TestMethod]
        public void ShouldReturnFalseIfBothLocationsAreNotTerminals()
        {
            string firstLocation = "CP RELAY";
            string secondLocation = "CP RELAY";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.IsWagoJumper);
        }
    }
}