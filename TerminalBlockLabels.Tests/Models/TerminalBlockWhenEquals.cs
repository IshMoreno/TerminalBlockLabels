using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.Models
{
    /// <summary>
    /// Class for testing the <see cref="TerminalBlock.Equals(object?)"/> method.
    /// </summary>
    [TestClass]
    public class TerminalBlockWhenEquals
    {
        [TestMethod]
        public void ShouldReturnFalseIfNumbersAreDifferent()
        {
            string firstNumber = "1171";
            string firstColor = "RED";
            string firstPanel = "CONTROL PANEL";
            TerminalBlock firstTerminalBlock = new(firstNumber, firstColor, firstPanel, false);

            string secondNumber = "8271";
            string secondColor = "RED";
            string secondPanel = "CONTROL PANEL";
            TerminalBlock secondTerminalBlock = new(secondNumber, secondColor, secondPanel, false);

            Assert.IsFalse(firstTerminalBlock.Equals(secondTerminalBlock));
            Assert.IsFalse(secondTerminalBlock.Equals(firstTerminalBlock));
        }

        [TestMethod]
        public void ShouldReturnFalseIfColorsAreDifferent()
        {
            string firstNumber = "1171";
            string firstColor = "RED";
            string firstPanel = "CONTROL PANEL";
            TerminalBlock firstTerminalBlock = new(firstNumber, firstColor, firstPanel, false);

            string secondNumber = "1173";
            string secondColor = "GRAY";
            string secondPanel = "CONTROL PANEL";
            TerminalBlock secondTerminalBlock = new(secondNumber, secondColor, secondPanel, false);

            Assert.IsFalse(firstTerminalBlock.Equals(secondTerminalBlock));
            Assert.IsFalse(secondTerminalBlock.Equals(firstTerminalBlock));
        }

        [TestMethod]
        public void ShouldReturnFalseIfPanelsAreDifferent()
        {
            string firstNumber = "1171";
            string firstColor = "RED";
            string firstPanel = "CONTROL PANEL";
            TerminalBlock firstTerminalBlock = new(firstNumber, firstColor, firstPanel, false);

            string secondNumber = "1171";
            string secondColor = "GRAY";
            string secondPanel = "FHJB";
            TerminalBlock secondTerminalBlock = new(secondNumber, secondColor, secondPanel, false);

            Assert.IsFalse(firstTerminalBlock.Equals(secondTerminalBlock));
            Assert.IsFalse(secondTerminalBlock.Equals(firstTerminalBlock));
        }

        [TestMethod]
        public void ShouldReturnTrueIfOppositesAreEqual()
        {
            string firstNumber = "8271";
            string firstColor = "RED";
            string firstPanel = "FHJB";
            TerminalBlock firstTerminalBlock = new(firstNumber, firstColor, firstPanel, false);

            string secondNumber = "8271";
            string secondColor = "RED";
            string secondPanel = "FHJB";
            TerminalBlock secondTerminalBlock = new(secondNumber, secondColor, secondPanel, false);

            Assert.IsTrue(firstTerminalBlock.Equals(secondTerminalBlock));
            Assert.IsTrue(secondTerminalBlock.Equals(firstTerminalBlock));
        }
    }
}