namespace CleaverBrooks.TerminalStripUtility.Library.Models
{
    /// <summary>
    /// Class representing a terminal block.
    /// </summary>
    public class TerminalBlock : IComparable<TerminalBlock>, IEquatable<TerminalBlock?>
    {
        private readonly string number;
        private readonly string color;
        private readonly string panel;
        private readonly bool isForShieldedCable;

        /// <summary>
        /// Constructor for the <see cref="TerminalBlock"/> class.
        /// </summary>
        /// <param name="number">Terminal block number.</param>
        /// <param name="color">Terminal block color.</param>
        /// <param name="panel">Location of the terminal block.</param>
        /// <param name="isForShieldedCable">Value indicating if the terminal block is for a shielded cable.</param>
        public TerminalBlock(string number, string color, string panel, bool isForShieldedCable)
        {
            this.number = number;
            this.color = color;
            this.panel = panel;
            this.isForShieldedCable = isForShieldedCable;
        }

        /// <summary>
        /// Terminal block number.
        /// </summary>
        public string Number { get { return number; } }

        /// <summary>
        /// Terminal block color.
        /// </summary>
        public string Color { get { return color; } }

        /// <summary>
        /// Location of the terminal block.
        /// </summary>
        public string Panel { get { return panel; } }

        /// <summary>
        /// Value indicating if the terminal block is for a shielded cable.
        /// </summary>
        public bool IsForShieldedCable { get { return isForShieldedCable; } }

        /// <summary>
        /// The rung number for the terminal block.
        /// </summary>
        public int Rung
        {
            get
            {
                string rungAsString = number[..^1];
                return int.Parse(rungAsString);
            }
        }

        /// <summary>
        /// This property returns an integer value. If the last character is numeric, it returns the parsed integer. If the last character is a letter, 
        /// then a number is provided. EX: "8057", the last charcter "7" would be extracted and returned as '7'. If the number is "805A", then a number
        /// is provided, and returned as '10', (65-55). "805B" would return '11' (66-55).
        /// </summary>
        public int TerminalIdentifier
        {
            get
            {
                string terminalIdentifierAsString = number.Substring(number.Length - 1, 1);
                bool lastCharacterIsNumeric = int.TryParse(terminalIdentifierAsString, out int terminalIdentifier);
                if (lastCharacterIsNumeric)
                {
                    return terminalIdentifier;
                }
                terminalIdentifier = terminalIdentifierAsString.ToCharArray()[0] - 55;
                return terminalIdentifier;
            }
        }

        /// <summary>
        /// This method compares the current <see cref="TerminalBlock"/> object to another <see cref="TerminalBlock"/> object.
        /// </summary>
        /// <param name="other">The other <see cref="TerminalBlock"> object that the current <see cref="TerminalBlock"/> object is being compared to.</param>
        /// <returns>
        /// This method returns a negative integer if the current instance precedes the object specified as an argument.
        /// It returns zero if the current instance is in the same position as the object specified as an argument.
        /// It returns a positive integer if the current instance follows the object specified as an argument.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if the specified <see cref="TerminalBlock"/> object is <see cref="null"/>.</exception>
        /// <exception cref="Exception">Thrown if one or more of the <see cref="TerminalBlock"/> objects have invalid panels or colors.</exception>
        public int CompareTo(TerminalBlock? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            int panelComparisonInt = GetPanelComparisonInt(other);
            if (panelComparisonInt != 0)
            {
                return panelComparisonInt;
            }

            int colorComparisonInt = GetColorComparisonInt(other);
            if (colorComparisonInt != 0)
            {
                return colorComparisonInt;
            }

            return GetNumberComparisonInt(other);
        }

        /// <summary>
        /// Helper method that gets a panel comparison integer based on the panel.
        /// </summary>
        /// <param name="other">The other <see cref="TerminalBlock"/> object being compared.</param>
        /// <returns>
        /// This method returns a negative integer if the current instance precedes the object specified as an argument.
        /// It returns zero if the current instance is in the same position as the object specified as an argument.
        /// It returns a positive integer if the current instance follows the object specified as an argument.
        /// </returns>
        /// <exception cref="Exception">Thrown if one or more of the terminal blocks have invalid panels.</exception>
        private int GetPanelComparisonInt(TerminalBlock other)
        {
            if (panel.Equals(other.Panel))
            {
                return 0;
            }
            else if (panel.Equals("CONTROL PANEL") && other.Panel.Equals("ENTRANCE PANEL"))
            {
                return -1;
            }
            else if (panel.Equals("CONTROL PANEL") && other.Panel.Equals("FHJB"))
            {
                return -1;
            }
            else if (panel.Equals("ENTRANCE PANEL") && other.Panel.Equals("CONTROL PANEL"))
            {
                return 1;
            }
            else if (panel.Equals("ENTRANCE PANEL") && other.Panel.Equals("FHJB"))
            {
                return -1;
            }
            else if (panel.Equals("FHJB") && other.Panel.Equals("CONTROL PANEL"))
            {
                return 1;
            }
            else if (panel.Equals("FHJB") && other.Panel.Equals("ENTRANCE PANEL"))
            {
                return 1;
            }

            throw new Exception("Invalid Panel Name.");
        }

