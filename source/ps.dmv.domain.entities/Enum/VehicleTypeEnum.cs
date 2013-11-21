using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.domain.data.Enum
{
    public enum VehicleTypeEnum
    {
        [Description("Avto")]
        Car = 1,

        [Description("Avtodom")]
        LivingVan,

        [Description("Kolo z motorjem")]
        BikeWithEngine,

        [Description("Motorno kolo")]
        Motorbike
    }
}
