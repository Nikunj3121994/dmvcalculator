using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Repositories
{
    /// <summary>
    /// IStatisticsRepository
    /// </summary>
    public interface IStatisticsRepository
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
