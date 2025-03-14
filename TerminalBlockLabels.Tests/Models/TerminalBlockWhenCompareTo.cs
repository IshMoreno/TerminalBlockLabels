using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="TerminalBlock.CompareTo(TerminalBlock?)"/> method.
    /// </summary>
    [TestClass]
    public class TerminalBlockWhenCompareTo
    {
        [TestMethod]
        public void ShouldReturnCorrectValueForControlAndEntrancePanels()
        {
            string firstNumber = "1171";
            string firstColor = "RED";
            string firstPanel = "CONTROL PANEL";
            TerminalBlock firstTerminalBlock = new(firstNumber, firstColor, firstPanel, false);

            string secondNumber = "1171";
            string secondColor = "RED";
            string secondPanel = "ENTRANCE PANEL";
            TerminalBlock secondTerminalBlock = new(secondNumber, secondColor, secondPanel, false);

            Assert.IsTrue(firstTerminalBlock.CompareTo(secondTerminalBlock) < 0);
            Assert.IsTrue(secondTerminalBlock.CompareTo(firstTerminalBlock) > 0);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForControlAndFHJBPanels()
        {
            string firstNumber = "1171";
            string firstColor = "RED";
            string firstPanel = "CONTROL PANEL";
            TerminalBlock firstTerminalBlock = new(firstNumber, firstColor, firstPanel, false);

            string secondNumber = "1171";
            string secondColor = "RED";
            string secondPanel = "FHJB";
            TerminalBlock secondTerminalBlock = new(secondNumber, secondColor, secondPanel, false);

            Assert.IsTrue(firstTerminalBlock.CompareTo(secondTerminalBlock) < 0);
            Assert.IsTrue(secondTerminalBlock.CompareTo(firstTerminalBlock) > 0);
        }

        [TestMethod]
        public void ShouldReturnCorrectValueForEntranceAndFHJBPanels()
        {
            string firstNumber = "1171";
            string firstColor = "RED";
            string firstPanel = "ENTRANCE PANEL";
            TerminalBlock firstTerminalBlock = new(firstNumber, firstColor, firstPanel, false);

            string secondNumber = "1171";
            string secondColor = "RED";
            string secondPanel = "FHJB";
            TerminalBlock secondTerminalBlock = new(secondNumber, secondColor, secondPanel, false);

            Assert.IsTrue(firstTerminalBlock.CompareTo(secondTerminalBlock) < 0);
            Assert.IsTrue(secondTerminalBlock.CompareTo(firstTerminalBlock) > 0);
        }
    }
}
