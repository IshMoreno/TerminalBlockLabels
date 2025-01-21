namespace CleaverBrooks.TerminalStripUtility.Library.Exceptions
{
    /// <summary>
    /// Exception that gets thrown if a CSV file is missing an expecting header.
    /// </summary>
    public class MissingHeaderException : Exception
    {
        private readonly string missingHeaderName;

        /// <summary>
        /// Constructor for the <see cref="MissingHeaderException"/> class.
        /// </summary>
        /// <param name="missingHeaderName">The name of the header that is missing.</param>
        public MissingHeaderException(string missingHeaderName)
        {
            this.missingHeaderName = missingHeaderName;
        }

        /// <summary>
        /// The name of the header that is missing.
        /// </summary>
        public string MissingHeaderName
        {
            get { return missingHeaderName; }
        }
    }
}