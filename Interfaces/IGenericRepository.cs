using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace HumanResource.ApplicationCore.Interfaces
{
    public interface IGenericRepository<T> 
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task AddAsync(T entity);
        void Add(T entity);

        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> FirstAsync(ISpecification<T> spec);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec);
        Task<T> SingletAsync(ISpecification<T> spec);

        Task<T> SingleOrDefaultAsync(ISpecification<T> spec);
        
        T First(ISpecification<T> spec);
        T FirstOrDefault(ISpecification<T> spec);
        T Single(ISpecification<T> spec);

        T SingleOrDefault(ISpecification<T> spec);
    }
}
