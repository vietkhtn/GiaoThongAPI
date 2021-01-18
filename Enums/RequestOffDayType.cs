using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HumanResource.ApplicationCore.Enums
{
    public enum RequestOffDayType
    {
        [Description("Nghỉ phép")]
        NP = 1,
        [Description("Nghỉ không lương")]
        NPKL = 2,
        [Description("Thai Sản")]
        TS = 6,
        [Description("Nghỉ Bệnh")]
        NB = 1,
        [Description("Nghỉ Kết Hôn")]
        NKH = 1
    }
}
