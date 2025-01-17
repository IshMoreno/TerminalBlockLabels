using CleaverBrooks.TerminalStripUtility.Library.Models;

namespace CleaverBrooks.TerminalStripUtility.Library.Creators
{
    /// <summary>
    /// Class for creating <see cref="TerminalBlock"/> objects from a collection of <see cref="Wire"/> objects.
    /// </summary>
    public class TerminalBlockCreator
    {
        private readonly IEnumerable<Wire> wires;

        /// <summary>
        /// Constructor for the <see cref="TerminalBlockCreator"/> class.
        /// </summary>
        /// <param name="wires">The wires that the terminal blocks are being created from.</param>
        public TerminalBlockCreator(IEnumerable<Wire> wires)
        {
            this.wires = wires;
        }

        /// <summary>
        /// The wires that the terminal blocks are being created from.
        /// </summary>
        public IEnumerable<Wire> Wires
        {
            get { return wires; }
        }

        /// <summary>
        /// Helper method that gets the terminal block color for a specific wire.
        /// </summary>
        /// <param name="wire">The wire being evaluated.</param>
        /// <returns>
        /// It returns the terminal block color. The return value will be all caps and it will not be abbreviated.
        /// </returns>
        /// <exception cref="Exception">Thrown if the terminal block color could not be determined for the specified wire.</exception>
        public string GetTerminalBlockColor(Wire wire)
        {
            if (wire.IsFieldWire && wire.CarriesAlternatingCurrent)
            {
                if (wires.Any(wireFromList => wireFromList.Number.Equals(wire.Number)))
                {
                    Wire firstMatchingWire = wires.Where(wireFromList => wireFromList.Number.Equals(wire.Number)).FirstOrDefault()!;

                    if (firstMatchingWire.IsShieldedCable || (firstMatchingWire.IsFieldWire && !firstMatchingWire.CarriesAlternatingCurrent))
                    {
                        return "BLUE";
                    }

                    return GetTerminalBlockColor(wire.Color);
                }

                return "RED";
            }

            if (wire.IsShieldedCable || (wire.IsFieldWire && !wire.CarriesAlternatingCurrent))
            {
                return "BLUE";
            }

            return GetTerminalBlockColor(wire.Color);
        }

        /// <summary>
        /// Helper method that gets the terminal block color based on a wire color.
        /// </summary>
        /// <param name="wireColor">The color of the wire.</param>
        /// <returns>The terminal block color.</returns>
        /// <exception cref="Exception">Thrown if the specified wire color is not supported.</exception>
        private static string GetTerminalBlockColor(string wireColor)
        {
            if (wireColor.Equals("RED") || wireColor.Equals("ORG"))
            {
                return "RED";
            }

            if (wireColor.Equals("WHT") || wireColor.Equals("WHT/ORG"))
            {
                return "GRAY";
            }

            if (wireColor.Equals("VT"))
            {
                return "ORANGE";
            }

            if (wireColor.Equals("BLU") || wireColor.Equals("WHT/BLU"))
            {
                return "BLUE";
            }

            throw new Exception("A terminal block color could not be determined for this wire.");
        }

