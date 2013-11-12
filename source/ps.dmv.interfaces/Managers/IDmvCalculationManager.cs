using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Managers
{
    public interface IDmvCalculationManager
    {
        List<DmvCalculation> GetAll();

        DmvCalculationResult GetDmvTaxValueResult(DmvCalculation dmvCalculation);

        List<DmvCalculationResult> GetLastDmvCalculationResult(int numberOfLastResponses);
    }
}
