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
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private DmvEntities _db = null;

        public FuelTypeRepository()
        {
            _db = new DmvEntities();
        }

        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<FuelType, CodeTableItem>();

            List<FuelType> fuelTypeList = _db.FuelType.ToList();

            List<CodeTableItem> codeTableItems = Mapper.Map<List<FuelType>, List<CodeTableItem>>(fuelTypeList);

            return codeTableItems;
        }
    }
}
