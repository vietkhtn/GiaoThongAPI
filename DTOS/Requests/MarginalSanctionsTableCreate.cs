using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Requests
{
    public class MarginalSanctionsTableCreate
    {
        public DateTime TimeViolation { get; set; }
        public string Location { get; set; }
        public float VAT { get; set; }
        public int TotalMoney { get; set; }
        public int VehicleId { get; set; }
        public string Note { get; set; }
        public int CitizenShipProfileId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }
       
    }
}
