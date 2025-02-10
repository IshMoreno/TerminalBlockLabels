using CleaverBrooks.TerminalStripUtility.Library.Creators;
using CleaverBrooks.TerminalStripUtility.Library.Models;
namespace CleaverBrooks.TerminalStripUtility.Tests.Creators
{
    /// <summary>
    /// Class for testing the <see cref="TerminalBlockCreator.GetTerminalBlockColor"/> method.
    /// </summary>
    [TestClass]
    public class TerminalBlockCreatorWhenGetTerminalBlockColor
    {
        [TestMethod]
        public void ShouldReturnRedTerminalBlock()
        {
            List<Wire> wires = new()
            {
                new Wire("CONTROL PANEL", "CONTROL PANEL", "1171", "RED_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "2571", "ORG_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "1221", "RED_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "1222", "RED_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "1223", "RED_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);

            string terminalBlockColor = terminalBlockCreator.GetTerminalBlockColor(wires[0]);

            Assert.AreEqual("RED", terminalBlockColor);
        }

        [TestMethod]
        public void ShouldReturnGrayTerminalBlock()
        {
            List<Wire> wires = new()
            {
                new Wire("CONTROL PANEL", "CONTROL PANEL", "1173", "WHT_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "2572", "WHT/ORG_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "3342", "WHT/ORG_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "1073", "WHT_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "1002", "WHT_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);

            string terminalBlockColor = terminalBlockCreator.GetTerminalBlockColor(wires[0]);

            Assert.AreEqual("GRAY", terminalBlockColor);
        }

        [TestMethod]
        public void ShouldReturnOrangeTerminalBlock()
        {
            List<Wire> wires = new()
            {
                new Wire("CONTROL PANEL", "CONTROL PANEL", "2091", "VT_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "2092", "VT_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "2093", "VT_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "2094", "VT_16AWG"),
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);

            string terminalBlockColor = terminalBlockCreator.GetTerminalBlockColor(wires[0]);

            Assert.AreEqual("ORANGE", terminalBlockColor);
        }

        [TestMethod]
        public void ShouldReturnBlueTerminalBlock()
        {

            List<Wire> wires = new()
            {
                new Wire("CONTROL PANEL", "CONTROL PANEL", "3111", "BLU_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "3112", "WHT/BLU_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "3013", "BLU_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "3013", "BLU_16AWG"),
                new Wire("CONTROL PANEL", "CONTROL PANEL", "3014", "WHT/BLU_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);

            string terminalBlockColor = terminalBlockCreator.GetTerminalBlockColor(wires[0]);

            Assert.AreEqual("BLUE", terminalBlockColor);
        }

        [TestMethod]
        public void ShouldNotReturnAnyBlock()
        {
            List<Wire> wires = new()
            {
                new Wire("ENTRANCE PANEL", "ENTRANCE PANEL", "1090", "BLK_16AWG"),
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);

            var exception = Assert.ThrowsException<Exception>(() => terminalBlockCreator.GetTerminalBlockColor(wires[0]));
            Assert.AreEqual("A terminal block color could not be determined for this wire.", exception.Message);
        }
    }
}