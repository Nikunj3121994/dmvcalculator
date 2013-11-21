using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        /// The _DB
        /// </summary>
        private DmvEntities _db = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileDeRepository"/> class.
        /// </summary>
        public MobileDeRepository()
        {
            Mapper.CreateMap<MobileDeCar, Domain.MobileDeCar>();
            Mapper.CreateMap<Domain.MobileDeCar, MobileDeCar>();

            _db = new DmvEntities();
        }

        public PagedList<Domain.MobileDeCar> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Domain.MobileDeCar Get(int id)
        {
            throw new NotImplementedException();

        //    Instructor instructor = db.Instructors
        //.Include(i => i.OfficeAssignment)
        //.Where(i => i.ID == id)
        //.Single();
        }

        /// <summary>
        /// Saves the specified mobile de car.
        /// </summary>
        /// <param name="mobileDeCar">The mobile de car.</param>
        /// <returns></returns>
        public async Task<Domain.MobileDeCar> Save(Domain.MobileDeCar mobileDeCar)
        {
            MobileDeCar mobileDeCarDb = Mapper.Map<MobileDeCar>(mobileDeCar);

            mobileDeCarDb = _db.MobileDeCar.Add(mobileDeCarDb);

            await _db.SaveChangesAsync();

            Domain.MobileDeCar mobileDeCarEntity = Mapper.Map<Domain.MobileDeCar>(mobileDeCarDb);

            return mobileDeCarEntity;
        }
    }
}
