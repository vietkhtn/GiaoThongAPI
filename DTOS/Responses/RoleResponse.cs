using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Responses
{
    public class RoleResponse
    {
        public int Id { get; set; }
        public string RoleName { set; get; }
        public bool IsActive { set; get; }
    }
}
