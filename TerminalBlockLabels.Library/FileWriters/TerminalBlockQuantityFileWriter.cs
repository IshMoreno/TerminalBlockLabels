using CleaverBrooks.Orders;
using CleaverBrooks.TerminalStripUtility.Library.Creators;
using CleaverBrooks.TerminalStripUtility.Library.Models;
using System.IO;
using System.Text;

namespace CleaverBrooks.TerminalStripUtility.Library.FileWriters
{
    /// <summary>
    /// Class used to export a text file containing the number of terminals per color per panel.
    /// </summary>
    public class TerminalBlockQuantityFileWriter
    {
        private readonly IEnumerable<TerminalBlock> terminalBlocks;
        private readonly ISerialNumber serialNumber;
        private readonly bool isHostPanel;

        /// <summary>
        /// The constructor for the <see cref="TerminalBlockQuantityFileWriter"/> class.
        /// </summary>
        /// <param name="terminalBlocks">A list of terminals block objects.</param>
        /// <param name="serialNumber">Serial number for the order.</param>
        /// <param name="isHostPanel">Value indicating whether or not it's a host panel.</param>
        public TerminalBlockQuantityFileWriter(IEnumerable<TerminalBlock> terminalBlocks, ISerialNumber serialNumber, bool isHostPanel)
        {
            this.terminalBlocks = terminalBlocks;
            this.serialNumber = serialNumber;
            this.isHostPanel = isHostPanel;
        }

        /// <summary>
        /// A list of terminal block objects.
        /// </summary>
        public IEnumerable<TerminalBlock> TerminalBlocks
        {
            get { return terminalBlocks; }
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
        /// Method used to print out to a .txt file the quantity of each terminal color for each panel.
        /// </summary>
        public async Task WriteFileAsync()
        {
            string outputDirectoryPath = @"\\aqcorp.com\thv\Data\Data\Final Assembly Shared\Panel Shop\Terminal Blocks Production\";
            string outputFilePath;
            if (isHostPanel)
            {
                outputFilePath = $"{outputDirectoryPath}{serialNumber.ConcatentatedSerialNumber}HP Terminal Quantity.txt";
            }
            else
            {
                outputFilePath = $"{outputDirectoryPath}{serialNumber.ConcatentatedSerialNumber} Terminal Quantity.txt";
            }

            using FileStream fileStream = new(outputFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true);

            StringBuilder contentBuilder = new();
            contentBuilder.AppendLine("TERMINAL BLOCKS PER PANEL");
            contentBuilder.AppendLine();

            var terminalsGroupedByPanel = terminalBlocks.GroupBy(terminalBlock => terminalBlock.Panel);

            foreach (var panel in terminalsGroupedByPanel)
            {
                contentBuilder.AppendLine(panel.Key);

                var terminalsGroupedByColor = panel.GroupBy(terminalBlock => terminalBlock.Color);

                foreach (var terminalBlockColor in terminalsGroupedByColor)
                {
                    contentBuilder.AppendLine($"{terminalBlockColor.Key}: {terminalBlockColor.Count()}");

                    if (terminalBlockColor.Key.Equals("BLUE"))
                    {
                        if (terminalBlockColor.Any(terminalBlock => terminalBlock.IsForShieldedCable))
                        {
                            int numberOfTerminalBlocksForShieldedCables = terminalBlockColor.Count(terminalBlock => terminalBlock.IsForShieldedCable);
                            int numberOfShieldedGroundLabels = LabelCreator.GetNumberOfShieldedGroundLabels(numberOfTerminalBlocksForShieldedCables);

                            contentBuilder.AppendLine($"GREEN: {numberOfShieldedGroundLabels}");
                        }
                    }
                }

                contentBuilder.AppendLine();
            }

            string content = contentBuilder.ToString();
            byte[] encodedText = Encoding.UTF8.GetBytes(content);
            await fileStream.WriteAsync(encodedText);
        }
    }
}