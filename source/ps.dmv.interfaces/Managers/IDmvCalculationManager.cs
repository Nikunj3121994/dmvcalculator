using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.Lists;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Managers
{
    /// <summary>
    /// IDmvCalculationManager
    /// </summary>
    public interface IDmvCalculationManager
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        PagedList<DmvCalculation> GetAll(int pageIndex, int pageSize);

        /// <summary>
        /// Processes the DMV tax value result.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        Task<DmvCalculationResult> ProcessDmvTaxValueResult(DmvCalculation dmvCalculation);

        /// <summary>
        /// Gets the last DMV calculation result.
        /// </summary>
        /// <param name="numberOfLastResponses">The number of last responses.</param>
        /// <returns></returns>
        List<Task<DmvCalculationResult>> GetLastDmvCalculationResult(int numberOfLastResponses);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        DmvCalculationResult Get(int id);

        /// <summary>
        /// Updates the specified DMV calculation result.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation result.</param>
        /// <returns></returns>
        Task<DmvCalculationResult> Update(DmvCalculation dmvCalculation);
    }
}
