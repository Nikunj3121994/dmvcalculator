using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.infrastructure.Repositories
{
    /// <summary>
    /// StatisticsRepository
    /// </summary>
    public class StatisticsRepository : IStatisticsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsRepository"/> class.
        /// </summary>
        public StatisticsRepository()
        {

        }

        /// <summary>
        /// Gets the most popular car brand statistics.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CarManufacturerNumberStatistics GetMostPopularCarBrandStatistics()
        {
            CarManufacturerNumberStatistics carManufacturerNumberStatistics = new CarManufacturerNumberStatistics();

            using (DmvEntities db = new DmvEntities())
            {
                carManufacturerNumberStatistics.CarManufacturerNumber = db.MobileDeCar
                    .Where(m => m.IsDeleted == false)
                    .GroupBy(m => m.Maker)
                    .Select(g => new { Name = g.Key, Count = g.Count() })
                    .ToDictionary(m => m.Name, m => m.Count);
            }

            return carManufacturerNumberStatistics;
        }

        /// <summary>
        /// Gets the calculation frequency statistics.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public CalculationFrequencyStatistics GetCalculationFrequencyStatistics()
        {
            CalculationFrequencyStatistics calculationFrequencyStatistics = new CalculationFrequencyStatistics();

            using (DmvEntities db = new DmvEntities())
            {
            calculationFrequencyStatistics.CalculationFrequencyData = db.DmvCalculation
                    .Where(m => m.IsDeleted == false)
                    .GroupBy(m => EntityFunctions.TruncateTime(m.CreatedOn))
                    .Select(g => new { Date = g.Key, Count = g.Count() })
                    .ToDictionary(m => m.Date, m => m.Count);
            }

            return calculationFrequencyStatistics;
        }
    }
}
