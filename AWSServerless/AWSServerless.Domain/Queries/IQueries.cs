using AWSServerless.Domain.BTOs;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AWSServerless.Domain.Queries
{
    public interface IQueries<D, T> where D : class where T : class
    {
        #region Public Methods

        /// <summary>
        /// Get the database object as a database transfer object given the id
        /// </summary>
        /// <param name="id">id of the entity</param>
        /// <returns>DTO of the entity</returns>
        Task<D> GetByIdAsync(int id);

        /// <summary>
        /// Get the database object as a database transfer object given the id
        /// </summary>
        /// <param name="id">id of the entity</param>
        /// <param name="includes">Any includes (only one level)</param>
        /// <returns>DTO of the entity</returns>
        Task<D> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get the database objects as database transfer objects given the where clause
        /// </summary>
        /// <param name="where">where clause to apply</param>
        /// <param name="skip">number of elements to skip (default 0)</param>
        /// <param name="limit">number of elements to take (default 1000)</param>
        /// <param name="propName">property to sort by (optional)</param>
        /// <param name="sortDir">the direction to sort (optional)</param>
        /// <param name="includes">Any includes (only one level)</param>
        /// <returns>DTOs of the entities</returns>
        Task<TableResult<D>> GetManyAsync(
            Expression<Func<T, bool>> where,
            int skip = 0,
            int limit = 1000,
            string propName = "-",
            string sortDir = "-",
            params Expression<Func<T, object>>[] includes
        );

        #endregion Public Methods
    }
}