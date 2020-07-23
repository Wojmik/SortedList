using System;
using System.Collections.Generic;
using System.Text;

namespace WojciechMikołajewicz.AdvancedList.Internal
{
	readonly struct KeyData<T, K>
	{
		public static implicit operator KeyData<T, K>(AdvancedList.KeyData<T, K> kd) => new KeyData<T, K>(getMember: kd.GetMember, comparison: kd.Comparison);

		public readonly Func<T, K> GetMember;

		public readonly Comparison<K> Comparison;

		public KeyData(Func<T, K> getMember, Comparison<K> comparison)
		{
			this.GetMember=getMember;
			this.Comparison=comparison;
		}
	}
}