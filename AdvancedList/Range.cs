using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
#if NETSTANDARD2_0
	/// <summary>
	/// Range
	/// </summary>
	public readonly struct Range
	{
		/// <summary>
		/// Returns range covering whole collection
		/// </summary>
		public static Range All { get => new Range(0, new Index(0, true)); }

		/// <summary>
		/// Start index
		/// </summary>
		public Index Start { get; }

		/// <summary>
		/// End index
		/// </summary>
		public Index End { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="start">Start index</param>
		/// <param name="end">End index</param>
		public Range(Index start, Index end)
		{
			this.Start=start;
			this.End=end;
		}

		/// <summary>
		/// Deconstructor
		/// </summary>
		/// <param name="start">Start index</param>
		/// <param name="end">End index</param>
		public void Deconstruct(out Index start, out Index end)
		{
			start=this.Start;
			end=this.End;
		}

		/// <summary>
		/// Get offser and length of the range
		/// </summary>
		/// <param name="length">Length of the list</param>
		/// <returns>Offset and length of the range</returns>
		public (int Offset, int Length) GetOffsetAndLength(int length)
		{
			int startOffset = this.Start.GetOffset(length);
			return (Offset: startOffset, Length: this.End.GetOffset(length)-startOffset);
		}
	}
#endif
}