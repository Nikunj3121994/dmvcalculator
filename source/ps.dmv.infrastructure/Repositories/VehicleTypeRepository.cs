using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ps.dmv.common.DataTypes;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.infrastructure.Repositories
{
    /// <summary>
    /// VehicleTypeRepository
    /// </summary>
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleTypeRepository"/> class.
        /// </summary>
        public VehicleTypeRepository()
        {

        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<VehicleType, CodeTableItem>();

            List<VehicleType> vehicleTypeList = null;

            using (DmvEntities db = new DmvEntities())
            {
                vehicleTypeList = db.VehicleType.ToList();
            }

            List<CodeTableItem> codeTableItems = Mapper.Map<List<VehicleType>, List<CodeTableItem>>(vehicleTypeList);

            return codeTableItems;
        }
    }
}
