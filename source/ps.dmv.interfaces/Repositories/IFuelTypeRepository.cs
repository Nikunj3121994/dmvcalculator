using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.DataTypes;

namespace ps.dmv.interfaces.Repositories
{
    public interface IFuelTypeRepository
    {
        List<CodeTableItem> GetAll();
    }
}
