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

        /// <summary>
        /// The statistics DMV calculations number
        /// </summary>
        public const int StatisticsDmvCalculationsNumber = 10;

        /// <summary>
        /// The statistics mobile de calculations number
        /// </summary>
        public const int StatisticsMobileDeCalculationsNumber = 10;

        /// <summary>
        /// The latest mobile de calculations number
        /// </summary>
        public const int LatestMobileDeCalculationsNumber = 5;

        /// <summary>
        /// The pager consecutive pages
        /// </summary>
        public const int PagerConsecutivePages = 5;

        /// <summary>
        /// The pager next
        /// </summary>
        public const string PagerNext = "Naprej";

        /// <summary>
        /// The pager previous
        /// </summary>
        public const string PagerPrevious = "Nazaj";
    }
}
