using FinancialHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialHub.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Base Repository with basic CRUD methods
    /// </summary>
    /// <typepaam name="T">Any Entity that inherits <see cref="BaseEntity"/> </typepaam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Adds an entity to the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T obj);

        /// <summary>
        /// Updates a created entity on the database
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<T> UpdateAsync(T obj);
        
        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(Guid id);
        
        /// <summary>
        /// Get All entities from the database 
        /// </summary>
        Task<ICollection<T>> GetAllAsync();
        
        /// <summary>
        /// Get All entities from the database based on a filter
        /// </summary>
        Task<ICollection<T>> GetAsync(Func<T, bool> predicate);
        
        /// <summary>
        /// Gets an entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);
    }
}
