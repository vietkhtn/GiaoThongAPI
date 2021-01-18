using System.Collections.Generic;
using System.Threading.Tasks;
using HumanResource.ApplicationCore.Entities;

namespace IThong.Interfaces
{
    public interface ILawService
    {
        Task<IEnumerable<Law>> GetAllAsync(int pageNumber, int pageSize);
        
        Task<Law> GetOneAsync(int id);

        Task<IEnumerable<Law>> FindLaw(string noiDungDieuLuat, string diem);
    }
}