using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.Lists;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Repositories
{
    /// <summary>
    /// IDmvCalculationRepository
    /// </summary>
    public interface IDmvCalculationRepository
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        PagedList<DmvCalculation> GetAll(int pageIndex, int pageSize, bool includeImportedCalculation);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        DmvCalculation Get(int id);

        /// <summary>
        /// Saves the specified DMV calculation.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        Task<DmvCalculation> Save(DmvCalculation dmvCalculation);

        /// <summary>
        /// Updates the specified DMV calculation.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        Task<DmvCalculation> Update(DmvCalculation dmvCalculation);
    }
}
