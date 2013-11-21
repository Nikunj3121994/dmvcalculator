using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.Lists;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Managers
{
    /// <summary>
    /// IMobileDeManager
    /// </summary>
    public interface IMobileDeManager
    {
        /// <summary>
        /// Imports the car data.
        /// </summary>
        /// <param name="importMobileDe">The import mobile de.</param>
        /// <returns></returns>
        Task<DmvCalculationResult> ImportCarData(ImportMobileDe importMobileDe);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        PagedList<MobileDeCar> GetAll(int pageIndex, int pageSize);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        MobileDeCar Get(int id);
    }
}
