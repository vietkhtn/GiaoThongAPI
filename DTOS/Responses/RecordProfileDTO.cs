using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IThong.DTOS.Responses
{
    public class RecordProfileDTO
    {
        public int Id { get; set; }
        public string NumberPlate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Brand { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Addresses { get; set; }
        public string IDNo { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime ProductionDate { get; set; }
        public string FrameNumber { get; set; }
        public string Color { get; set; }


    }
}
