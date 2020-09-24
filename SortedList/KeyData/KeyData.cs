using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.SortedList
{
	/// <summary>
	/// Key data
	/// </summary>
	/// <typeparam name="T">Type of item</typeparam>
	/// <typeparam name="K">Type of key</typeparam>
	public readonly struct KeyData<T, K> : IKeyData<T>
	{
		/// <summary>
		/// Gets key member of item
		/// </summary>
		public Func<T, K> GetMember { get; }

		/// <summary>
		/// Key comparison
		/// </summary>
		public Comparison<K> Comparison { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="getMember">Gets key member of item</param>
		/// <param name="comparison">Key comparison</param>
		public KeyData(Func<T, K> getMember, Comparison<K> comparison)
		{
			this.GetMember = getMember;
			this.Comparison = comparison;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="getMember">Gets key member of item</param>
		/// <param name="comparer">Key comparer</param>
		public KeyData(Func<T, K> getMember, Comparer<K> comparer)
		{
			this.GetMember = getMember;
			this.Comparison = comparer.Compare;
		}

		/// <summary>
		/// Constructor with default key comparer
		/// </summary>
		/// <param name="getMember">Gets key member of item</param>
		public KeyData(Func<T, K> getMember)
		{
			this.GetMember = getMember;
			this.Comparison = Comparer<K>.Default.Compare;
		}

		/// <summary>
		/// Deconstruct
		/// </summary>
		/// <param name="getMember">Gets key member of item</param>
		/// <param name="comparison">Key comparison</param>
		public void Deconstruct(out Func<T, K> getMember, out Comparison<K> comparison)
		{
			getMember=this.GetMember;
			comparison=this.Comparison;
		}

		/// <summary>
		/// Compare item's keys
		/// </summary>
		/// <param name="x">Item to compare its key</param>
		/// <param name="y">Item to compare its key</param>
		/// <returns>Compare result: -1 if key of <paramref name="x"/> is less than key of <paramref name="y"/>, 1 if key of <paramref name="x"/> is greater than key of <paramref name="y"/>, 0 if key of <paramref name="x"/> is equal to key of <paramref name="y"/></returns>
		public int Compare(T x, T y)
		{
			return this.Comparison(this.GetMember(x), this.GetMember(y));
		}

		/// <summary>
		/// Compare item's key to <paramref name="value"/>
		/// </summary>
		/// <param name="x">Item to compare its key with <paramref name="value"/></param>
		/// <param name="value">Key value to compare</param>
		/// <returns>Compare result: -1 if key of <paramref name="x"/> is less than <paramref name="value"/>, 1 if key of <paramref name="x"/> is greater than <paramref name="value"/>, 0 if key of <paramref name="x"/> is equal to <paramref name="value"/></returns>
		public int Compare(T x, K value)
		{
			return this.Comparison(this.GetMember(x), value);
		}

		/// <summary>
		/// Compare item's key to <paramref name="value"/>
		/// </summary>
		/// <param name="x">Item to compare its key with <paramref name="value"/></param>
		/// <param name="value">Key value to compare</param>
		/// <returns>Compare result: -1 if key of <paramref name="x"/> is less than <paramref name="value"/>, 1 if key of <paramref name="x"/> is greater than <paramref name="value"/>, 0 if key of <paramref name="x"/> is equal to <paramref name="value"/></returns>
		int IKeyData<T>.Compare(T x, object value)
		{
			return this.Comparison(this.GetMember(x), (K)value);
		}
	}
}