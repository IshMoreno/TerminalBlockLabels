using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.IsCriticalFuelWire"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetIsCriticalFuelWire
    {
        [TestMethod]
        public void ShouldReturnTrueIfWireIsViolet()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "GAS TRAIN";
            string number = "2051";
            string layerName = "VT_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsCriticalFuelWire);
        }

        [TestMethod]
        public void ShouldReturnFalseIfWireIsNotViolet()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "GAS TRAIN";
            string number = "2051";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.IsCriticalFuelWire);
        }
    }
}