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
    public class VehicleTypeRepository : IVehicleTypeRepository
    {
        private DmvEntities _db = null;

        public VehicleTypeRepository()
        {
            _db = new DmvEntities();
        }

        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<VehicleType, CodeTableItem>();

            List<VehicleType> vehicleTypeList = _db.VehicleType.ToList();

            List<CodeTableItem> codeTableItems = Mapper.Map<List<VehicleType>, List<CodeTableItem>>(vehicleTypeList);

            return codeTableItems;
        }
    }
}
