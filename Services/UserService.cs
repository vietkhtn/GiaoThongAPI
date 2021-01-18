using HumanResource.ApplicationCore.Entities;
using HumanResource.ApplicationCore.Interfaces;
using IThong.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unit;
        public UserService(IUnitOfWork unit)
        {
            _unit = unit;

        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unit.Repository<User>().ListAllAsync();
            
        }
    }
}
