using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
#if NETSTANDARD2_0
	public readonly struct Index
	{
		public static implicit operator Index(int value) => new Index(value);

		public int Value { get; }

		public bool IsFromEnd { get; }

		public Index(int value, bool fromEnd = false)
		{
			this.Value=value;
			this.IsFromEnd=fromEnd;
		}

		public void Deconstruct(out int value, out bool fromEnd)
		{
			value=this.Value;
			fromEnd=this.IsFromEnd;
		}

		public int GetOffset(int length)
		{
			return this.IsFromEnd ? length-this.Value : this.Value;
		}
	}
#endif
}