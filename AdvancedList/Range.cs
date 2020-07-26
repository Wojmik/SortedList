using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
#if NETSTANDARD2_0
	public readonly struct Range
	{
		public Index Start { get; }

		public Index End { get; }

		public Range(Index start, Index end)
		{
			this.Start=start;
			this.End=end;
		}

		public void Deconstruct(out Index start, out Index end)
		{
			start=this.Start;
			end=this.End;
		}

		(int Offset, int Length) GetOffsetAndLength(int length)
		{
			int startOffset = this.Start.GetOffset(length);
			return (Offset: startOffset, Length: this.End.GetOffset(length)-startOffset);
		}
	}
#endif
}