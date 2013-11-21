using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Processors
{
    /// <summary>
    /// IMobileDeProcessor
    /// </summary>
    public interface IMobileDeProcessor
    {
        /// <summary>
        /// Imports the car from mobile de.
        /// </summary>
        /// <param name="importMobileDe">The import mobile de.</param>
        /// <returns></returns>
        Task<MobileDeCar> ImportCarFromMobileDe(ImportMobileDe importMobileDe);
    }
}
