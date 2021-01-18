using HumanResource.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll(); 
    }
}
