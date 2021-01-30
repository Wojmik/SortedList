using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
#if NETSTANDARD2_0
	/// <summary>
	/// Index
	/// </summary>
	public readonly struct Index
	{
		/// <summary>
		/// Implicit operator
		/// </summary>
		/// <param name="value">Index</param>
		public static implicit operator Index(int value) => new Index(value);

		/// <summary>
		/// Index value
		/// </summary>
		public int Value { get; }

		/// <summary>
		/// Is from end
		/// </summary>
		public bool IsFromEnd { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="value">Index value</param>
		/// <param name="fromEnd">Is from end</param>
		public Index(int value, bool fromEnd = false)
		{
			this.Value=value;
			this.IsFromEnd=fromEnd;
		}

		/// <summary>
		/// Deconstructor
		/// </summary>
		/// <param name="value">Index value</param>
		/// <param name="fromEnd">Is from end</param>
		public void Deconstruct(out int value, out bool fromEnd)
		{
			value=this.Value;
			fromEnd=this.IsFromEnd;
		}

		/// <summary>
		/// Gets offset
		/// </summary>
		/// <param name="length">Length of the list</param>
		/// <returns>Offset</returns>
		public int GetOffset(int length)
		{
			return this.IsFromEnd ? length-this.Value : this.Value;
		}
	}
#endif
}