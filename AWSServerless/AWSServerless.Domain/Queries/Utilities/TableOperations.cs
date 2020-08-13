using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AWSServerless.Domain.Queries.Utilities
{
    public static class TableOperations
    {
        #region Public Methods

        /// <summary>
        /// Setup for table.
        /// </summary>
        /// <returns>The for table.</returns>
        /// <param name="queryable">Queryable.</param>
        /// <param name="skip">Skip.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="sortProp">Sort property.</param>
        /// <param name="sortDir">Sort dir.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static IQueryable<T> SetupForTable<T>(
            IQueryable<T> queryable,
            int skip,
            int limit,
            string sortProp,
            string sortDir
        )
        {
            if (
                !string.IsNullOrWhiteSpace(sortProp) &&
                !string.IsNullOrWhiteSpace(sortDir) &&
                sortProp != "-" &&
                sortDir != "-"
            )
            {
                sortProp = $"{char.ToUpper(sortProp[0])}{sortProp.Substring(1)}";

                PropertyInfo prop = typeof(T).GetProperty(sortProp);
                if (sortDir.ToLower() == "asc")
                {
                    queryable = queryable.OrderBy(x => prop.GetValue(x, null));
                }
                else
                {
                    queryable = queryable.OrderByDescending(x => prop.GetValue(x, null));
                }
            }

            if (skip > 0)
            {
                queryable = queryable.Skip(skip);
            }

            if (limit > 0)
            {
                queryable = queryable.Take(limit);
            }

            return queryable;
        }

        #endregion Public Methods
    }

}
