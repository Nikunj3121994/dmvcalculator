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
    public class EuroExhaustTypeRepository : IEuroExhaustTypeRepository
    {
        private DmvEntities _db = null;

        public EuroExhaustTypeRepository()
        {
            _db = new DmvEntities();
        }

        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<EuroExhaustType, CodeTableItem>();

            List<EuroExhaustType> euroExhaustTypeList = _db.EuroExhaustType.ToList();

            List<CodeTableItem> codeTableItems = Mapper.Map<List<EuroExhaustType>, List<CodeTableItem>>(euroExhaustTypeList);

            return codeTableItems;
        }
    }
}
