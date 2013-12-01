using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using ps.dmv.domain.data.Entities;

namespace ps.dmv.web.Infrastructure.Core
{
    /// <summary>
    /// BaseApiDmvController
    /// </summary>
    public class BaseApiDmvController : ApiController
    {
        /// <summary>
        /// Gets the HTTP response message.
        /// </summary>
        /// <param name="dmvCalculationResult">The DMV calculation result.</param>
        /// <returns></returns>
        protected HttpResponseMessage GetHttpResponseMessage(DmvCalculationResult dmvCalculationResult)
        {
            HttpResponseMessage httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, dmvCalculationResult.DmvCalculation.Id);
            httpResponseMessage.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dmvCalculationResult.DmvCalculation.Id }));
            httpResponseMessage.Content = new StringContent(JsonConvert.SerializeObject(dmvCalculationResult));

            return httpResponseMessage;
        }
    }
}