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
    public class EngineTypeRepository : IEngineTypeRepository
    {
        private DmvEntities _db = null;

        public EngineTypeRepository()
        {
            _db = new DmvEntities();
        }

        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<EngineType, CodeTableItem>();

            List<EngineType> engineTypeList = _db.EngineType.ToList();

            List<CodeTableItem> codeTableItems = Mapper.Map<List<EngineType>, List<CodeTableItem>>(engineTypeList);

            return codeTableItems;
        }
    }
}
