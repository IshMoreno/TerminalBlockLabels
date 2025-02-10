using CleaverBrooks.Orders;
using CleaverBrooks.TerminalStripUtility.Library.Creators;
using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Creators
{
    /// <summary>
    /// Class for testing the constructor of the <see cref="LabelCreator"/> class.
    /// </summary>
    [TestClass]
    public class LabelCreatorWhenCreateLabelCreator
    {
        [TestMethod]
        public void ShouldCreate()
        {
            List<TerminalBlock> terminalBlocks = new();
            SerialNumber serialNumber = new("T1234-1-1");

            LabelCreator labelCreator = new(terminalBlocks, serialNumber);

            Assert.AreEqual(terminalBlocks, labelCreator.TerminalBlocks);
        }
    }
}