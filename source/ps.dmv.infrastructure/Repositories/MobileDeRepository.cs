using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.interfaces.Repositories;
using Domain = ps.dmv.domain.data.Entities;

namespace ps.dmv.infrastructure.Repositories
{
    public class MobileDeRepository : IMobileDeRepository
    {
        public List<Domain.MobileDeCar> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.MobileDeCar Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Domain.MobileDeCar mobileDeCar)
        {
            throw new NotImplementedException();
        }
    }
}
