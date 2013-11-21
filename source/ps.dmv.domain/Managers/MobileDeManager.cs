using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using ps.dmv.common.Core;
using ps.dmv.common.Lists;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Processors;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Managers
{
    /// <summary>
    /// MobileDeManager
    /// </summary>
    public class MobileDeManager : IMobileDeManager
    {
        /// <summary>
        /// Imports the car data.
        /// </summary>
        /// <param name="importMobileDe">The import mobile de.</param>
        /// <returns></returns>
        public async Task<DmvCalculationResult> ImportCarData(ImportMobileDe importMobileDe)
        {
            MobileDeCar mobileDeCar = await ServiceLocator.Instance.Resolve<IMobileDeProcessor>().ImportCarFromMobileDe(importMobileDe);

            DmvCalculationResult dmvCalculationResult = await ServiceLocator.Instance.Resolve<IDmvCalculationManager>().ProcessDmvTaxValueResult(mobileDeCar.DmvCalculation);
            mobileDeCar.DmvCalculationId = dmvCalculationResult.DmvCalculation.Id;
            mobileDeCar.DmvCalculation = null;
            mobileDeCar.CreatedOn = DateTime.Now;
            
            mobileDeCar = await ServiceLocator.Instance.Resolve<IMobileDeRepository>().Save(mobileDeCar);
            dmvCalculationResult.MobileDeCar = mobileDeCar;

            dmvCalculationResult.DmvCalculation.MobileDeCarId = mobileDeCar.Id;
            dmvCalculationResult = await ServiceLocator.Instance.Resolve<IDmvCalculationManager>().Update(dmvCalculationResult.DmvCalculation);

            return dmvCalculationResult;
        }

        public PagedList<MobileDeCar> GetAll(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public MobileDeCar Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
