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
    /// IMobileDeRepository
    /// </summary>
    public interface IMobileDeRepository
    {
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

        /// <summary>
        /// Saves the specified mobile de car.
        /// </summary>
        /// <param name="mobileDeCar">The mobile de car.</param>
        /// <returns></returns>
        Task<MobileDeCar> Save(MobileDeCar mobileDeCar);
    }
}
