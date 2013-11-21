using System.Collections.Generic;

namespace ps.dmv.common.Lists
{
	/// <summary>
	/// Represents a collection of objects that can be individually accessed by index while also providing result page information.
	/// </summary>
	/// <typeparam name="TObject">Type of elements in the paged list.</typeparam>
	public interface IPagedList<TObject> : IList<TObject>
	{
		/// <summary>
		/// Gets the total number of pages.
		/// </summary>
		int TotalPageCount { get; }

		/// <summary>
		/// Gets the total number of items.
		/// </summary>
		long TotalItemCount { get; }

		/// <summary>
		/// Gets the current page index.
		/// </summary>
		int CurrentPageIndex { get; }


		/// <summary>
		/// Gets the size of the page that equals collection count.
		/// </summary>
		int PageSize { get; }
	}
}
