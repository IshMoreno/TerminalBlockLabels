using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.IsFieldWire"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetIsFieldWire
    {
        [TestMethod]
        public void ShouldReturnTrueIfWireIsFieldWire()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "FEEDWATER VALVE";
            string number = "2261";
            string layerName = "FIELD_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.IsFieldWire);
        }

        [TestMethod]
        public void ShouldReturnFalseIfWireIsNotFieldWire()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "FEEDWATER VALVE";
            string number = "2261";
            string layerName = "SHIELDED_CABLE_18AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.IsFieldWire);
        }
    }
}