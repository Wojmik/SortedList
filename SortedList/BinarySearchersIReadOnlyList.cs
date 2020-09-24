using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.SortedList
{
	/// <summary>
	/// Extension of IReadOnlyList&lt;T&gt;, ReadOnlySpan&lt;T&gt;, Span&lt;T&gt;, ReadOnlyMemory&lt;T&gt;, Memory&lt;T&gt; allowing binary search in sorted lists
	/// </summary>
	public static partial class BinarySearchers
	{
		/// <summary>
		/// Find range of items equal to searched one.
		/// <paramref name="list"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="list">Sorted list</param>
		/// <param name="range">Range in <paramref name="list"/> to search in</param>
		/// <param name="comparison">Method should determine whether the passed item is less (-1), equal (0) or greater (1) than searching one (item.CompareTo(SearchingItem))</param>
		/// <returns>Range of items in <paramref name="list"/> equals to serched one</returns>
		public static Range BinaryFindEqual<T>(this IReadOnlyList<T> list, Range range, Func<T, int> comparison)
		{
			var greaterOrEqual = BinaryFindGreaterOrEqual(list, range, comparison);
			return BinaryFindLessOrEqual(list, greaterOrEqual, comparison);
		}

		/// <summary>
		/// Find range of items less or equal to searched one.
		/// <paramref name="list"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="list">Sorted list</param>
		/// <param name="range">Range in <paramref name="list"/> to search in</param>
		/// <param name="comparison">Method should determine whether the passed item is less (-1), equal (0) or greater (1) than searching one (item.CompareTo(SearchingItem))</param>
		/// <returns>Range of items in <paramref name="list"/> less or equals to serched one</returns>
		public static Range BinaryFindLessOrEqual<T>(this IReadOnlyList<T> list, Range range, Func<T, int> comparison)
		{
			int left = range.Start.GetOffset(list.Count), last = range.End.GetOffset(list.Count)-1, right = last, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(list[current]);
				//Check comparison result
				if(0<cmp)//The searched item is located in the left part of the range
					right=current-1;
				else//The searched item was found. But we want the last one - so check if the next one also meets the conditions
					if(current>=last || 0<(cmp=comparison(list[current+1])))//There is no next item or is greater than the searched one, so current item is the last matching one
				{
					//The last searched item was found
					return new Range(range.Start, current+1);
				}
				else//The next item also matches, so it is not the last one that meets the conditions, so the searched element is in the right part of the range
					left=current+1;
			}

			return new Range();
		}

		/// <summary>
		/// Find range of items less than searched one.
		/// <paramref name="list"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="list">Sorted list</param>
		/// <param name="range">Range in <paramref name="list"/> to search in</param>
		/// <param name="comparison">Method should determine whether the passed item is less (-1), equal (0) or greater (1) than searching one (item.CompareTo(SearchingItem))</param>
		/// <returns>Range of items in <paramref name="list"/> less than serched one</returns>
		public static Range BinaryFindLess<T>(this IReadOnlyList<T> list, Range range, Func<T, int> comparison)
		{
			int left = range.Start.GetOffset(list.Count), last = range.End.GetOffset(list.Count)-1, right = last, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(list[current]);
				//Check comparison result
				if(0<=cmp)//The searched item is located in the left part of the range
					right=current-1;
				else//The searched item was found. But we want the last one - so check if the next one also meets the conditions
					if(current>=last || 0<=(cmp=comparison(list[current+1])))//There is no next item or is greater or equal to the searched one, so current item is the last matching one
				{
					//The last searched item was found
					return new Range(range.Start, current+1);
				}
				else//The next item also matches, so it is not the last one that meets the conditions, so the searched element is in the right part of the range
					left=current+1;
			}

			return new Range();
		}

		/// <summary>
		/// Find range of items greater or equal to searched one.
		/// <paramref name="list"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="list">Sorted list</param>
		/// <param name="range">Range in <paramref name="list"/> to search in</param>
		/// <param name="comparison">Method should determine whether the passed item is less (-1), equal (0) or greater (1) than searching one (item.CompareTo(SearchingItem))</param>
		/// <returns>Range of items in <paramref name="list"/> greater or equals to serched one</returns>
		public static Range BinaryFindGreaterOrEqual<T>(this IReadOnlyList<T> list, Range range, Func<T, int> comparison)
		{
			int first = range.Start.GetOffset(list.Count), left = first, right = range.End.GetOffset(list.Count)-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(list[current]);
				//Check comparison result
				if(0>cmp)//The searched item is located in the right part of the range
					left=current+1;
				else//The searched item was found. But we want the first one - so check if the previous one also meets the conditions
					if(current<=first || 0>(cmp=comparison(list[current-1])))//There is no previous item or is less than the searched one, so current item is the first matching one
				{
					//The first searched item was found
					return new Range(current, range.End);
				}
				else//The previous item also matches, so it is not the first one that meets the conditions, so the searched element is in the left part of the range
					right=current-1;
			}

			return new Range();
		}

		/// <summary>
		/// Find range of items greater than searched one.
		/// <paramref name="list"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="list">Sorted list</param>
		/// <param name="range">Range in <paramref name="list"/> to search in</param>
		/// <param name="comparison">Method should determine whether the passed item is less (-1), equal (0) or greater (1) than searching one (item.CompareTo(SearchingItem))</param>
		/// <returns>Range of items in <paramref name="list"/> greater than serched one</returns>
		public static Range BinaryFindGreater<T>(this IReadOnlyList<T> list, Range range, Func<T, int> comparison)
		{
			int first = range.Start.GetOffset(list.Count), left = first, right = range.End.GetOffset(list.Count)-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(list[current]);
				//Check comparison result
				if(0>=cmp)//The searched item is located in the right part of the range
					left=current+1;
				else//The searched item was found. But we want the first one - so check if the previous one also meets the conditions
					if(current<=first || 0>=(cmp=comparison(list[current-1])))//There is no previous item or is less or equal to the searched one, so current item is the first matching one
				{
					//The first searched item was found
					return new Range(current, range.End);
				}
				else//The previous item also matches, so it is not the first one that meets the conditions, so the searched element is in the left part of the range
					right=current-1;
			}

			return new Range();
		}
	}
}