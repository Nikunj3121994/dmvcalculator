using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Processors
{
    /// <summary>
    /// IDmvCalculationProcessor
    /// </summary>
    public interface IDmvCalculationProcessor
    {
        /// <summary>
        /// Calculates the DMV all.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        DmvCalculation CalculateDmvAll(DmvCalculation dmvCalculation);
    }
}
