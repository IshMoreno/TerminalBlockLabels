using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.TerminatesAt(string)"/> method.
    /// </summary>
    [TestClass]
    public class WireWhenTerminatesAt
    {
        [TestMethod]
        public void ShouldReturnTrueIfSpecifiedLocationEqualsFirstLocation()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.TerminatesAt("CONTROL PANEL"));
        }

        [TestMethod]
        public void ShouldReturnTrueIfSpecifiedLocationEqualsSecondLocation()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.TerminatesAt("ENTRANCE PANEL"));
        }

        [TestMethod]
        public void ShouldReturnTrueIfSpecifiedLocationEqualsBothLocations()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.TerminatesAt("CONTROL PANEL"));
        }

        [TestMethod]
        public void ShouldReturnFalseIfSpecifiedLocationDoesNotEqualEitherLocation()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.TerminatesAt("FHJB"));
        }
    }
}