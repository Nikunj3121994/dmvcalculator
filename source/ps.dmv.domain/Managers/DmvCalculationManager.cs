using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ps.dmv.common.Core;
using ps.dmv.common.Helpers;
using ps.dmv.common.Lists;
using ps.dmv.domain.application.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Processors;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Managers
{
    /// <summary>
    /// DmvCalculationManager
    /// </summary>
    public class DmvCalculationManager : ManagerBase<DmvCalculation>, IDmvCalculationManager   
    {
        private IDmvCalculationRepository _dmvCalculationRepository = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DmvCalculationManager"/> class.
        /// </summary>
        public DmvCalculationManager()
        {
            _dmvCalculationRepository = ServiceLocator.Instance.Resolve<IDmvCalculationRepository>();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="includeImportedCalculation"></param>
        /// <returns></returns>
        public PagedList<DmvCalculation> GetAll(int pageIndex, int pageSize, bool includeImportedCalculation)
        {
            return _dmvCalculationRepository.GetAll(pageIndex, pageSize, includeImportedCalculation);
        }

        /// <summary>
        /// Gets the DMV tax value result.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        public async Task<DmvCalculationResult> ProcessDmvTaxValueResult(DmvCalculation dmvCalculation)
        {
            DmvCalculation dmvCalculationCalculated = ServiceLocator.Instance.Resolve<IDmvCalculationProcessor>().CalculateDmvAll(dmvCalculation);

            dmvCalculationCalculated.CreatedOn = DateTime.UtcNow;

            base.Validate(dmvCalculationCalculated);

            dmvCalculationCalculated = await _dmvCalculationRepository.Save(dmvCalculationCalculated);

            DmvCalculationResult dmvCalculationResult = new DmvCalculationResult(dmvCalculationCalculated);

            return dmvCalculationResult;
        }

        /// <summary>
        /// Gets the last DMV calculation result.
        /// </summary>
        /// <param name="numberOfLastResponses">The number of last responses.</param>
        /// <param name="includeImportedCalculation"></param>
        /// <returns></returns>
        public List<Task<DmvCalculationResult>> GetLastDmvCalculationResult(int numberOfLastResponses, bool includeImportedCalculation)
        {
            return _dmvCalculationRepository.GetAll(DmvConstants.InitialPageIndex, numberOfLastResponses, includeImportedCalculation).Select(async i => await this.ProcessDmvTaxValueResult(i)).ToList();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public DmvCalculationResult Get(int id)
        {
            DmvCalculation dmvCalculation = _dmvCalculationRepository.Get(id);

            return new DmvCalculationResult(dmvCalculation);
        }

        /// <summary>
        /// Updates the specified DMV calculation result.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation result.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<DmvCalculationResult> Update(DmvCalculation dmvCalculation)
        {
            base.Validate(dmvCalculation);

            DmvCalculation dmvCalculationFromDb = await _dmvCalculationRepository.Update(dmvCalculation);

            return new DmvCalculationResult(dmvCalculationFromDb);
        }
    }
}
