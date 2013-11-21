using System;
using System.Collections.Generic;

namespace ps.dmv.common.Lists
{
	/// <summary>
	/// Represents a stringly typed paged list of objects that can be accessed by index
	/// </summary>
	/// <typeparam name="TObject">Type of elements in the paged list.</typeparam>
	public class PagedList<TObject> : List<TObject>, IPagedList<TObject>
	{
		#region IPagedList<TObject> Members

		/// <summary>
		/// Gets the total number of pages.
		/// </summary>
		/// <value></value>
		public int TotalPageCount { get; private set; }

		/// <summary>
		/// Gets the total number of items.
		/// </summary>
		/// <value></value>
		public long TotalItemCount { get; private set; }

		/// <summary>
		/// Gets the current page index.
		/// </summary>
		/// <value></value>
		public int CurrentPageIndex { get; private set; }

		/// <summary>
		/// Gets the size of the page. If not set, equals collection count.
		/// </summary>
		/// <value></value>
		public int PageSize
		{
			get { return pageSize.GetValueOrDefault(this.Count); }
		}
		private int? pageSize;

		/// <summary>
		/// Is last page full => new message goes on new page.
		/// </summary>
		public bool IsLastPageFull
		{
			get 
			{ 
				return PageSize != 0 ? TotalItemCount % PageSize == 0 : false; 
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="PagedList&lt;TObject&gt;"/> class.
		/// </summary>
		/// <param name="collection">The collection whose elements are copied to the new paged list.</param>
		/// <param name="currentPageIndex">The current page index. First page should be 0.</param>
		/// <param name="totalPageCount">Total page count of the complete result set.</param>
		/// <param name="totalItemCount">Total item count</param>
		public PagedList(IEnumerable<TObject> collection, int currentPageIndex, int totalPageCount, long totalItemCount)
			: base(collection)
		{
			// check arguments
			this.CheckArguments(currentPageIndex, totalPageCount);

			// set properties
			this.TotalPageCount = totalPageCount;
			this.TotalItemCount = totalItemCount;
			this.CurrentPageIndex = currentPageIndex;
		}

		public PagedList(int capacity, int currentPageIndex, int totalPageCount, long totalItemCount) : base(capacity)
		{
			// check arguments
			this.CheckArguments(currentPageIndex, totalPageCount);

			// set properties
			this.TotalPageCount = totalPageCount;
			this.TotalItemCount = totalItemCount;
			this.CurrentPageIndex = currentPageIndex;
		}

		public PagedList(IEnumerable<TObject> collection, int currentPageIndex, int totalPageCount, long totalItemCount, int pageSize)
			: this(collection, currentPageIndex, totalPageCount, totalItemCount)
		{
			this.pageSize = pageSize;
		}

		#endregion

		#region Public methods

		public new PagedList<TOutput> ConvertAll<TOutput>(Converter<TObject, TOutput> converter)
		{
			if (converter == null)
			{
				throw new ArgumentNullException("converter");
			}
			PagedList<TOutput> result = new PagedList<TOutput>(this.Count, this.CurrentPageIndex, this.TotalPageCount, this.TotalItemCount);
			foreach (TObject obj in this)
			{
				result.Add(converter(obj));
			}
			return result;
		}

		#endregion

		#region Private methods

		private void CheckArguments(int currentPageIndex, int totalPageCount)
		{
			// check arguments validity
			if (currentPageIndex < 0)
			{
				throw new ArgumentOutOfRangeException("currentPageindex", currentPageIndex, "Current page index cannot be negative.");
			}
			if (totalPageCount < 0)
			{
				throw new ArgumentOutOfRangeException("totalPageCount", totalPageCount, "Total page count caanot be negative.");
			}
		}

		#endregion
	}
}
