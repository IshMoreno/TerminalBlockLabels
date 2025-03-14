using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="Wire.OnlyCountsOnce"/> property.
    /// </summary>
    [TestClass]
    public class WireWhenGetOnlyCountsOnce
    {
        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsControlPanelAndSecondLocationIsEntrancePanel()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsEntrancePanelAndSecondLocationIsControlPanel()
        {
            string firstLocation = "ENTRANCE PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsControlPanelAndSecondLocationIsFHJB()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "FHJB";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsFHJBAndSecondLocationIsControlPanel()
        {
            string firstLocation = "FHJB";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsAlternatingCurrentPanelAndSecondLocationIsControlPanel()
        {
            string firstLocation = "VAC PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsControlPanelAndSecondLocationIsAlternatingCurrentPanel()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "VAC PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsDirectCurrentPanelAndSecondLocationIsControlPanel()
        {
            string firstLocation = "VDC PANEL";
            string secondLocation = "CONTROL PANEL";
            string number = "3111";
            string layerName = "BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsControlPanelAndSecondLocationIsDirectCurrentPanel()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "VDC PANEL";
            string number = "3111";
            string layerName = "BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsAlternatingCurrentPanelAndSecondLocationIsEntrancePanel()
        {
            string firstLocation = "VAC PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsEntrancePanelAndSecondLocationIsAlternatingCurrentPanel()
        {
            string firstLocation = "ENTRANCE PANEL";
            string secondLocation = "VAC PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsDirectCurrentPanelAndSecondLocationIsEntrancePanel()
        {
            string firstLocation = "VDC PANEL";
            string secondLocation = "ENTRANCE PANEL";
            string number = "3111";
            string layerName = "BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsEntrancePanelAndSecondLocationIsDirectCurrentPanel()
        {
            string firstLocation = "ENTRANCE PANEL";
            string secondLocation = "VDC PANEL";
            string number = "3111";
            string layerName = "BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsAlternatingCurrentPanelAndSecondLocationIsFHJB()
        {
            string firstLocation = "VAC PANEL";
            string secondLocation = "FHJB";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsFHJBAndSecondLocationIsAlternatingCurrentPanel()
        {
            string firstLocation = "FHJB";
            string secondLocation = "VAC PANEL";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsDirectCurrentPanelAndSecondLocationIsFHJB()
        {
            string firstLocation = "VDC PANEL";
            string secondLocation = "FHJB";
            string number = "3111";
            string layerName = "BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnTrueIfFirstLocationIsFHJBAndSecondLocationIsDirectCurrentPanel()
        {
            string firstLocation = "FHJB";
            string secondLocation = "VDC PANEL";
            string number = "3111";
            string layerName = "BLU_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsTrue(wire.OnlyCountsOnce);
        }

        [TestMethod]
        public void ShouldReturnFalseIfFirstLocationIsControlPanelAndSecondLocationIsCPRelay()
        {
            string firstLocation = "CONTROL PANEL";
            string secondLocation = "CP RELAY";
            string number = "1171";
            string layerName = "RED_16AWG";

            Wire wire = new(firstLocation, secondLocation, number, layerName);

            Assert.IsFalse(wire.OnlyCountsOnce);
        }
    }
}