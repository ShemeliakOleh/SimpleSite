using SimpleSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SimpleSite.Entities.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        void Delete(Guid Id);
    }
}