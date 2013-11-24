using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Managers
{
    /// <summary>
    /// StatisticsManager
    /// </summary>
    public class StatisticsManager : IStatisticsManager
    {
        private IStatisticsRepository _statisticsRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsManager"/> class.
        /// </summary>
        public StatisticsManager()
        {
            _statisticsRepository = ServiceLocator.Instance.Resolve<IStatisticsRepository>();
        }

        /// <summary>
        /// Gets the most popular car brand statistics.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CarManufacturerNumberStatistics GetMostPopularCarBrandStatistics(/*int maxDifferentiation*/)
        {
            CarManufacturerNumberStatistics carManufacturerNumberStatistics = _statisticsRepository.GetMostPopularCarBrandStatistics();

            // Calculate rest functionality
            //TODO implement maxPieCharts parts number (so that we do now have to many "parting") introduce rest section

            return carManufacturerNumberStatistics;
        }

        /// <summary>
        /// Gets the calculation frequency statistics.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CalculationFrequencyStatistics GetCalculationFrequencyStatistics()
        {
            CalculationFrequencyStatistics calculationFrequencyStatistics = _statisticsRepository.GetCalculationFrequencyStatistics();

            //TODO: fill the "zero gaps" in date amount statistics

            return calculationFrequencyStatistics;
        }
    }
}
