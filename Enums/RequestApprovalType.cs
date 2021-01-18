using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HumanResource.ApplicationCore.Enums
{
    public enum RequestApprovalType
    {
        [Description("Nghỉ phép")]
        NP = 1,
        [Description("Nghỉ không lương")]
        NPKL = 2,
        [Description("Đi trễ")]
        DT = 3,
        [Description("Về sớm")]
        VS = 4,
        [Description("Công Tác")]
        CT = 5,
        [Description("Thai Sản")]
        TS = 6,
        [Description("Nghỉ Bệnh")]
        NB = 1,
        [Description("Nghỉ Kết Hôn")]
        NKH = 1
    }
}
