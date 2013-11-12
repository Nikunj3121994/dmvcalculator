using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.Core;
using ps.dmv.common.DataTypes;
using ps.dmv.domain.data.Enum;
using ps.dmv.infrastructure;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Managers
{
    public class CodeTableManager : ICodeTableManager
    {
        public CodeTableManager()
        {
            
        }

        public List<CodeTableItem> GetAll(CodeTableType codeTableType)
        {
            List<CodeTableItem> list = new List<CodeTableItem>();

            switch (codeTableType)
            {
                case CodeTableType.VehicleType:
                    list = ServiceLocator.Instance.Resolve<IVehicleTypeRepository>().GetAll();
                    break;
                case CodeTableType.EngineType:
                    list = ServiceLocator.Instance.Resolve<IEngineTypeRepository>().GetAll();
                    break;
                case CodeTableType.EuroExhaustType:
                    list = ServiceLocator.Instance.Resolve<IEuroExhaustTypeRepository>().GetAll();
                    break;
                case CodeTableType.FuelType:
                    list = ServiceLocator.Instance.Resolve<IFuelTypeRepository>().GetAll();
                    break;
                default:
                    throw new Exception("Unknown CodeTableType: " + codeTableType);
            }

            return list;
        }
    }
}
