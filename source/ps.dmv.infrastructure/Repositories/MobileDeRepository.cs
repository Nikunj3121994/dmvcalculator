using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ps.dmv.common.Extensions;
using ps.dmv.common.Lists;
using ps.dmv.interfaces.Repositories;
using Domain = ps.dmv.domain.data.Entities;

namespace ps.dmv.infrastructure.Repositories
{
    /// <summary>
    /// MobileDeRepository
    /// </summary>
    public class MobileDeRepository : IMobileDeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MobileDeRepository"/> class.
        /// </summary>
        public MobileDeRepository()
        {
            Mapper.CreateMap<MobileDeCar, Domain.MobileDeCar>();
            Mapper.CreateMap<Domain.MobileDeCar, MobileDeCar>();

            Mapper.CreateMap<DmvCalculation, Domain.DmvCalculation>();
            Mapper.CreateMap<Domain.DmvCalculation, DmvCalculation>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public PagedList<Domain.MobileDeCar> GetAll(int pageIndex, int pageSize)
        {
            int count = 0;

            List<MobileDeCar> mobileDeCarDbList = null;

            using (DmvEntities db = new DmvEntities())
            {
                count = db.MobileDeCar.Where(m => m.IsDeleted == false).Count();

                mobileDeCarDbList = db.MobileDeCar.Include("DmvCalculation").Where(m => m.IsDeleted == false)
                        .OrderByDescending(m => m.CreatedOn).Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }

            List<Domain.MobileDeCar> mobileDeCarEntityList = Mapper.Map<List<MobileDeCar>, List<Domain.MobileDeCar>>(mobileDeCarDbList);

            int pageCount = (int)Math.Ceiling(Convert.ToDouble(count) / (double)pageSize);//TODO move it to the infrastructure

            return mobileDeCarEntityList.ToPagedList(pageIndex, pageCount, count);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Domain.MobileDeCar Get(int id)
        {
            MobileDeCar mobileDeCarDb = null;

            using (DmvEntities db = new DmvEntities())
            {
                mobileDeCarDb = db.MobileDeCar.Include("DmvCalculation").Where(c => c.IsDeleted == false && c.Id == id).FirstOrDefault();
            }

            Domain.MobileDeCar mobileDeCarEntity = Mapper.Map<Domain.MobileDeCar>(mobileDeCarDb);

            return mobileDeCarEntity;
        }

        /// <summary>
        /// Saves the specified mobile de car.
        /// </summary>
        /// <param name="mobileDeCar">The mobile de car.</param>
        /// <returns></returns>
        public async Task<Domain.MobileDeCar> Save(Domain.MobileDeCar mobileDeCar)
        {
            MobileDeCar mobileDeCarDb = Mapper.Map<MobileDeCar>(mobileDeCar);

            using (DmvEntities db = new DmvEntities())
            {
                mobileDeCarDb = db.MobileDeCar.Add(mobileDeCarDb);

                await db.SaveChangesAsync();
            }

            Domain.MobileDeCar mobileDeCarEntity = Mapper.Map<Domain.MobileDeCar>(mobileDeCarDb);

            return mobileDeCarEntity;
        }
    }
}
