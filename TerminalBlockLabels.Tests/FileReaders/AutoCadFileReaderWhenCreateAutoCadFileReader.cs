using CleaverBrooks.Orders;
using CleaverBrooks.TerminalStripUtility.Library.FileReaders;

namespace CleaverBrooks.TerminalStripUtility.Tests.FileReaders
{
    /// <summary>
    /// Class for testing the constructor for the <see cref="AutoCadFileReader"/> class.
    /// </summary>
    [TestClass]
    public class AutoCadFileReaderWhenCreateAutoCadFileReader
    {
        [TestMethod]
        public void ShouldCreateFromFilepath()
        {
            string filepath = @"C:\T1234-1-1.csv";
            AutoCadFileReader autoCadFileReader = new(filepath);
            Assert.AreEqual(filepath, autoCadFileReader.Filepath);
        }

        [TestMethod]
        public void ShouldCreateFromSerialNumberWhenHostPanel()
        {
            SerialNumber serialNumber = new("T1234-1-1");
            bool isHostPanel = true;

            AutoCadFileReader autoCadFileReader = new(serialNumber, isHostPanel);

            Assert.AreEqual(@"\\aqcorp.com\thv\CAD\Submit\Wire Marker Files\T1234-1-1HP.csv", autoCadFileReader.Filepath);
        }

        [TestMethod]
        public void ShouldCreateFromSerialNumberWhenNotHostPanel()
        {
            SerialNumber serialNumber = new("T1234-1-1");
            bool isHostPanel = false;

            AutoCadFileReader autoCadFileReader = new(serialNumber, isHostPanel);

            Assert.AreEqual(@"\\aqcorp.com\thv\CAD\Submit\Wire Marker Files\T1234-1-1.csv", autoCadFileReader.Filepath);
        }
    }
}