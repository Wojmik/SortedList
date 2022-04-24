using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WojciechMikołajewicz.AdvancedListDotNetCoreMSUnitTest
{
	public class SortedListItemComparer : Comparer<SortedListItem>
	{
		protected int Depth { get; }

		public SortedListItemComparer(int depth)
		{
			if(depth<=0 || depth>SortedReadOnlyListSampleSourceArray.AllKeysDataList.Count)
				throw new ArgumentOutOfRangeException(nameof(depth), depth, $"{nameof(depth)} has to be greather than 0 and less or equal to {SortedReadOnlyListSampleSourceArray.AllKeysDataList.Count}");

			this.Depth=depth;
		}

		public override int Compare(SortedListItem? x, SortedListItem? y)
		{
			int cmp = 0, i;

			for(i=0; i<this.Depth; i++)
			{
				cmp = SortedReadOnlyListSampleSourceArray.AllKeysDataList[i].Compare(x, y);
				if (cmp!=0)
					break;
			}

			return cmp;
		}
	}
}