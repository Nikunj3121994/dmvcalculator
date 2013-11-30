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
using ps.dmv.domain.application.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Processors;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Managers
{
    /// <summary>
    /// MobileDeManager
    /// </summary>
    public class MobileDeManager : ManagerBase<MobileDeCar>, IMobileDeManager
    {
        private IMobileDeRepository _mobileDeRepository = null;
        private IDmvCalculationManager _dmvCalculationManager = null;

        public MobileDeManager()
        {
            _mobileDeRepository = ServiceLocator.Instance.Resolve<IMobileDeRepository>();
            _dmvCalculationManager = ServiceLocator.Instance.Resolve<IDmvCalculationManager>();
        }

        /// <summary>
        /// Imports the car data.
        /// </summary>
        /// <param name="importMobileDe">The import mobile de.</param>
        /// <returns></returns>
        public async Task<DmvCalculationResult> ImportCarData(ImportMobileDe importMobileDe)
        {
            MobileDeCar mobileDeCar = await ServiceLocator.Instance.Resolve<IMobileDeProcessor>().ImportCarFromMobileDe(importMobileDe);

            DmvCalculationResult dmvCalculationResult = await _dmvCalculationManager.ProcessDmvTaxValueResult(mobileDeCar.DmvCalculation);
            mobileDeCar.DmvCalculationId = dmvCalculationResult.DmvCalculation.Id;
            mobileDeCar.DmvCalculation = null;
            mobileDeCar.CreatedOn = DateTime.UtcNow;

            base.Validate(mobileDeCar);

            mobileDeCar = await _mobileDeRepository.Save(mobileDeCar);
            dmvCalculationResult.MobileDeCar = mobileDeCar;

            dmvCalculationResult.DmvCalculation.MobileDeCarId = mobileDeCar.Id;

            dmvCalculationResult = await _dmvCalculationManager.Update(dmvCalculationResult.DmvCalculation);

            return dmvCalculationResult;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public PagedList<MobileDeCar> GetAll(int pageIndex, int pageSize)
        {
            PagedList<MobileDeCar> mobileDeCarList = _mobileDeRepository.GetAll(pageIndex, pageSize);

            return mobileDeCarList;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public MobileDeCar Get(int id)
        {
            MobileDeCar mobileDeCar = _mobileDeRepository.Get(id);

            return mobileDeCar;
        }
    }
}
