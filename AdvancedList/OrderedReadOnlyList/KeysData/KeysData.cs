using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	/// <summary>
	/// Keys data
	/// </summary>
	/// <typeparam name="T">Type of items</typeparam>
	public abstract class KeysData<T> : IComparer<T>
	{
		/// <summary>
		/// Compare items
		/// </summary>
		/// <param name="x">Item to compare</param>
		/// <param name="y">Item to compare</param>
		/// <returns>Compare result: -1 if <paramref name="x"/> is less than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/>, 0 if <paramref name="x"/> is equal to <paramref name="y"/></returns>
		public abstract int Compare(T x, T y);

		/// <summary>
		/// Create array from <paramref name="collection"/>, sorted by keys defined in <paramref name="keysData"/>
		/// </summary>
		/// <param name="collection">Collection base on which array is created</param>
		/// <param name="keysData">Keys definition</param>
		/// <returns>Sorted array</returns>
		protected static T[] CreateSortedArray(IEnumerable<T> collection, KeysData<T> keysData)
		{
			const int startChunk = 256;
			bool shouldSort = false;
			T[] array;

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

			return array;
		}
	}
}