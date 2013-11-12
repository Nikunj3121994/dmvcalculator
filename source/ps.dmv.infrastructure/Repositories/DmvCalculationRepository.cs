using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ps.dmv.interfaces.Repositories;
using Domain = ps.dmv.domain.data.Entities;

namespace ps.dmv.infrastructure.Repositories
{
    /// <summary>
    /// DmvCalculationRepository
    /// </summary>
    public class DmvCalculationRepository : IDmvCalculationRepository
    {
        private DmvEntities _db = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DmvCalculationRepository"/> class.
        /// </summary>
        public DmvCalculationRepository()
        {
            Mapper.CreateMap<DmvCalculation, Domain.DmvCalculation>();

            _db = new DmvEntities();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<Domain.DmvCalculation> GetAll(int pageIndex, int pageSize)
        {
            int count = _db.DmvCalculation.Where(d => d.IsDeleted == false).Count();

            List<DmvCalculation> dmvCalculationDbList = _db.DmvCalculation.Where(d => d.IsDeleted == false)
                .OrderByDescending(d => d.DateOfCalculation).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            List<Domain.DmvCalculation> dmvCalculationEntityList = Mapper.Map<List<DmvCalculation>, List<Domain.DmvCalculation>>(dmvCalculationDbList);

            return dmvCalculationEntityList;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Domain.DmvCalculation Get(int id)
        {
            DmvCalculation dmvCalculation = _db.DmvCalculation.Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefault();

            Domain.DmvCalculation dmvCalculationEntity = Mapper.Map<Domain.DmvCalculation>(dmvCalculation);

            return dmvCalculationEntity;
        }
    }
}
