namespace CleaverBrooks.TerminalStripUtility.Library.Models
{
    /// <summary>
    /// A class representing a wire.
    /// </summary>
    public class Wire : IEquatable<Wire?>
    {
        private readonly string firstLocation;
        private readonly string secondLocation;
        private readonly string number;
        private string layerName;

        /// <summary>
        /// Constructor for the <see cref="Wire"/> class.
        /// </summary>
        /// <param name="firstLocation">The first location of the wire.</param>
        /// <param name="secondLocation">The second location of the wire.</param>
        /// <param name="number">The wire number.</param>
        /// <param name="layerName">The AutoCAD layer name that contains the wire color, gauge, and special wire properties.</param>
        public Wire(string firstLocation, string secondLocation, string number, string layerName)
        {
            this.firstLocation = firstLocation;
            this.secondLocation = secondLocation;
            this.number = number;
            this.layerName = layerName;
        }

        /// <summary>
        /// The first location of the wire.
        /// </summary>
        public string FirstLocation
        {
            get { return firstLocation; }
        }

        /// <summary>
        /// The second location of the wire.
        /// </summary>
        public string SecondLocation
        {
            get { return secondLocation; }
        }

        /// <summary>
        /// The wire number.
        /// </summary>
        public string Number
        {
            get { return number; }
        }

        /// <summary>
        /// The AutoCAD layer name that contains the wire color, gauge, and special wire properties.
        /// </summary>
        public string LayerName
        {
            get { return layerName; }
            set { layerName = value; }
        }

        /// <summary>
        /// Property indicating if the wire is an ethernet cable.
        /// </summary>
        public bool IsEthernetCable
        {
            get
            {
                string[] splitLayerName = layerName.Split("_");
                return splitLayerName[0].Equals("ETHERNET");
            }
        }

        /// <summary>
        /// Property indicating if the wire is a Wago jumper rather than an actual wire.
        /// </summary>
        public bool IsWagoJumper
        {
            get
            {
                return
                    (firstLocation.Equals("CONTROL PANEL") && secondLocation.Equals("CONTROL PANEL")) ||
                    (firstLocation.Equals("ENTRANCE PANEL") && secondLocation.Equals("ENTRANCE PANEL")) ||
                    (firstLocation.Equals("FHJB") && secondLocation.Equals("FHJB")) ||
                    (firstLocation.Equals("HOST PANEL") && secondLocation.Equals("HOST PANEL")) ||
                    (firstLocation.Equals("VAC PANEL") && secondLocation.Equals("VAC PANEL")) ||
                    (firstLocation.Equals("VDC PANEL") && secondLocation.Equals("VDC PANEL"));
            }
        }

        /// <summary>
        /// Property to see if the wire is wired by the customer.
        /// </summary>
        public bool IsFieldWire
        {
            get
            {
                string[] splitLayerName = layerName.Split("_");
                return splitLayerName[0].Equals("FIELD");
            }
        }

        /// <summary>
        /// Property indicating if wire should only be counted once.
        /// </summary>
        public bool OnlyCountsOnce
        {
            get
            {
                return
                    (firstLocation.Equals("CONTROL PANEL") && secondLocation.Equals("ENTRANCE PANEL")) ||
                    (firstLocation.Equals("ENTRANCE PANEL") && secondLocation.Equals("CONTROL PANEL")) ||

                    (firstLocation.Equals("CONTROL PANEL") && secondLocation.Equals("FHJB")) ||
                    (firstLocation.Equals("FHJB") && secondLocation.Equals("CONTROL PANEL")) ||

                    (firstLocation.Equals("VAC PANEL") && secondLocation.Equals("CONTROL PANEL")) ||
                    (firstLocation.Equals("CONTROL PANEL") && secondLocation.Equals("VAC PANEL")) ||

                    (firstLocation.Equals("VDC PANEL") && secondLocation.Equals("CONTROL PANEL")) ||
                    (firstLocation.Equals("CONTROL PANEL") && secondLocation.Equals("VDC PANEL")) ||

                    (firstLocation.Equals("VAC PANEL") && secondLocation.Equals("ENTRANCE PANEL")) ||
                    (firstLocation.Equals("ENTRANCE PANEL") && secondLocation.Equals("VAC PANEL")) ||

                    (firstLocation.Equals("VDC PANEL") && secondLocation.Equals("ENTRANCE PANEL")) ||
                    (firstLocation.Equals("ENTRANCE PANEL") && secondLocation.Equals("VDC PANEL")) ||

                    (firstLocation.Equals("VAC PANEL") && secondLocation.Equals("FHJB")) ||
                    (firstLocation.Equals("FHJB") && secondLocation.Equals("VAC PANEL")) ||

                    (firstLocation.Equals("VDC PANEL") && secondLocation.Equals("FHJB")) ||
                    (firstLocation.Equals("FHJB") && secondLocation.Equals("VDC PANEL"));
            }
        }

