using System;
using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;
using abbSolutions.Communication.HyperTypeDescriptor;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace abbSolutions.Communication.ThreadSafeObjects
{
	/// <summary>
	/// Thread-safe lookup allows multiple threads to look up items by key, add items,
	/// and remove items in a thread-safe manner
	/// </summary>
	/// <typeparam name="TListType"></typeparam>
	/// <typeparam name="TIndex"></typeparam>
	[TypeDescriptionProvider(typeof(HyperTypeDescriptionProvider)), Serializable]
	public class ThreadSafeLookup<TIndex, TListType> : Lockable, IMultipleItems<TListType>,
	   ISupportsCount, ISupportsAddRemoveClear<TIndex, TListType> where TListType : class
	{
		public Dictionary<TIndex, TListType> Lookup = new Dictionary<TIndex, TListType>();
		public TListType[] ArrayOfItems { get { return AllItems.ToArray(); } }
		public int Count { get { return Lookup.Count; } }

		public bool ContainsKey(TIndex key) { return Lookup.ContainsKey(key); }
		public bool TryGetValue(TIndex key, out TListType items) { return Lookup.TryGetValue(key, out items); }

		public List<TListType> AllItems
		{
			get
			{
				List<TListType> items = new List<TListType>(Lookup.Count);

				AquireLock();
				{
					foreach (KeyValuePair<TIndex, TListType> kvp in Lookup)
						items.Add(kvp.Value);
				}
				ReleaseLock();

				return items;
			}
		}

		public bool Add(TIndex key, TListType item)
		{
			bool found = true;

			AquireLock();
			{
				if (!Lookup.ContainsKey(key))
				{
					Lookup.Add(key, item);
					found = false;
				}
			}
			ReleaseLock();

			return found;
		}

		public void AddOrSet(TIndex key, TListType item)
		{
			if (Lookup.ContainsKey(key))
			{
				Lookup[key] = item;
			}
			else
			{
				Add(key, item);
			}
		}

		public TListType this[TIndex key]
		{
			get
			{
				TListType item;

				// Not totally safe for lookups that frequently add/remove items.
				// For thread safety, surround the following line with AquireLock(); / ReleaseLock();
				if (!Lookup.TryGetValue(key, out item)) item = default(TListType);

				return item;
			}
		}

		public bool Remove(TIndex key, TListType item)
		{
			bool removed = false;

			if (!Lookup.ContainsKey(key))
				return false;

			AquireLock();
			{
				if (Lookup.ContainsKey(key))
				{
					Lookup.Remove(key);
					removed = true;
				}
			}
			ReleaseLock();

			return removed;
		}

		public bool Remove(TIndex key)
		{
			bool removed = false;

			if (!Lookup.ContainsKey(key))
				return false;

			AquireLock();
			{
				if (Lookup.ContainsKey(key))
				{
					Lookup.Remove(key);
					removed = true;
				}
			}
			ReleaseLock();

			return removed;
		}

		public void Clear()
		{
			AquireLock();
			{
				Lookup.Clear();
			}
			ReleaseLock();
		}
	}

	/// <summary>
	/// Thread-safe lookup allows multiple threads to look up items by key, add items,
	/// and remove items in a thread-safe manner
	/// </summary>
	/// <typeparam name="TListType"></typeparam>
	/// <typeparam name="TIndex"></typeparam>
	[TypeDescriptionProvider(typeof(HyperTypeDescriptionProvider)), Serializable]
	public class ThreadSafeLookupOnAutoKey<TIndex, TListType> : ThreadSafeLookup<TIndex, TListType>, IMultipleItems<TListType>,
	   ISupportsCount, ISupportsAddRemoveClear<TIndex, TListType> where TListType : class, IKeyedOnProperty<TIndex>
	{
		public bool Add(TListType item)
		{
			TIndex key = item.Key;
			return Add(key, item);
		}

		public void AddOrSet(TListType item)
		{
			TIndex key = item.Key;
			AddOrSet(key, item);
		}

		public bool Remove(TListType item)
		{
			TIndex key = item.Key;
			return Remove(item.Key);
		}
	}

	/// <summary>
	/// Thread-safe lookup allows multiple threads to look up items by key, add items,
	/// and remove items in a thread-safe manner
	/// </summary>
	/// <typeparam name="TListType"></typeparam>
	/// <typeparam name="TIndex"></typeparam>
	[TypeDescriptionProvider(typeof(HyperTypeDescriptionProvider)), Serializable]
	public class ThreadSafeLookupNonRef<TIndex, TListType> : Lockable, IMultipleItems<TListType>,
	   ISupportsCount
	{
		public Dictionary<TIndex, TListType> Lookup = new Dictionary<TIndex, TListType>();
		public TListType[] ArrayOfItems { get { return AllItems.ToArray(); } }
		public int Count { get { return Lookup.Count; } }

		public bool ContainsKey(TIndex key) { return Lookup.ContainsKey(key); }
		public bool TryGetValue(TIndex key, out TListType items) { return Lookup.TryGetValue(key, out items); }

		public List<TListType> AllItems
		{
			get
			{
				List<TListType> items = new List<TListType>(Lookup.Count);

				AquireLock();
				{
					foreach (KeyValuePair<TIndex, TListType> kvp in Lookup)
						items.Add(kvp.Value);
				}
				ReleaseLock();

				return items;
			}
		}

		public bool Add(TIndex key, TListType item)
		{
			bool found = true;

			AquireLock();
			{
				if (!Lookup.ContainsKey(key))
				{
					Lookup.Add(key, item);
					found = false;
				}
			}
			ReleaseLock();

			return found;
		}

		public void AddOrSet(TIndex key, TListType item)
		{
			if (Lookup.ContainsKey(key))
			{
				Lookup[key] = item;
			}
			else
			{
				Add(key, item);
			}
		}

		public TListType this[TIndex key]
		{
			get
			{
				TListType item;

				// Not totally safe for lookups that frequently add/remove items.
				// For thread safety, surround the following line with AquireLock(); / ReleaseLock();
				if (!Lookup.TryGetValue(key, out item)) item = default(TListType);

				return item;
			}
		}

		public bool Remove(TIndex key, TListType item)
		{
			bool removed = false;

			if (!Lookup.ContainsKey(key))
				return false;

			AquireLock();
			{
				if (Lookup.ContainsKey(key))
				{
					Lookup.Remove(key);
					removed = true;
				}
			}
			ReleaseLock();

			return removed;
		}

		public bool Remove(TIndex key)
		{
			bool removed = false;

			if (!Lookup.ContainsKey(key))
				return false;

			AquireLock();
			{
				if (Lookup.ContainsKey(key))
				{
					Lookup.Remove(key);
					removed = true;
				}
			}
			ReleaseLock();

			return removed;
		}

		public void Clear()
		{
			AquireLock();
			{
				Lookup.Clear();
			}
			ReleaseLock();
		}
	}
}