using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Managers
{
    /// <summary>
    /// IStatisticsManager
    /// </summary>
    public interface IStatisticsManager
    {
        /// <summary>
        /// Gets the most popular car brand statistics.
        /// </summary>
        /// <returns></returns>
        CarManufacturerNumberStatistics GetMostPopularCarBrandStatistics();

        /// <summary>
        /// Gets the calculation frequency statistics.
        /// </summary>
        /// <returns></returns>
        CalculationFrequencyStatistics GetCalculationFrequencyStatistics();
    }
}
