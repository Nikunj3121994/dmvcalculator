using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.domain.data.Entities
{
    /// <summary>
    /// MostPopularCarBrandStatistics
    /// </summary>
    public class CarManufacturerNumberStatistics
    {
        /// <summary>
        /// Gets or sets the car manufactured number.
        /// </summary>
        /// <value>
        /// The car manufactured number.
        /// </value>
        public Dictionary<string, int> CarManufacturerNumber { set; get; }
    }
}
