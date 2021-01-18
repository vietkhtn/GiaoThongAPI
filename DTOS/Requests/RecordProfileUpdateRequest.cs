using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Requests
{
    public class RecordProfileUpdateRequest
    {
        public int? VehicleId { get; set; }
        public int? VehicleOwnerId { get; set; }
        public string Note { get; set; }
        public bool? IsActive { get; set; }
      
    }
}
