using System.Collections.Generic;

namespace AWSServerless.Domain.BTOs
{
    public class TableResult<T> where T : class
    {
        #region Public Properties

        /// <summary>
        /// The Count of elements in the Table Result.
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// The Values of elements in the Table Result.
        /// </summary>
        public IList<T> Values { get; set; } = new List<T>();

        #endregion Public Properties
    }
}