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
    /// EngineTypeRepository
    /// </summary>
    public class EngineTypeRepository : IEngineTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineTypeRepository"/> class.
        /// </summary>
        public EngineTypeRepository()
        {

        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<EngineType, CodeTableItem>();

            List<EngineType> engineTypeList = null;

            using (DmvEntities db = new DmvEntities())
            {
                engineTypeList = db.EngineType.ToList();
            }

            List<CodeTableItem> codeTableItems = Mapper.Map<List<EngineType>, List<CodeTableItem>>(engineTypeList);

            return codeTableItems;
        }
    }
}
