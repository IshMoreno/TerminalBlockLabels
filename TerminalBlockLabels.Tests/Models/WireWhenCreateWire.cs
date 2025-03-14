using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the constructor of the <see cref="Wire"/> class.
    /// </summary>
    [TestClass]
    public class WireWhenCreateWire
    {
        [TestMethod]
        public void ShouldCreate()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.AreEqual(firstLocation, wire.FirstLocation);
            Assert.AreEqual(secondLocation, wire.SecondLocation);
            Assert.AreEqual(number, wire.Number);
            Assert.AreEqual(layerName, wire.LayerName);
        }
    }
}