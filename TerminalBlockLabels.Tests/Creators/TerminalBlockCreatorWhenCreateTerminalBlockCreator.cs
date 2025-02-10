using CleaverBrooks.TerminalStripUtility.Library.Creators;
using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Creators
{
    /// <summary>
    /// Class for testing the constructor of the <see cref="TerminalBlockCreator"/> class.
    /// </summary>
    [TestClass]
    public class TerminalBlockCreatorWhenCreateTerminalBlockCreator
    {
        [TestMethod]
        public void ShouldCreate()
        {
            List<Wire> wires = new();
            TerminalBlockCreator terminalBlockCreator = new(wires);
            Assert.AreEqual(wires, terminalBlockCreator.Wires);
        }
    }
}