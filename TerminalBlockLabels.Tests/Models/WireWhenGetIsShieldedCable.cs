using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.IsShieldedCable"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetIsShieldedCable
    {
        [TestMethod]
        public void ShouldReturnTrueIfWireIsShielded()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "FEEDWATER VALVE";
            string number = "2261";
            string layerName = "SHIELDED_CABLE_18AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsShieldedCable);
        }

        [TestMethod]
        public void ShouldReturnFalseIfWireIsNotShielded()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "FEEDWATER VALVE";
            string number = "2261";
            string layerName = "FIELD_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.IsShieldedCable);
        }
    }
}