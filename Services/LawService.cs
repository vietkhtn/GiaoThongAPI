using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using HumanResource.ApplicationCore.Entities;
using HumanResource.ApplicationCore.Interfaces;
using HumanResource.ApplicationCore.Specifications;
using HumanResource.Infrastructure.Data;
using IThong.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IThong.Services
{
    public class LawService : ILawService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LawService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Law>> GetAllAsync(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            
            BaseSpecification<Law> spec = new BaseSpecification<Law>();
            
            spec.ApplyPaging((pageNumber - 1) * pageSize, pageSize);

            return await _unitOfWork.Repository<Law>().ListAsync(spec);
        }

        public async Task<IEnumerable<Law>> FindLaw(string noiDungDieuLuat, string diem)
        {
            try
            {
                var context = _unitOfWork.GetDbSet<Law>();
                var query = "Call findLaw('" + diem + "', '" + noiDungDieuLuat + "')";
                Console.WriteLine(query);
                var results = await context.FromSqlRaw(query).ToListAsync();
                return results;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Law> GetOneAsync(int id)
        {
            return await _unitOfWork.Repository<Law>().GetByIdAsync(id);
        }
    }
}