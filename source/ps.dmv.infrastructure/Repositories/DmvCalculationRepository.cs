using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
        /// Initializes a new instance of the <see cref="DmvCalculationRepository"/> class.
        /// </summary>
        public DmvCalculationRepository()
        {
            Mapper.CreateMap<DmvCalculation, Domain.DmvCalculation>();
            Mapper.CreateMap<Domain.DmvCalculation, DmvCalculation>();

            Mapper.CreateMap<MobileDeCar, Domain.MobileDeCar>();
            Mapper.CreateMap<Domain.MobileDeCar, MobileDeCar>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public PagedList<Domain.DmvCalculation> GetAll(int pageIndex, int pageSize)
        {
            int count = 0;

            List<DmvCalculation> dmvCalculationDbList = null;

            using (DmvEntities db = new DmvEntities())
            {
                count = db.DmvCalculation.Where(d => d.IsDeleted == false).Count();

                dmvCalculationDbList = db.DmvCalculation.Include("MobileDeCar").Where(d => d.IsDeleted == false)
                    .OrderByDescending(d => d.CreatedOn).Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }

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
            DmvCalculation dmvCalculationDb = null;

            using (DmvEntities db = new DmvEntities())
            {

                dmvCalculationDb = db.DmvCalculation.Include("MobileDeCar").Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefault();
            }

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

            using (DmvEntities db = new DmvEntities())
            {
                dmvCalculationDb = db.DmvCalculation.Add(dmvCalculationDb);

                await db.SaveChangesAsync();
            }

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

            using (DmvEntities db = new DmvEntities())
            {
                dmvCalculationDb = db.DmvCalculation.Attach(dmvCalculationDb);

                DbEntityEntry<DmvCalculation> entry = db.Entry(dmvCalculationDb);

                entry.State = EntityState.Modified;
                //entry.Property(e => e.MobileDeCarId).IsModified = true;

                await db.SaveChangesAsync();
            }

            Domain.DmvCalculation dmvCalculationEntity = Mapper.Map<Domain.DmvCalculation>(dmvCalculationDb);

            return dmvCalculationEntity;
        }
    }
}
