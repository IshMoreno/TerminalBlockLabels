using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the constructor of the <see cref="TerminalBlock"/> class.
    /// </summary>
    [TestClass]
    public class TerminalBlockWhenCreateTerminalBlock
    {
        [TestMethod]
        public void ShouldCreate()
        {
            string number = "1171";
            string color = "RED";
            string panel = "CONTROL PANEL";
            bool isForShieldedCable = false;

            TerminalBlock terminalBlock = new(number, color, panel, isForShieldedCable);

            Assert.AreEqual(number, terminalBlock.Number);
            Assert.AreEqual(color, terminalBlock.Color);
            Assert.AreEqual(panel, terminalBlock.Panel);
            Assert.AreEqual(isForShieldedCable, terminalBlock.IsForShieldedCable);
        }
    }
}