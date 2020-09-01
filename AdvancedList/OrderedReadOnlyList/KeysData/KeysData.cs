using System;
using System.Collections.Generic;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.KeysData
{
	public abstract class KeysData<T> : IComparer<T>
	{
		public abstract int Compare(T x, T y);

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