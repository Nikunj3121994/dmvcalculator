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
    /// EuroExhaustTypeRepository
    /// </summary>
    public class EuroExhaustTypeRepository : IEuroExhaustTypeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EuroExhaustTypeRepository"/> class.
        /// </summary>
        public EuroExhaustTypeRepository()
        {

        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<CodeTableItem> GetAll()
        {
            Mapper.CreateMap<EuroExhaustType, CodeTableItem>();

            List<EuroExhaustType> euroExhaustTypeList = null;

            using (DmvEntities db = new DmvEntities())
            {
                euroExhaustTypeList = db.EuroExhaustType.ToList();
            }

            List<CodeTableItem> codeTableItems = Mapper.Map<List<EuroExhaustType>, List<CodeTableItem>>(euroExhaustTypeList);

            return codeTableItems;
        }
    }
}
