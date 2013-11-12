﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.interfaces.Repositories
{
    public interface IDmvCalculationRepository
    {
        List<DmvCalculation> GetAll();

        DmvCalculation Get(int id);
    }
}
