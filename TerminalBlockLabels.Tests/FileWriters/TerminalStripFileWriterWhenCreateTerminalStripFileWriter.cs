using CleaverBrooks.Orders;
using CleaverBrooks.TerminalStripUtility.Library.FileWriters;

namespace CleaverBrooks.TerminalStripUtility.Tests.FileWriters
{
    /// <summary>
    /// Class for testing the constructor of the <see cref="TerminalStripFileWriter"/> class.
    /// </summary>
    [TestClass]
    public class TerminalStripFileWriterWhenCreateTerminalStripFileWriter
    {
        [TestMethod]
        public void ShouldCreate()
        {
            List<string> labels = new();
            SerialNumber serialNumber = new("T1234-1-1");
            bool isHostPanel = false;

            TerminalStripFileWriter terminalStripFileWriter = new(labels, serialNumber, isHostPanel);

            Assert.AreEqual(labels, terminalStripFileWriter.Labels);
            Assert.AreEqual(serialNumber, terminalStripFileWriter.SerialNumber);
            Assert.AreEqual(isHostPanel, terminalStripFileWriter.IsHostPanel);
        }
    }
}