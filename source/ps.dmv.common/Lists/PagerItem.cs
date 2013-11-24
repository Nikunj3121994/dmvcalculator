using System;
using System.Collections.Generic;
using ps.dmv.common.Helpers;

namespace ps.dmv.common.Lists
{
    /// <summary>
    /// Represents a pager item that cna be used to display paging navigation
    /// </summary>
    public class PagerItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the title of a pager item
        /// </summary>
        /// <value>Pager item title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets pager item URL.
        /// </summary>
        /// <value>Pager item URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets pager item type.
        /// </summary>
        /// <value>Pager item type.</value>
        public PagerItemType Type { get; set; }

        #endregion

        #region Static generator

        /// <summary>
        /// Generates a <see cref="List{Viva.Web.General.PagerItem}"/> collection of pager items with configured consecutive pages.
        /// </summary>
        /// <param name="totalPages">Total pages count.</param>
        /// <param name="currentPage">Current page index.</param>
        /// <param name="urlFormat">URL format string.</param>
        /// <returns>Returns a <see cref="List{Viva.Web.General.PagerItem}"/> collection of pager items.</returns>
        public static List<PagerItem> GeneratePagerItems(int totalPages, int currentPage, string urlFormat)
        {
            return GeneratePagerItems(totalPages, currentPage, urlFormat, DmvConstants.PagerConsecutivePages);
        }

        /// <summary>
        /// Generates a <see cref="List{Viva.Web.General.PagerItem}"/> collection of pager items.
        /// </summary>
        /// <param name="totalPages">Total pages count.</param>
        /// <param name="currentPage">Current page index.</param>
        /// <param name="urlFormat">URL format string.</param>
        /// <param name="consecutivePages">Number of consecutive pages block (will always be converted to an odd number larger than 1).</param>
        /// <returns>Returns a <see cref="List{Viva.Web.General.PagerItem}"/> collection of pager items.</returns>
        public static List<PagerItem> GeneratePagerItems(int totalPages, int currentPage, string urlFormat, int consecutivePages)
        {
            List<PagerItem> result = new List<PagerItem>();

            consecutivePages = (int)Math.Max(3, consecutivePages);
            consecutivePages = consecutivePages % 2 == 0 ? consecutivePages + 1 : consecutivePages;

            // if current page is not the first, "previous" link should be added
            if (currentPage > 1)
            {
                result.Add(new PagerItem
                {
                    Title = DmvConstants.PagerPrevious,
                    Type = PagerItemType.Previous,
                    Url = string.Format(urlFormat, currentPage - 1)
                });
            }

            int start = 1;
            int end = totalPages;

            // calculate start and end for consecutive pages
            if (totalPages > consecutivePages + 1)
            {
                int half = (consecutivePages - 1) / 2;

                start = currentPage - half;
                end = currentPage + half;

                if (start <= half)
                {
                    start = 1;
                    end = consecutivePages;
                }

                if (end > totalPages - half)
                {
                    end = totalPages;
                    start = totalPages - consecutivePages + 1;
                }
            }

            // add first page if necessery
            if (start > 1)
            {
                result.Add(new PagerItem
                {
                    Title = "1",
                    Type = PagerItemType.Page,
                    Url = string.Format(urlFormat, 1)
                });
                // add separator if necessery
                if (start > 2)
                {
                    result.Add(new PagerItem
                    {
                        Title = "&hellip;",
                        Type = PagerItemType.Separator,
                        Url = null
                    });
                }
            }

            // add consecutive pages
            for (int i = start; i <= end; i++)
            {
                result.Add(new PagerItem
                {
                    Title = i.ToString(),
                    Type = i.Equals(currentPage) ? PagerItemType.SelectedPage : PagerItemType.Page,
                    Url = string.Format(urlFormat, i)
                });
            }

            // add last page if necessery
            if (end < totalPages)
            {
                // add spearator if necessery
                if (end < totalPages - 1)
                {
                    result.Add(new PagerItem
                    {
                        Title = "&hellip;",
                        Type = PagerItemType.Separator,
                        Url = null
                    });
                }
                result.Add(new PagerItem
                {
                    Title = totalPages.ToString(),
                    Type = PagerItemType.Page,
                    Url = string.Format(urlFormat, totalPages)
                });
            }

            // when current page is not the last one, "next" should be added
            if (currentPage < totalPages)
            {
                result.Add(new PagerItem
                {
                    Title = DmvConstants.PagerNext,
                    Type = PagerItemType.Next,
                    Url = string.Format(urlFormat, currentPage + 1)
                });
            }

            return result;
        }

        #endregion
    }
}