        /// <summary>
        /// Property indicating if wire cable is shielded.
        /// </summary>
        public bool IsShieldedCable
        {
            get
            {
                string[] splitLayerName = layerName.Split("_");
                return splitLayerName[0].Equals("SHIELDED");
            }
        }

        /// <summary>
        /// Property indicating if wire is neutral.
        /// </summary>
        public bool IsNeutral
        {
            get
            {
                string[] splitLayerName = layerName.Split("_");
                bool whiteWire = splitLayerName[0].Equals("WHT") && splitLayerName.Length.Equals(2);
                bool whiteOrangeWire = splitLayerName[0].Equals("WHT") && splitLayerName.Length.Equals(3) && splitLayerName[1].Equals("ORG");
                return whiteWire || whiteOrangeWire;
            }
        }

        /// <summary>
        /// Property indicating if wire is for igniting fuel.
        /// </summary>
        public bool IsCriticalFuelWire
        {
            get
            {
                string[] splitLayerName = layerName.Split("_");
                bool violetWire = splitLayerName[0].Equals("VT") && splitLayerName.Length.Equals(2);
                return violetWire;
            }
        }

        /// <summary>
        /// Property indicating if wire carries alternating current.
        /// </summary>
        public bool CarriesAlternatingCurrent
        {
            get
            {
                string[] splitLayerName = layerName.Split("_");
                bool redWire = splitLayerName[0].Equals("RED") && splitLayerName.Length.Equals(2);
                bool violetWire = splitLayerName[0].Equals("VT") && splitLayerName.Length.Equals(2);
                bool orangeWire = splitLayerName[0].Equals("ORG") && splitLayerName.Length.Equals(2);
                return redWire || IsNeutral || violetWire || orangeWire;
            }
        }

        /// <summary>
        /// The color(s) of the wire.
        /// Returns NA if the wire is an Ethernet cable, a Shielded cable or a Field wire.
        /// If the wire is a solid color wire, then the solid color is returned.
        /// If a wire is a striped wire, then a solid color and striped color are return separated by a slash.
        /// </summary>
        public string Color
        {
            get
            {
                if (IsEthernetCable || IsShieldedCable || IsFieldWire)
                {
                    return "NA";
                }
                string[] splitLayerName = layerName.Split("_");
                if (splitLayerName.Length.Equals(2))
                {
                    return splitLayerName[0];
                }
                return splitLayerName[0] + "/" + splitLayerName[1];
            }
        }

        /// <summary>
        /// Method that determines if the wire terminates at the specified location.
        /// </summary>
        /// <param name="location">The location being asked about.</param>
        /// <returns>It returns true if either of the wire's location match the specified location. It returns false otherwise.</returns>
        public bool TerminatesAt(string location)
        {
            return firstLocation.Equals(location) || secondLocation.Equals(location);
        }

        /// <summary>
        /// Method that determines if the wire going from one location to the next is the same wire vise-versa.
        /// </summary>
        /// <param name="obj">This paramameter allows us to compare the wire object with another one for equality.</param>
        /// <returns>It returns false if wire objects are not equal to each other.</returns>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Wire);
        }

        /// <summary>
        /// Method that checks to see if the current <see cref="Wire"/> object is equal to another <see cref="Wire"/> object.
        /// </summary>
        /// <param name="other">The other <see cref="Wire"/> object that the current <see cref="Wire"/> object is being compared to.</param>
        /// <returns>
        /// Returns <see cref="true"/> if the two wires are equal.
        /// Returns <see cref="false"/> if the two wires are unequal.
        /// Note that the two locations do not need to be listed in the same order for the wires to be considered equal (as long as the pair of locations is the same).
        /// </returns>
        public bool Equals(Wire? other)
        {
            return other is not null &&
                   (
                        (FirstLocation.Equals(other.FirstLocation) && SecondLocation.Equals(other.SecondLocation))
                        ||
                        (FirstLocation.Equals(other.SecondLocation) && SecondLocation.Equals(other.FirstLocation))
                   ) &&
                   Number == other.Number && layerName == other.layerName;
        }

        /// <summary>
        /// This method generates a hash code for the wire object and is used for efficient storage based on the wire properties.
        /// </summary>
        /// <returns>It returns the combined hash code of the wire object.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstLocation, SecondLocation, Number, LayerName);
        }
    }
}