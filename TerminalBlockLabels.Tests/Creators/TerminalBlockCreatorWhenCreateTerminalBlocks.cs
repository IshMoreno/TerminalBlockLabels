using CleaverBrooks.TerminalStripUtility.Library.Creators;
using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Creators
{
    /// <summary>
    /// Class for testing the <see cref="TerminalBlockCreator.CreateTerminalBlocks"/> method.
    /// </summary>
    [TestClass]
    public class TerminalBlockCreatorWhenCreateTerminalBlocks
    {
        [TestMethod]
        public void ShouldRemoveJumpers()
        {
            List<Wire> wires = new()
            {
                new("CONTROL PANEL", "CONTROL PANEL", "1171", "RED_16AWG"),
                new("ENTRANCE PANEL", "ENTRANCE PANEL", "1171", "RED_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);
            IEnumerable<TerminalBlock> terminalBlocks = terminalBlockCreator.CreateTerminalBlocks();

            Assert.AreEqual(0, terminalBlocks.Count());
        }

        [TestMethod]
        public void ShouldRemoveBlackWires()
        {
            List<Wire> wires = new()
            {
                new("EBOX STARTER", "EBOX STARTER", "1031", "BLK"),
                new("EBOX STARTER", "EBOX STARTER", "1032", "BLK")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);
            IEnumerable<TerminalBlock> terminalBlocks = terminalBlockCreator.CreateTerminalBlocks();

            Assert.AreEqual(0, terminalBlocks.Count());
        }

        [TestMethod]
        public void ShouldRemoveEthernetCables()
        {
            List<Wire> wires = new()
            {
                new("CP DOOR", "CP POWER", "3301", "ETHERNET_CABLE_22AWG"),
                new("CP POWER", "EBOX VSD", "3302", "ETHERNET_CABLE_22AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);
            IEnumerable<TerminalBlock> terminalBlocks = terminalBlockCreator.CreateTerminalBlocks();

            Assert.AreEqual(0, terminalBlocks.Count());
        }

        [TestMethod]
        public void ShouldRemoveDuplicateWiresThatOnlyCountOnce()
        {
            List<Wire> wires = new()
            {
                new("CONTROL PANEL", "ENTRANCE PANEL", "1171", "RED_16AWG"),
                new("CONTROL PANEL", "ENTRANCE PANEL", "1171", "RED_16AWG"),
                new("CONTROL PANEL", "ENTRANCE PANEL", "1171", "RED_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);
            IEnumerable<TerminalBlock> terminalBlocks = terminalBlockCreator.CreateTerminalBlocks();

            Assert.AreEqual(2, terminalBlocks.Count());
        }

        [TestMethod]
        public void ShouldCeilingUpForOddNumber()
        {
            List<Wire> wires = new()
            {
                new("CP POWER", "CONTROL PANEL", "1171", "RED_16AWG"),
                new("CP POWER", "CONTROL PANEL", "1171", "RED_16AWG"),
                new("CP POWER", "CONTROL PANEL", "1171", "RED_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);
            IEnumerable<TerminalBlock> terminalBlocks = terminalBlockCreator.CreateTerminalBlocks();

            Assert.AreEqual(2, terminalBlocks.Count());
        }

        [TestMethod]
        public void ShouldDivideByTwoForEvenNumber()
        {
            List<Wire> wires = new()
            {
                new("CP POWER", "CONTROL PANEL", "1171", "RED_16AWG"),
                new("CP POWER", "CONTROL PANEL", "1171", "RED_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);
            IEnumerable<TerminalBlock> terminalBlocks = terminalBlockCreator.CreateTerminalBlocks();

            Assert.AreEqual(1, terminalBlocks.Count());
        }

        [TestMethod]
        public void ShouldReturnRedTerminalBlockIfWireIsRed()
        {
            List<Wire> wires = new()
            {
                new("CP POWER", "CONTROL PANEL", "1171", "RED_16AWG")
            };

            TerminalBlockCreator terminalBlockCreator = new(wires);
            IEnumerable<TerminalBlock> terminalBlocks = terminalBlockCreator.CreateTerminalBlocks();

            Assert.AreEqual(1, terminalBlocks.Count());
            Assert.AreEqual("RED", terminalBlocks.ToList()[0].Color);
        }
    }
}