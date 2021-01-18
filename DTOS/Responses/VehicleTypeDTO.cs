using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Responses
{
    public class VehicleTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Fees { get; set; }
    }
}
