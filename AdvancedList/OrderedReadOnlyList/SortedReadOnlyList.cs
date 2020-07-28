using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WojciechMikołajewicz.AdvancedList.OrderedReadOnlyList.Internal;

namespace WojciechMikołajewicz.AdvancedList
{
	public abstract class SortedReadOnlyList<T> : IReadOnlyList<T>
	{
		internal readonly protected T[] _Array;

		protected abstract int KeysCount { get; }

		public IReadOnlyList<KeyData<T>> KeysData { get; }

		public T this[int index] { get => this._Array[index]; }

		public int Count { get => this._Array.Length; }

		protected SortedReadOnlyList(IEnumerable<T> collection, IEnumerable<KeyData<T>> keysData)
		{
			const int startChunk = 256;
			bool shouldSort = false;
			ItemComparer<T> itemComparer = new ItemComparer<T>(keysData);

			this.KeysData=keysData.ToArray();

			if(this.KeysData.Count!=KeysCount)
				throw new ArgumentException($"{nameof(keysData)} argument should be {KeysCount} length", nameof(keysData));

			if(collection is IReadOnlyCollection<T> roColl)
			{
				this._Array=new T[roColl.Count];

				using(var enumerator = collection.GetEnumerator())
				{
					if(enumerator.MoveNext())
					{
						int i = 0;
						this._Array[i]=enumerator.Current;

						while(enumerator.MoveNext())
						{
							if(!shouldSort)
								shouldSort=0<itemComparer.Compare(this._Array[i], enumerator.Current);
							i++;
							this._Array[i]=enumerator.Current;
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
								shouldSort=0<itemComparer.Compare(currentChunk[i], enumerator.Current);
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

						//Create array of proper size and copy items to it
						this._Array=new T[-startChunk*(1-(int)Math.Pow(2, chunksList.Count-1))+i];

						//Copy full nodes
						var node = chunksList.First;
						int j=0;
						while(!object.ReferenceEquals(node, chunksList.Last))
						{
							Array.Copy(node.Value, 0, this._Array, j, node.Value.Length);
							j+=node.Value.Length;
							node=node.Next;
						}
						//Copy last, incomplete node
						Array.Copy(node.Value, 0, this._Array, j, i);
					}
					else
						this._Array=new T[0];
				}
			}

			//Sort array if required
			if(shouldSort)
				Array.Sort(this._Array, itemComparer);
		}

		public ReadOnlyMemory<T> AsMemory()
		{
			return new ReadOnlyMemory<T>(this._Array);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)this._Array).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}