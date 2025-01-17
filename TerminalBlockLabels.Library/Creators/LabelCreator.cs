using CleaverBrooks.Orders;
using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Library.Creators
{
    /// <summary>
    /// Class for creating a list of labels based on a list of terminal blocks.
    /// </summary>
    public class LabelCreator
    {
        private readonly IEnumerable<TerminalBlock> terminalBlocks;
        private readonly ISerialNumber serialNumber;

        /// <summary>
        /// Constructor for the <see cref="LabelCreator"/> class.
        /// </summary>
        /// <param name="terminalBlocks">The list of terminal blocks that the list of labels is being created from.</param>
        /// <param name="serialNumber">The serial number that the labels are being created for.</param>
        public LabelCreator(IEnumerable<TerminalBlock> terminalBlocks, ISerialNumber serialNumber)
        {
            this.terminalBlocks = terminalBlocks;
            this.serialNumber = serialNumber;
        }

        /// <summary>
        /// The list of terminal blocks that the list of labels is being created from.
        /// </summary>
        public IEnumerable<TerminalBlock> TerminalBlocks { get { return terminalBlocks; } }

        /// <summary>
        /// The serial number that the labels are being created for.
        /// </summary>
        public ISerialNumber SerialNumber { get { return serialNumber; } }

        /// <summary>
        /// Creates labels for various panels.
        /// </summary>
        /// <returns>
        /// Returns an IEnumerable collection of strings represeting labels for different panels.
        /// </returns>
        public IEnumerable<string> CreateLabels()
        {
            List<string> labels = new()
            {
                serialNumber.ConcatentatedSerialNumber,
                ""
            };

            labels.AddRange(GetPanelLabelsFor("CONTROL PANEL"));
            labels.AddRange(GetPanelLabelsFor("ENTRANCE PANEL"));
            labels.AddRange(GetPanelLabelsFor("FHJB"));
            labels.AddRange(GetPanelLabelsFor("HOST PANEL"));
            labels.AddRange(GetPanelLabelsFor("VAC PANEL"));
            labels.AddRange(GetPanelLabelsFor("VDC PANEL"));
            labels.AddRange(GetPanelLabelsFor("ELECTRIC BOILER PANEL"));

            return labels;
        }

        /// <summary>
        /// Retrieves sorted labels for a specified panel, and inserts a blank string if there are blue terminals. Then, it adds "SG" if there are
        /// shielded cables.
        /// </summary>
        /// <param name="panel">The name of the panel for which labels are to be retrieved.</param>
        /// <returns>
        /// Returns a list of strings representing labels for the specified panel.
        /// </returns>
        private List<string> GetPanelLabelsFor(string panel)
        {
            List<string> labelsForPanel = new();

            string shortenedPanelName = GetShortenedPanelName (panel);
            labelsForPanel.Add(shortenedPanelName);

            List<TerminalBlock> terminalBlocksForPanel = terminalBlocks.Where(terminalBlock => terminalBlock.Panel.Equals(panel)).ToList();
            terminalBlocksForPanel.Sort();

            foreach(TerminalBlock terminalBlock in terminalBlocksForPanel)
            {
                labelsForPanel.Add(terminalBlock.Number);
            }

            int indexOfFirstBlueTerminalBlock = 0;

            if (terminalBlocksForPanel.Any(terminalBlock => terminalBlock.Color.Equals("BLUE")))
            {
                TerminalBlock firstBlueTerminalBlock = terminalBlocksForPanel.Where(terminalBlock => terminalBlock.Color.Equals("BLUE")).FirstOrDefault()!;

                indexOfFirstBlueTerminalBlock = terminalBlocksForPanel.IndexOf(firstBlueTerminalBlock);

                labelsForPanel.Insert(indexOfFirstBlueTerminalBlock + 1, "");
            }

            if(terminalBlocksForPanel.Any(terminalBlock => terminalBlock.IsForShieldedCable))
            {
                int numberOfTerminalBlocksForShieldedCables = terminalBlocksForPanel.Count(terminalBlock => terminalBlock.IsForShieldedCable);
                int numberOfShieldedGroundLabels = GetNumberOfShieldedGroundLabels(numberOfTerminalBlocksForShieldedCables);

                if (numberOfShieldedGroundLabels.Equals(1))
                {
                    labelsForPanel.Add("SG");
                }
                else
                {
                    for (int i = 1; i <= numberOfShieldedGroundLabels; i++)
                    {
                        int insertionIndex = indexOfFirstBlueTerminalBlock + 2 + (i * 5) + (i - 1);
                        labelsForPanel.Insert(insertionIndex, "SG");
                    }
                }
            }

            labelsForPanel = SwapShieldedGroundLabels(labelsForPanel);
            labelsForPanel.Add("");

            if (labelsForPanel.Count > 2)
            {
                return labelsForPanel;
            }
            else
            {
                labelsForPanel = new();
                return labelsForPanel;
            }
        }

        /// <summary>
        /// Helper method that moves the SG labels if the label before and after are the same.
        /// </summary>
        /// <param name="labelsForPanel">List of labels for a panel.</param>
        /// <returns>A list of labels for a panel with the SG labels in the correct place.</returns>
        private static List<string> SwapShieldedGroundLabels(List<string> labelsForPanel)
        {
            for (int i = 1; i < labelsForPanel.Count - 1; i++)
            {
                if (labelsForPanel[i].Equals("SG") && labelsForPanel[i - 1].Equals(labelsForPanel[i + 1]))
                {
                    (labelsForPanel[i + 1], labelsForPanel[i]) = (labelsForPanel[i], labelsForPanel[i + 1]);
                }
            }

            return labelsForPanel;
        }

        /// <summary>
        /// Helper method used to determine the number of shielded ground terminals required.
        /// </summary>
        /// <param name="numberOfTerminalBlocksForShieldedCable">The number of terminal blocks that are for shielded cables.</param>
        /// <returns>The number of shielded ground terminal labels.</returns>
        public static int GetNumberOfShieldedGroundLabels(int numberOfTerminalBlocksForShieldedCable)
        {
            if (numberOfTerminalBlocksForShieldedCable <= 6)
            {
                return 1;
            }
            else
            {
                int numberOfShieldedGroundLabels = (int)(Math.Floor((double)(numberOfTerminalBlocksForShieldedCable - 7) / 8.0)) + 2;
                return numberOfShieldedGroundLabels;
            }
        }

        /// <summary>
        /// Retrieves a shortened name for the specified panel.
        /// </summary>
        /// <param name="panel">The name of the panel.</param>
        /// <returns>
        /// Returns a shortened name for the specified panel.
        /// </returns>
        /// <exception cref="Exception">Thrown when the panel name is invalid.</exception>
        private static string GetShortenedPanelName(string panel)
        {
            if(panel.Equals("CONTROL PANEL"))
            {
                return "CP";
            }

            else if(panel.Equals("ENTRANCE PANEL"))
            {
                return "EBOX";
            }

            else if (panel.Equals("FHJB"))
            {
                return "FHJB";
            }

            if (panel.Equals("HOST PANEL"))
            {
                return "HP";
            }

            if (panel.Equals("VAC PANEL"))
            {
                return "VAC";
            }

            if (panel.Equals("VDC PANEL"))
            {
                return "VDC";
            }

            if (panel.Equals("ELECTRIC BOILER PANEL"))
            {
                return "EB";
            }

            throw new Exception("Invalid panel name.");
        }
    }
}