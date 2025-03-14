using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="TerminalBlock.TerminalIdentifier"/> property.
    /// </summary>
    [TestClass]
    public class TerminalBlockWhenGetTerminalIdentifier
    {
        [TestMethod]
        public void ShouldReturnCorrectValueIfLastCharacterIsNumber()
        {
            string number = "1171";
            string color = "RED";
            string panel = "CONTROL PANEL";

            TerminalBlock terminalBlock = new(number, color, panel, false);

            Assert.AreEqual(1, terminalBlock.TerminalIdentifier);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueIfLastCharacterIsLetter()
        {
            string number = "117A";
            string color = "RED";
            string panel = "CONTROL PANEL";

            TerminalBlock terminalBlock = new(number, color, panel, false);

            Assert.AreEqual(10, terminalBlock.TerminalIdentifier);
        }
    }
}