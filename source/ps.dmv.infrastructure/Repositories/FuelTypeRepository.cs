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
    /// FuelTypeRepository
    /// </summary>
    public class FuelTypeRepository : IFuelTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuelTypeRepository"/> class.
        /// </summary>
        public FuelTypeRepository()
        {

        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<FuelType, CodeTableItem>();

            List<FuelType> fuelTypeList = null;

            using (DmvEntities db = new DmvEntities())
            {
                fuelTypeList = db.FuelType.ToList();
            }

            List<CodeTableItem> codeTableItems = Mapper.Map<List<FuelType>, List<CodeTableItem>>(fuelTypeList);

            return codeTableItems;
        }
    }
}
