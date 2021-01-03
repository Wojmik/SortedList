using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.SortedList.KeysData;

namespace WojciechMikołajewicz.SortedList
{
	/// <summary>
	/// Sorted read only list with binary search based on items compare (not items equality)
	/// </summary>
	/// <typeparam name="T">Items type</typeparam>
	/// <typeparam name="TKeysData">Sorting keys type</typeparam>
	public abstract class SortedReadOnlyListBase<T, TKeysData> : IReadOnlyList<T>
		where TKeysData : IComparer<T>
	{
		/// <summary>
		/// Internal sorted array
		/// </summary>
		protected readonly T[] _Array;

		/// <summary>
		/// Sorting keys
		/// </summary>
		public TKeysData KeysData { get; }

		/// <summary>
		/// Number of items
		/// </summary>
		public int Count { get => _Array.Length; }

		/// <summary>
		/// Returns an item of <paramref name="index"/>
		/// </summary>
		/// <param name="index">Index of the item to return</param>
		/// <returns>Item of specified <paramref name="index"/></returns>
		public T this[int index] { get => _Array[index]; }

		/// <summary>
		/// Constructor
		/// </summary>
		private SortedReadOnlyListBase()
		{ }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="collection">Collection base on which array is created</param>
		/// <param name="keysData">Keys data</param>
		protected SortedReadOnlyListBase(IEnumerable<T> collection, TKeysData keysData)
		{
			const int startChunk = 256;
			bool shouldSort = false;
			T[] array;

			this.KeysData = keysData;

			if(collection is IReadOnlyCollection<T> roColl)
			{
				array=new T[roColl.Count];

				using(var enumerator = collection.GetEnumerator())
				{
					if(enumerator.MoveNext())
					{
						int i = 0;
						array[i]=enumerator.Current;

						while(enumerator.MoveNext())
						{
							if(!shouldSort)
								shouldSort=0<keysData.Compare(array[i], enumerator.Current);
							i++;
							array[i]=enumerator.Current;
						}
					}
				}
			}
			else
			{
				LinkedList<T[]> chunksList = new LinkedList<T[]>();

				using(var enumerator = collection.GetEnumerator())
				{
					if(enumerator.MoveNext())
					{
						T[] currentChunk = new T[startChunk];
						int i = 0;

						chunksList.AddLast(currentChunk);
						currentChunk[i]=enumerator.Current;

						while(enumerator.MoveNext())
						{
							if(!shouldSort)
								shouldSort=0<keysData.Compare(currentChunk[i], enumerator.Current);
							i++;
							if(currentChunk.Length<=i)
							{
								//New chunk required
								currentChunk=new T[checked(currentChunk.Length*2)];
								i=0;
								chunksList.AddLast(currentChunk);
							}
							currentChunk[i]=enumerator.Current;
						}
						i++;

						//Create array of proper size and copy items to it
						array=new T[startChunk*((int)Math.Pow(2, chunksList.Count-1)-1)+i];

						//Copy full nodes
						var node = chunksList.First;
						int j = 0;
						while(!object.ReferenceEquals(node, chunksList.Last))
						{
							Array.Copy(node.Value, 0, array, j, node.Value.Length);
							j+=node.Value.Length;
							node=node.Next;
						}
						//Copy last, incomplete node
						Array.Copy(node.Value, 0, array, j, i);
					}
					else
						array=new T[0];
				}
			}

			//Sort array if required
			if(shouldSort)
				Array.Sort(array, keysData);

			this._Array=array;
		}

		/// <summary>
		/// Gets a read-only reference to the element at the specified <paramref name="index"/> in the read-only list
		/// </summary>
		/// <param name="index">The zero-based index of the element to get a reference to</param>
		/// <returns>A read-only reference to the element at the specified <paramref name="index"/> in the read-only list</returns>
		public ref readonly T ItemRef(int index)
		{
			return ref _Array[index];
		}

		/// <summary>
		/// Get ReadOnlyMemory from internal array
		/// </summary>
		/// <returns>ReadOnlyMemory from internal array</returns>
		public ReadOnlyMemory<T> AsMemory()
		{
			return new ReadOnlyMemory<T>(this._Array);
		}

		/// <summary>
		/// Get enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)_Array).GetEnumerator();
		}

		/// <summary>
		/// Get enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return _Array.GetEnumerator();
		}
	}
}