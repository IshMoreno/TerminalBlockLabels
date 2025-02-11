using CleaverBrooks.TerminalStripUtility.Library.Exceptions;
using CleaverBrooks.TerminalStripUtility.Library.FileReaders;
using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Tests.FileReaders
{
    /// <summary>
    /// Class for testing the <see cref="AutoCadFileReader.ReadFileAsync"/> method.
    /// </summary>
    [TestClass]
    public class AutoCadFileReaderWhenReadFileAsync
    {
        [TestMethod]
        public void ShouldThrowInvalidFileException()
        {
            string directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\";
            string filepath = directoryPath + "InvalidAutoCADFile.csv";
            AutoCadFileReader reader = new(filepath);
            Assert.ThrowsExceptionAsync<FileNotFoundException>(() => reader.ReadFileAsync());
        }

        [TestMethod]
        public async Task ShouldReadValidFile()
        {
            string directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\";
            string filepath = directoryPath + "ValidAutoCADFile.csv";
            AutoCadFileReader reader = new(filepath);
            IEnumerable<Wire> wires = await reader.ReadFileAsync();
            Assert.AreEqual(1, wires.Count());
            Assert.AreEqual("CP POWER", wires.ElementAt(0).FirstLocation);
            Assert.AreEqual("CONTROL PANEL", wires.ElementAt(0).SecondLocation);
            Assert.AreEqual("3111", wires.ElementAt(0).Number);
            Assert.AreEqual("BLU_16AWG", wires.ElementAt(0).LayerName);
        }

        [TestMethod]
        public async Task ShouldReadFileIfTooManyHeaders()
        {
            string directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\";
            string filepath = directoryPath + "AutoCADFileWithTooManyHeaders.csv";
            AutoCadFileReader reader = new(filepath);
            IEnumerable<Wire> wires = await reader.ReadFileAsync();
            Assert.AreEqual(4, wires.Count());
        }

        [TestMethod]
        public async Task ShouldReadFileHeadersAreOutOfOrder()
        {
            string directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\";
            string filepath = directoryPath + "AutoCADFileWithTooManyHeaders.csv";
            AutoCadFileReader reader = new(filepath);
            IEnumerable<Wire> wires = await reader.ReadFileAsync();
            Assert.AreEqual(4, wires.Count());
        }

        [TestMethod]
        public void ShouldThrowExceptionIfWireNumberIsMissing()
        {
            string directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\";
            string filepath = directoryPath + "AutoCADFileWithMissingWireNumber.csv";
            AutoCadFileReader reader = new(filepath);
            Assert.ThrowsExceptionAsync<MissingWireNumberException>(() => reader.ReadFileAsync());
        }

        [TestMethod]
        public void ShouldThrowExceptionIfAHeaderIsMissing()
        {
            string directoryPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Resources\";
            string filepath = directoryPath + "AutoCADFileWithMissingHeader.csv";
            AutoCadFileReader reader = new(filepath);
            Assert.ThrowsExceptionAsync<MissingHeaderException>(() => reader.ReadFileAsync());
        }
    }
}