using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Managers
{
    public interface IMobileDeManager
    {
        DmvCalculationResult ImportCarData(Url carMobileUrl);
    }
}
