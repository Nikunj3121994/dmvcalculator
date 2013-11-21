using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.common.Helpers
{
    /// <summary>
    /// DmvConstants
    /// </summary>
    public static class DmvConstants
    {
        /// <summary>
        /// Used for XSRF protection when adding external logins
        /// </summary>
        public const string XsrfKey = "XsrfId";

        /// <summary>
        /// The latest DMV calculations number
        /// </summary>
        public const int LatestDmvCalculationsNumber = 5;

        /// <summary>
        /// The initial page index
        /// </summary>
        public const int InitialPageIndex = 0;
    }
}
