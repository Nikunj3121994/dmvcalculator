using System.Collections.Generic;
using System.Linq;
using ps.dmv.common.Lists;

namespace ps.dmv.common.Extensions
{
	/// <summary>
	/// IEnumerable extension methods
	/// </summary>
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Creates a <see cref="Viva.Objects.General.PagedList{TObject}"/> from an <see cref="System.Collections.Generic.IEnumerable{TObject}"/>.
		/// </summary>
		/// <typeparam name="TObject">Type of elements in the list.</typeparam>
		/// <param name="collection"><see cref="System.Collections.Generic.IEnumerable{TObject}"/> collection instance being extended.</param>
		/// <param name="currentPageIndex">Current page index.</param>
		/// <param name="totalPageCount">Total page count.</param>
		/// <param name="totalItemCount">Total item count.</param>
		/// <returns>Returns a <see cref="Viva.Objects.General.IPagedList{TObject}"/> object collection.</returns>

		public static PagedList<TObject> ToPagedList<TObject>(this IEnumerable<TObject> collection, int currentPageIndex, int totalPageCount, long totalItemCount)
		{
			return new PagedList<TObject>(collection.ToList(), currentPageIndex, totalPageCount, totalItemCount);
		}

		public static PagedList<TObject> ToPagedList<TObject>(this IEnumerable<TObject> collection, int currentPageIndex, int totalPageCount, long totalItemCount, int pageSize)
		{
			return new PagedList<TObject>(collection.ToList(), currentPageIndex, totalPageCount, totalItemCount, pageSize);
		}
	}
}