        /// <summary>
        /// Helper method that gets a panel comparison integer based on the terminal block color.
        /// </summary>
        /// <param name="other">The other <see cref="TerminalBlock"/> object being compared.</param>
        /// <returns>
        /// This method returns a negative integer if the current instance precedes the object specified as an argument.
        /// It returns zero if the current instance is in the same position as the object specified as an argument.
        /// It returns a positive integer if the current instance follows the object specified as an argument.
        /// </returns>
        /// <exception cref="Exception">Thrown if one or more of the terminal blocks have invalid colors.</exception>
        private int GetColorComparisonInt(TerminalBlock other)
        {
            if (color.Equals(other.Color))
            {
                return 0;
            }
            else if (color.Equals("RED") && other.Color.Equals("GRAY"))
            {
                return 0;
            }
            else if (color.Equals("RED") && other.Color.Equals("ORANGE"))
            {
                return -1;
            }
            else if (color.Equals("RED") && other.Color.Equals("BLUE"))
            {
                return -1;
            }
            else if (color.Equals("GRAY") && other.Color.Equals("RED"))
            {
                return 0;
            }
            else if (color.Equals("GRAY") && other.Color.Equals("ORANGE"))
            {
                return -1;
            }
            else if (color.Equals("GRAY") && other.Color.Equals("BLUE"))
            {
                return -1;
            }
            else if (color.Equals("ORANGE") && other.Color.Equals("RED"))
            {
                return 1;
            }
            else if (color.Equals("ORANGE") && other.Color.Equals("GRAY"))
            {
                return 1;
            }
            else if (color.Equals("ORANGE") && other.Color.Equals("BLUE"))
            {
                return -1;
            }
            else if (color.Equals("BLUE") && other.Color.Equals("RED"))
            {
                return 1;
            }
            else if (color.Equals("BLUE") && other.Color.Equals("ORANGE"))
            {
                return 1;
            }
            else if (color.Equals("BLUE") && other.Color.Equals("GRAY"))
            {
                return 1;
            }

            throw new Exception("Invalid Color.");
        }

        /// <summary>
        /// Helper method that gets a panel comparison integer based on the number.
        /// </summary>
        /// <param name="other">The other <see cref="TerminalBlock"/> object being compared.</param>
        /// <returns>
        /// This method returns a negative integer if the current instance precedes the object specified as an argument.
        /// It returns zero if the current instance is in the same position as the object specified as an argument.
        /// It returns a positive integer if the current instance follows the object specified as an argument.
        /// </returns>
        private int GetNumberComparisonInt(TerminalBlock other)
        {
            if (Rung < other.Rung)
            {
                return -1;
            }

            if (Rung > other.Rung)
            {
                return 1;
            }

            if (TerminalIdentifier < other.TerminalIdentifier)
            {
                return -1;
            }

            if (TerminalIdentifier > other.TerminalIdentifier)
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Method that checks to see if the current <see cref="TerminalBlock"/> object is equal to another <see cref="TerminalBlock"/> object.
        /// </summary>
        /// <param name="obj">The other <see cref="TerminalBlock"/> object that the current <see cref="TerminalBlock"/> object is being compared to.</param>
        /// <returns>
        /// Returns <see cref="true"/> if the two blocks are equal.
        /// Returns <see cref="false"/> if the two blocks are unequal.
        /// </returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as TerminalBlock);
        }

        /// <summary>
        /// Method that checks to see if the current <see cref="TerminalBlock"/> object is equal to another <see cref="TerminalBlock"/> object.
        /// </summary>
        /// <param name="other">The other <see cref="TerminalBlock"/> object.</param>
        /// <returns>
        /// Returns <see cref="true"/> if the two objects are equal.
        /// Returns <see cref="false"/> if the two objects are unequal.
        /// </returns>
        public bool Equals(TerminalBlock? other)
        {
            return other is not null &&
                Number == other.Number &&
                Color == other.Color &&
                Panel == other.Panel &&
                IsForShieldedCable == other.IsForShieldedCable;
        }

        /// <summary>
        /// This method generates a hash code for the terminal block object and is used for efficient storage based on terminal block properties.
        /// </summary>
        /// <returns>
        /// It returns the combined hash code of the wire object.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(Number, Color, Panel);
        }
    }
}