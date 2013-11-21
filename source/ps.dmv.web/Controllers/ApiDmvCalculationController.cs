using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using ps.dmv.common.Core;
using ps.dmv.common.Helpers;
using ps.dmv.common.Lists;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// ApiDmvCalculationController
    /// </summary>
    public class ApiDmvCalculationController : BaseApiDmvController
    {
        private IDmvCalculationManager _dmvCalculationManager = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiDmvCalculationController"/> class.
        /// </summary>
        public ApiDmvCalculationController()
        {
            _dmvCalculationManager = ServiceLocator.Instance.Resolve<IDmvCalculationManager>();
        }

        /// <summary>
        /// Gets the specified page size.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns></returns>
        public PagedList<DmvCalculation> Get([FromUri]int pageSize, [FromUri]int pageIndex)
        {
            PagedList<DmvCalculation> dmvCalculations = _dmvCalculationManager.GetAll(pageSize, pageIndex);

            return dmvCalculations;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public DmvCalculationResult Get(int id)
        {
            return _dmvCalculationManager.Get(id);
        }

        /// <summary>
        /// Posts the specified DMV calculation.
        /// </summary>
        /// <param name="dmvCalculation">The DMV calculation.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Post(DmvCalculation dmvCalculation)
        {
            //DmvCalculationResult dmvCalculationResult = AsyncHelpers.RunSync(() =>_dmvCalculationManager.ProcessDmvTaxValueResult(dmvCalculation));

            DmvCalculationResult dmvCalculationResult = await _dmvCalculationManager.ProcessDmvTaxValueResult(dmvCalculation);

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();

            //TODO: Get base from *
            httpResponseMessage.StatusCode = HttpStatusCode.OK;
            //httpResponseMessage.Headers.Location = new Uri("");
            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(dmvCalculationResult));
            
            return httpResponseMessage;
        }

        // PUT api/<controller>/5
        public void Put(int id, DmvCalculation dmvCalculation)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
