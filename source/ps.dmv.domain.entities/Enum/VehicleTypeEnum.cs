using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.domain.data.Enum
{
    /// <summary>
    /// VehicleTypeEnum
    /// </summary>
    public enum VehicleTypeEnum
    {
        [Description("Avto")]//TODO: Commonize
        [Display(Name = "Avto")]
        Car = 1,

        [Description("Avtodom")]
        [Display(Name = "Avtodom")]
        LivingVan,

        [Description("Kolo z motorjem")]
        [Display(Name = "Kolo z motorjem")]
        BikeWithEngine,

        [Description("Motorno kolo")]
        [Display(Name = "Motorno kolo")]
        Motorbike
    }
}
