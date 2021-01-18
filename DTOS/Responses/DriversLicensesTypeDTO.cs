using IThong.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Responses
{
    public class DriversLicensesTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public IEnumerable<dynamic> ListVehicleType { get; set; }
    }
}
