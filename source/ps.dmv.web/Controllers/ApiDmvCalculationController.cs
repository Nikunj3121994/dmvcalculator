using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ps.dmv.common.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    public class ApiDmvCalculationController : BaseApiDmvController
    {
        private IDmvCalculationManager _dmvCalculationManager = null;

        public ApiDmvCalculationController()
        {
            _dmvCalculationManager = ServiceLocator.Instance.Resolve<IDmvCalculationManager>();
        }

        public List<DmvCalculation> Get()
        {
            List<DmvCalculation> dmvCalculations = _dmvCalculationManager.GetAll();

            return dmvCalculations;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
