using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Repositories;

namespace ps.dmv.domain.application.Managers
{
    public class DmvCalculationManager : IDmvCalculationManager   
    {
        private IDmvCalculationRepository _dmvCalculationRepository = null;

        public DmvCalculationManager()
        {
            _dmvCalculationRepository = ServiceLocator.Instance.Resolve<IDmvCalculationRepository>();
        }

        public List<DmvCalculation> GetAll()
        {
            return _dmvCalculationRepository.GetAll();
        }

        public DmvCalculationResult GetDmvTaxValueResult(DmvCalculation dmvCalculation)
        {
            DmvCalculationResult dmvCalculationResult = new DmvCalculationResult();

            dmvCalculationResult.DmvCalculation = this.CalculateDmvAll(dmvCalculation);

            return dmvCalculationResult;
        }

        public List<DmvCalculationResult> GetLastDmvCalculationResult(int numberOfLastResponses)
        {
            throw new NotImplementedException();
        }

        private DmvCalculation CalculateDmvAll(DmvCalculation dmvCalculation)
        {


            return dmvCalculation;
        }
    }
}
