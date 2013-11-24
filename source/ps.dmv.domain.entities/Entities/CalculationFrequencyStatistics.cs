using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.domain.data.Entities
{
    /// <summary>
    /// CalculationFrequencyStatistics
    /// </summary>
    public class CalculationFrequencyStatistics
    {
        /// <summary>
        /// Gets or sets the calculation frequency data.
        /// </summary>
        /// <value>
        /// The calculation frequency data.
        /// </value>
        public Dictionary<DateTime?, int> CalculationFrequencyData { get; set; }
    }
}
