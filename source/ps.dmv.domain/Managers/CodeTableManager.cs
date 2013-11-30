using System;
using System.Collections.Generic;
using ps.dmv.common.Core;
using ps.dmv.common.DataTypes;
using ps.dmv.domain.application.Core;
using ps.dmv.domain.data.Enum;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Managers
{
    /// <summary>
    /// CodeTableManager
    /// </summary>
    public class CodeTableManager : ManagerBase<object>, ICodeTableManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeTableManager"/> class.
        /// </summary>
        public CodeTableManager()
        {
            
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="codeTableType">Type of the code table.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Unknown CodeTableType:  + codeTableType</exception>
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
