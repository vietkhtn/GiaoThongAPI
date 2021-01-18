using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanResource.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HumanResource.ApplicationCore.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<T> Repository<T>();
        Task<int> Complete();

        DbSet<T> GetDbSet<T>() where T : class;
    }
}
