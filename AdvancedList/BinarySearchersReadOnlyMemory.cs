using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList
{
	public static partial class BinarySearchers
	{
		/// <summary>
		/// Return memory of items equal to searched one.
		/// <paramref name="memory"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="memory">Sorted memory</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Memory of items in <paramref name="memory"/> equals to serched one</returns>
		public static ReadOnlyMemory<T> BinaryFindEqual<T>(this in ReadOnlyMemory<T> memory, Func<T, int> comparison)
		{
			var greaterOrEqual = BinaryFindGreaterOrEqual(memory, comparison);
			return BinaryFindLessOrEqual(greaterOrEqual, comparison);
		}

		/// <summary>
		/// Return memory of items less or equal to searched one.
		/// <paramref name="memory"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="memory">Sorted memory</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Memory of items in <paramref name="memory"/> less or equals to serched one</returns>
		public static ReadOnlyMemory<T> BinaryFindLessOrEqual<T>(this in ReadOnlyMemory<T> memory, Func<T, int> comparison)
		{
			int left = 0, right = memory.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(memory.Span[current]);
				//Check comparison result
				if(0>cmp)//The searched item is located in the left part of the range
					right=current-1;
				else//The searched item was found. But we want the last one - so check if the next one also meets the conditions
					if(current+1>=memory.Length || 0>(cmp=comparison(memory.Span[current+1])))//There is no next item or is greater than the searched one, so current item is the last matching one
				{
					//The last searched item was found
					return memory.Slice(0, current+1);
				}
				else//The next item also matches, so it is not the last one that meets the conditions, so the searched element is in the right part of the range
					left=current+1;
			}

			return ReadOnlyMemory<T>.Empty;
		}

		/// <summary>
		/// Return memory of items less than searched one.
		/// <paramref name="memory"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="memory">Sorted memory</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Memory of items in <paramref name="memory"/> less than serched one</returns>
		public static ReadOnlyMemory<T> BinaryFindLess<T>(this in ReadOnlyMemory<T> memory, Func<T, int> comparison)
		{
			int left = 0, right = memory.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(memory.Span[current]);
				//Check comparison result
				if(0>=cmp)//The searched item is located in the left part of the range
					right=current-1;
				else//The searched item was found. But we want the last one - so check if the next one also meets the conditions
					if(current+1>=memory.Length || 0>=(cmp=comparison(memory.Span[current+1])))//There is no next item or is greater or equal to the searched one, so current item is the last matching one
				{
					//The last searched item was found
					return memory.Slice(0, current+1);
				}
				else//The next item also matches, so it is not the last one that meets the conditions, so the searched element is in the right part of the range
					left=current+1;
			}

			return ReadOnlyMemory<T>.Empty;
		}

		/// <summary>
		/// Return memory of items greater or equal to searched one.
		/// <paramref name="memory"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="memory">Sorted memory</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Memory of items in <paramref name="memory"/> greater or equals to serched one</returns>
		public static ReadOnlyMemory<T> BinaryFindGreaterOrEqual<T>(this in ReadOnlyMemory<T> memory, Func<T, int> comparison)
		{
			int left = 0, right = memory.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(memory.Span[current]);
				//Check comparison result
				if(0<cmp)//The searched item is located in the right part of the range
					left=current+1;
				else//The searched item was found. But we want the first one - so check if the previous one also meets the conditions
					if(current<=0 || 0<(cmp=comparison(memory.Span[current-1])))//There is no previous item or is less than the searched one, so current item is the first matching one
				{
					//The first searched item was found
					return memory.Slice(current);
				}
				else//The previous item also matches, so it is not the first one that meets the conditions, so the searched element is in the left part of the range
					right=current-1;
			}

			return ReadOnlyMemory<T>.Empty;
		}

		/// <summary>
		/// Return memory of items greater than searched one.
		/// <paramref name="memory"/> has to be sorted and <paramref name="comparison"/> method has to use same sorting.
		/// </summary>
		/// <typeparam name="T">Type of items</typeparam>
		/// <param name="memory">Sorted memory</param>
		/// <param name="comparison">Method should determine whether the searching item is less (-1), equal (0) or greater (1) than passed one (SearchingItem.CompareTo(item))</param>
		/// <returns>Memory of items in <paramref name="memory"/> greater than serched one</returns>
		public static ReadOnlyMemory<T> BinaryFindGreater<T>(this in ReadOnlyMemory<T> memory, Func<T, int> comparison)
		{
			int left = 0, right = memory.Length-1, current, cmp;

			while(left<=right)
			{
				//Take middle item
				current=(left+right)>>1;
				//Compare current item with searched one
				cmp=comparison(memory.Span[current]);
				//Check comparison result
				if(0<=cmp)//The searched item is located in the right part of the range
					left=current+1;
				else//The searched item was found. But we want the first one - so check if the previous one also meets the conditions
					if(current<=0 || 0<=(cmp=comparison(memory.Span[current-1])))//There is no previous item or is less or equal to the searched one, so current item is the first matching one
				{
					//The first searched item was found
					return memory.Slice(current);
				}
				else//The previous item also matches, so it is not the first one that meets the conditions, so the searched element is in the left part of the range
					right=current-1;
			}

			return ReadOnlyMemory<T>.Empty;
		}
	}
}