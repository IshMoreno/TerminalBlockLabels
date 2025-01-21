using CleaverBrooks.Orders;
using System.IO;

namespace CleaverBrooks.TerminalStripUtility.Library.FileWriters
{
    /// <summary>
    /// Class that can be used to write a file that can be imported into the Wago software.
    /// </summary>
    public class TerminalStripFileWriter
    {
        private readonly IEnumerable<string> labels;
        private readonly ISerialNumber serialNumber;
        private readonly bool isHostPanel;

        /// <summary>
        /// Constructor for the <see cref="TerminalStripFileWriter"/> class.
        /// </summary>
        /// <param name="labels">The list of labels being written to the file.</param>
        /// <param name="serialNumber">Serial number for the order.</param>
        /// <param name="isHostPanel">Value indicating whether or not it's a host panel.</param>
        public TerminalStripFileWriter(IEnumerable<string> labels, ISerialNumber serialNumber, bool isHostPanel)
        {
            this.labels = labels;
            this.serialNumber = serialNumber;
            this.isHostPanel = isHostPanel;
        }

        /// <summary>
        /// The list of labels being written to the file.
        /// </summary>
        public IEnumerable<string> Labels
        {
            get { return labels; }
        }

        /// <summary>
        /// Serial number for the order.
        /// </summary>
        public ISerialNumber SerialNumber
        {
            get { return serialNumber; }
        }

        /// <summary>
        /// Value indicating whether or not it's a host panel.
        /// </summary>
        public bool IsHostPanel
        {
            get { return isHostPanel; }
        }

        /// <summary>
        /// Method that writes a CSV file for the order. The file will be written to the following directory: \\aqcorp.com\thv\Data\Data\Final Assembly Shared\Panel Shop\Terminal Blocks Production\.
        /// The file name will have HP at the end if it's for a Host Panel.
        /// Any blanks in the list of labels will be written as two commas, otherwise the value of the label will be written to the file.
        /// </summary>
        public async Task WriteFileAsync()
        {
            string outputDirectoryPath = @"\\aqcorp.com\thv\Data\Data\Final Assembly Shared\Panel Shop\Terminal Blocks Production\";
            string outputFilePath;
            if (isHostPanel)
            {
                outputFilePath = $"{outputDirectoryPath}{serialNumber.ConcatentatedSerialNumber}HP.csv";
            }
            else
            {
                outputFilePath = $"{outputDirectoryPath}{serialNumber.ConcatentatedSerialNumber}.csv";
            }

            using StreamWriter streamWriter = new(outputFilePath);

            foreach (string label in labels)
            {
                if (string.IsNullOrEmpty(label))
                {
                    await streamWriter.WriteLineAsync(",,");
                }
                else
                {
                    await streamWriter.WriteLineAsync(label);
                }
            }
        }
    }
}