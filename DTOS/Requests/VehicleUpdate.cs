using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Requests
{
    public class VehicleUpdate
    {
        public bool? IsActive { get; set; }
        public string NumberPlate { get; set; }
    }
}
