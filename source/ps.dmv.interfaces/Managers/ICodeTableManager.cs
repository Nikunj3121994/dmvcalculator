using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.DataTypes;
using ps.dmv.domain.data.Enum;

namespace ps.dmv.interfaces.Managers
{
    public interface ICodeTableManager
    {
        List<CodeTableItem> GetAll(CodeTableType codeTableType);
    }
}
