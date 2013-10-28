using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;
using ps.dmv.domain.entities.Entities;

namespace ps.dmv.interfaces.Managers
{
    public interface IDmvManager
    {
        DmvCalculationResponse GetDmvTaxValueResult(DmvCalculation dmvCalculation);
    }
}
