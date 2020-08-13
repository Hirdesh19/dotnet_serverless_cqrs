namespace AWSServerless.Domain.Helpers
{
    /// <summary>
    /// Contains paging query parameters
    /// </summary>
    public class TableQueryParams
    {
        #region Public Properties

        private string _filter = "";

        /// <summary>
        /// Filter on the data set. Such as a string to search.
        /// </summary>
        public string Filter
        {
            get
            {
                if (_filter == "-")
                {
                    return "";
                }
                return _filter;
            }
            set
            {
                _filter = value;
            }
        }

        /// <summary>
        /// The amount of data to retrieve.
        /// </summary>
        public int Limit { get; set; } = 1000;

        /// <summary>
        /// The amount of data to skip.
        /// </summary>
        public int Skip { get; set; } = 0;

        /// <summary>
        /// The Sort Direction given a sort Property.
        /// </summary>
        public string SortDir { get; set; } = "-";

        /// <summary>
        /// The Sort Property to sort against.
        /// </summary>
        public string SortProp { get; set; } = "-";

        #endregion Public Properties
    }
}