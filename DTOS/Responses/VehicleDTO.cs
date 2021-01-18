using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Responses
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string FrameNumber { get; set; }
        public string Color { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Brand { get; set; }
        public int VehicleTypeId { get; set; }
        public bool IsActive { get; set; } = false;
        public string NumberPlate { get; set; }
        public string Note { get; set; }
        public string Capacity { get; set; }
        public string EngineIDNo { get; set; }

    }
}
