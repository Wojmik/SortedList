using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList;

namespace WojciechMikołajewicz.AdvancedList
{
	//public abstract class KeyData<T> : IComparer<T>
	//{
	//	public static KeyData<T> Create<K>(Func<T, K> getMember, Comparison<K> comparison = null)
	//	{
	//		return new KeyData<T, K>(getMember: getMember, comparison: comparison);
	//	}

	//	public abstract int Compare(T x, T y);

	//	public abstract int Compare(T x, object value);
	//}

	//public class KeyData<T, K> : KeyData<T>
	//{
	//	public static implicit operator KeyData<T, K>(Func<T, K> func) => new KeyData<T, K>(func);

	//	public static implicit operator KeyDataStruct<T, K>(KeyData<T, K> keyData) => new KeyDataStruct<T, K>(getMember: keyData.GetMember, comparison: keyData.Comparison);

	//	public Func<T, K> GetMember { get; }

	//	public Comparison<K> Comparison { get; }

	//	public KeyData(Func<T, K> getMember, Comparison<K> comparison = null)
	//	{
	//		this.GetMember=getMember;
	//		this.Comparison=comparison??Comparer<K>.Default.Compare;
	//	}

	//	public override int Compare(T x, T y)
	//	{
	//		return this.Comparison(this.GetMember(x), this.GetMember(y));
	//	}

	//	public int Compare(T x, K value)
	//	{
	//		return this.Comparison(this.GetMember(x), value);
	//	}

	//	public override int Compare(T x, object value)
	//	{
	//		return this.Comparison(this.GetMember(x), (K)value);
	//	}
	//}
}