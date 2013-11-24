using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using ps.dmv.common.Core;
using ps.dmv.common.Lists;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// ApiMobileDeController
    /// </summary>
    public class ApiMobileDeController : BaseApiDmvController
    {
        private IMobileDeManager _mobileDeManager = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiMobileDeController"/> class.
        /// </summary>
        public ApiMobileDeController()
        {
            _mobileDeManager = ServiceLocator.Instance.Resolve<IMobileDeManager>();
        }

        /// <summary>
        /// Gets the specified page size.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <returns></returns>
        public PagedList<MobileDeCar> Get([FromUri]int pageSize, [FromUri]int pageIndex)
        {
            PagedList<MobileDeCar> mobileDeCarList = _mobileDeManager.GetAll(pageSize, pageIndex);

            return mobileDeCarList;
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="importMobileDe">The import mobile de.</param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, ImportMobileDe importMobileDe)
        {
            _mobileDeManager.ImportCarData(importMobileDe);

            HttpResponseMessage httpResponseMessage = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };

            //TODO: add proper response message

            return httpResponseMessage;
        }
    }
}
