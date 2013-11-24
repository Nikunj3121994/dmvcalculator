using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ps.dmv.common.Core;
using ps.dmv.common.DataTypes;
using ps.dmv.domain.data.Enum;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// ApiCodeTableController
    /// </summary>
    public class ApiCodeTableController : BaseApiDmvController
    {
        private ICodeTableManager _codeTableManager = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiCodeTableController"/> class.
        /// </summary>
        public ApiCodeTableController()
        {
            _codeTableManager = ServiceLocator.Instance.Resolve<ICodeTableManager>();
        }

        /// <summary>
        /// Gets the specified code table type.
        /// </summary>
        /// <param name="codeTableType">Type of the code table.</param>
        /// <returns></returns>
        public List<CodeTableItem> Get([FromUri]CodeTableType codeTableType)
        {
            return _codeTableManager.GetAll(codeTableType);
        }
    }
}