        /// <summary>
        /// Method for creating terminal blocks for a specific panel.
        /// </summary>
        /// <param name="panel">The panel that the terminal blocks are being created for.</param>
        /// <returns>
        /// A collection of terminal blocks for the specific panel.
        /// </returns>
        private IEnumerable<TerminalBlock> CreateTerminalBlocksFor(string panel)
        {
            List<Wire> wiresForPanel = wires.Where(wire => wire.TerminatesAt(panel)).ToList();

            wiresForPanel.RemoveAll(wire => wire.IsWagoJumper);
            wiresForPanel.RemoveAll(wire => wire.Color.Equals("BLK"));
            wiresForPanel.RemoveAll(wire => wire.IsEthernetCable);

            IEnumerable<Wire> distinctWiresThatOnlyCountOnce = wiresForPanel.Where(wire => wire.OnlyCountsOnce).Distinct().ToList();
            foreach (Wire currentWire in distinctWiresThatOnlyCountOnce)
            {
                while (wiresForPanel.Count(wire => wire.Equals(currentWire)) > 1)
                {
                    wiresForPanel.Remove(currentWire);
                }
            }

            List<Wire> wiresForPanelWithoutFieldWires = new();
            IEnumerable<Wire> wiresForPanelIncludingFieldWires = wiresForPanel.Distinct();
            HashSet<string> wireNumbersHashSet = new();
            foreach (Wire currentWire in wiresForPanelIncludingFieldWires)
            {
                if (currentWire.IsFieldWire)
                {
                    Wire matchingWire = wiresForPanelIncludingFieldWires.FirstOrDefault(wire => wire.Number == currentWire.Number && wire.LayerName != currentWire.LayerName)!;

                    if (matchingWire != null)
                    {
                        currentWire.LayerName = matchingWire.LayerName;
                    }
                    else if (currentWire.LayerName.Equals("FIELD_AC"))
                    {
                        currentWire.LayerName = "RED_16AWG";
                    }
                    else if (currentWire.LayerName.Equals("FIELD_DC"))
                    {
                        currentWire.LayerName = "BLU_16AWG";
                    }
                }
                if (!wireNumbersHashSet.Contains(currentWire.Number))
                {
                    wireNumbersHashSet.Add(currentWire.Number);
                    wiresForPanelWithoutFieldWires.Add(currentWire);
                }
            }

            List<TerminalBlock> terminalBlocksForPanel = new();
            IEnumerable<Wire> distinctWiresForPanel = wiresForPanelWithoutFieldWires.Distinct();
            foreach (Wire currentWire in distinctWiresForPanel)
            {
                int numberOfMatchingWires = wiresForPanel.Count(wire => wire.Number.Equals(currentWire.Number));

                int numberOfTerminals = (int)Math.Ceiling(numberOfMatchingWires / 2.0);

                for (int terminalNumber = 1; terminalNumber <= numberOfTerminals; terminalNumber++)
                {
                    string number = currentWire.Number;
                    string color = GetTerminalBlockColor(currentWire);
                    bool isForShieldedCable = currentWire.IsShieldedCable;
                    TerminalBlock terminalBlock = new(number, color, panel, isForShieldedCable);
                    terminalBlocksForPanel.Add(terminalBlock);
                }
            }

            return terminalBlocksForPanel;
        }

        /// <summary>
        /// Method that returns a collection of <see cref="TerminalBlock"/> objects based on the collection of wires.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="TerminalBlock"/> objects based on the collection of wires.
        /// </returns>
        public IEnumerable<TerminalBlock> CreateTerminalBlocks()
        {
            List<TerminalBlock> terminalBlocks = new();

            IEnumerable<TerminalBlock> terminalBlocksForControlPanel = CreateTerminalBlocksFor("CONTROL PANEL");
            terminalBlocks.AddRange(terminalBlocksForControlPanel);

            IEnumerable<TerminalBlock> terminalBlocksForEntrancePanel = CreateTerminalBlocksFor("ENTRANCE PANEL");
            terminalBlocks.AddRange(terminalBlocksForEntrancePanel);

            IEnumerable<TerminalBlock> terminalBlocksForFHJBPanel = CreateTerminalBlocksFor("FHJB");
            terminalBlocks.AddRange(terminalBlocksForFHJBPanel);

            IEnumerable<TerminalBlock> terminalBlocksForHostPanel = CreateTerminalBlocksFor("HOST PANEL");
            terminalBlocks.AddRange(terminalBlocksForHostPanel);

            IEnumerable<TerminalBlock> terminalBlocksForVACPanel = CreateTerminalBlocksFor("VAC PANEL");
            terminalBlocks.AddRange(terminalBlocksForVACPanel);

            IEnumerable<TerminalBlock> terminalBlocksForVDCPanel = CreateTerminalBlocksFor("VDC PANEL");
            terminalBlocks.AddRange(terminalBlocksForVDCPanel);

            IEnumerable<TerminalBlock> terminalBlocksForElectricBoilerPanel = CreateTerminalBlocksFor("ELECTRIC BOILER PANEL");
            terminalBlocks.AddRange(terminalBlocksForElectricBoilerPanel);

            terminalBlocks.Sort();

            return terminalBlocks;
        }
    }
}