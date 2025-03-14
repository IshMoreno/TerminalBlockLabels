using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="TerminalBlock.Rung"/> property.
    /// </summary>
    [TestClass]
    public class TerminalBlockWhenGetRung
    {
        [TestMethod]
        public void ShouldReturnCorrectValue()
        {
            string number = "1171";
            string color = "RED";
            string panel = "CONTROL PANEL";

            TerminalBlock terminalBlock = new(number, color, panel, false);

            Assert.AreEqual(117, terminalBlock.Rung);
        }
    }
}