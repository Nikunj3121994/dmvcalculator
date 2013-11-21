using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using ps.dmv.common.Extensions;
using ps.dmv.common.Lists;
using ps.dmv.interfaces.Repositories;
using Domain = ps.dmv.domain.data.Entities;

namespace ps.dmv.infrastructure.Repositories
{
    /// <summary>
    /// DmvCalculationRepository
    /// </summary>
    public class DmvCalculationRepository : IDmvCalculationRepository
    {
        /// <summary>
        /// The _DB
        /// </summary>
        private DmvEntities _db = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DmvCalculationRepository"/> class.
        /// </summary>
        public DmvCalculationRepository()
        {
            Mapper.CreateMap<DmvCalculation, Domain.DmvCalculation>();
            Mapper.CreateMap<Domain.DmvCalculation, DmvCalculation>();

            Mapper.CreateMap<MobileDeCar, Domain.MobileDeCar>();
            Mapper.CreateMap<Domain.MobileDeCar, MobileDeCar>();

            _db = new DmvEntities();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public PagedList<Domain.DmvCalculation> GetAll(int pageIndex, int pageSize)
        {
            int count = _db.DmvCalculation.Where(d => d.IsDeleted == false).Count();

            List<DmvCalculation> dmvCalculationDbList = _db.DmvCalculation.Include("MobileDeCar").Where(d => d.IsDeleted == false)
                .OrderByDescending(d => d.CreatedOn).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            List<Domain.DmvCalculation> dmvCalculationEntityList = Mapper.Map<List<DmvCalculation>, List<Domain.DmvCalculation>>(dmvCalculationDbList);

            int pageCount = (int)Math.Ceiling(Convert.ToDouble(count) / (double)pageSize);

            return dmvCalculationEntityList.ToPagedList(pageIndex, pageCount, count);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Domain.DmvCalculation Get(int id)
        {
            DmvCalculation dmvCalculationDb = _db.DmvCalculation.Include("MobileDeCar").Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefault();//TODO: check inlude!

            Domain.DmvCalculation dmvCalculationEntity = Mapper.Map<Domain.DmvCalculation>(dmvCalculationDb);

            return dmvCalculationEntity;
        }

        /// <summary>
        /// Saves the specified DMV calculation.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Domain.DmvCalculation> Save(Domain.DmvCalculation dmvCalculation)
        {
            DmvCalculation dmvCalculationDb = Mapper.Map<DmvCalculation>(dmvCalculation);

            dmvCalculationDb = _db.DmvCalculation.Add(dmvCalculationDb);

            await _db.SaveChangesAsync();

            Domain.DmvCalculation dmvCalculationEntity = Mapper.Map<Domain.DmvCalculation>(dmvCalculationDb);

            return dmvCalculationEntity;
        }

        /// <summary>
        /// Updates the specified DMV calculation.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<Domain.DmvCalculation> Update(Domain.DmvCalculation dmvCalculation)
        {
            DmvCalculation dmvCalculationDb = Mapper.Map<DmvCalculation>(dmvCalculation);

            dmvCalculationDb = _db.DmvCalculation.Attach(dmvCalculationDb);
            DbEntityEntry<DmvCalculation> entry = _db.Entry(dmvCalculationDb);
            //_db.Entry(dmvCalculationDb).State = EntityState.Modified;//TODO: change the updaing to the whole entity by loading and updating it
            entry.Property(e => e.MobileDeCarId).IsModified = true;

            await _db.SaveChangesAsync();

            Domain.DmvCalculation dmvCalculationEntity = Mapper.Map<Domain.DmvCalculation>(dmvCalculationDb);

            return dmvCalculationEntity;
        }
    }
}
