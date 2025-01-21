using CleaverBrooks.Orders;
using CleaverBrooks.TerminalStripUtility.Library.Exceptions;
using CleaverBrooks.TerminalStripUtility.Library.Models;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace CleaverBrooks.TerminalStripUtility.Library.FileReaders
{
    /// <summary>
    /// Class that can be used to get a list of <see cref="Wire"/> objects from an autocad csv file.
    /// </summary>
    public class AutoCadFileReader
    {
        private readonly string filepath;

        /// <summary>
        /// One argument constructor for the <see cref="AutoCadFileReader"/> class.
        /// </summary>
        /// <param name="filepath">Path to the file being read.</param>
        public AutoCadFileReader(string filepath)
        {
            this.filepath = filepath;
        }

        /// <summary>
        /// Two argument constructor for the <see cref="AutoCadFileReader"/> class.
        /// </summary>
        /// <param name="serialNumber">The serial number for the unit being read.</param>
        /// <param name="isHostPanel">Value indicating if the csv file is for a host panel.</param>
        public AutoCadFileReader(ISerialNumber serialNumber, bool isHostPanel)
        {
            if (isHostPanel)
            {
                filepath = @$"\\aqcorp.com\thv\CAD\Submit\Wire Marker Files\{serialNumber.ConcatentatedSerialNumber}HP.csv";
            }
            else
            {
                filepath = @$"\\aqcorp.com\thv\CAD\Submit\Wire Marker Files\{serialNumber.ConcatentatedSerialNumber}.csv";
            }
        }

        /// <summary>
        /// Path to the file being read.
        /// </summary>
        public string Filepath
        {
            get { return filepath; }
        }

        /// <summary>
        /// Method that gets a list of <see cref="Wire"/> objects from an autoCad CSV file.
        /// </summary>
        /// <returns>
        /// A list of <see cref="Wire"/> objects from an autoCad CSV file.
        /// </returns>
        /// <exception cref="MissingHeaderException">Thrown if the CSV file is missing a required header.</exception>
        /// <exception cref="FileLoadException">Thrown if the file could not be read.</exception>
        /// <exception cref="MissingWireNumberException">Thrown if the CSV file is missing a wire number.</exception>
        public async Task<IEnumerable<Wire>> ReadFileAsync()
        {
            IEnumerable<Wire> wires = await Task.Run(() => ReadFile());
            return wires;
        }

        /// <summary>
        /// Method that gets a list of <see cref="Wire"/> objects from an autoCad CSV file.
        /// </summary>
        /// <returns>
        /// A list of <see cref="Wire"/> objects from an autoCad CSV file.
        /// </returns>
        /// <exception cref="MissingHeaderException">Thrown if the CSV file is missing a required header.</exception>
        /// <exception cref="FileLoadException">Thrown if the file could not be read.</exception>
        /// <exception cref="MissingWireNumberException">Thrown if the CSV file is missing a wire number.</exception>
        private IEnumerable<Wire> ReadFile()
        {
            List<Wire> wires = new();

            using TextFieldParser textFieldParser = new(filepath);
            textFieldParser.TextFieldType = FieldType.Delimited;
            textFieldParser.SetDelimiters(",");

            string[] headers = textFieldParser.ReadFields()!;
            int loc1Index = Array.IndexOf(headers, "LOC1");
            int loc2Index = Array.IndexOf(headers, "LOC2");
            int wireNoIndex = Array.IndexOf(headers, "WIRENO");
            int wlay1Index = Array.IndexOf(headers, "WLAY1");

            if (loc1Index < 0)
            {
                throw new MissingHeaderException("LOC1");
            }
            if (loc2Index < 0)
            {
                throw new MissingHeaderException("LOC2");
            }
            if (wireNoIndex < 0)
            {
                throw new MissingHeaderException("WIRENO");
            }
            if (wlay1Index < 0)
            {
                throw new MissingHeaderException("WLAY1");
            }

            if (textFieldParser.EndOfData)
            {
                throw new FileLoadException();
            }

            while (!textFieldParser.EndOfData)
            {
                string[] currentLine = textFieldParser.ReadFields()!;

                if (currentLine[wireNoIndex] == "")
                {
                    throw new MissingWireNumberException();
                }

                string loc1 = currentLine[loc1Index];
                string loc2 = currentLine[loc2Index];
                string wireNo = currentLine[wireNoIndex];
                string wlay1 = currentLine[wlay1Index];

                Wire wire = new(loc1, loc2, wireNo, wlay1);
                wires.Add(wire);
            }
            return wires;
        }
    }
}