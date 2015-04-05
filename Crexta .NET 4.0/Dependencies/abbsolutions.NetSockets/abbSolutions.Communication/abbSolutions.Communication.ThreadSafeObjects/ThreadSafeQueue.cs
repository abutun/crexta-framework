using System;
using System.Collections.Generic;
using System.ComponentModel;
using abbSolutions.Communication.ThreadSafeObjects;
using abbSolutions.Communication.HyperTypeDescriptor;

namespace abbSolutions.Communication.ThreadSafeObjects
{
    /// <summary>
    /// A simple queue that avoids using lock().  Fast/efficient to dequeue/enqueue from multiple threads
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [TypeDescriptionProvider(typeof(HyperTypeDescriptionProvider)), Serializable]
    public class ThreadSafeQueue<TListType> : Lockable, IMultipleItems<TListType>, ISupportsCount, ISupportsEnqueueDequeue<TListType> where TListType : class
    {
        public Queue<TListType> _queue = new Queue<TListType>();
        public int _count;

        public List<TListType> AllItems { get { return new List<TListType>(ArrayOfItems); } }
        public int Count { get { return _count; } }

        public void Enqueue(TListType item)
        {
            // We need to be sure that no other threads simultaneously modify the shared _queue
            // object during our enqueue operation
            AquireLock();
            {
                _queue.Enqueue(item);
                _count++;
            }
            ReleaseLock();
        }

        public void EnqueueMultiple(List<TListType> items)
        {
            AquireLock();
            {
                foreach (TListType item in items)
                    _queue.Enqueue(item);

                _count += items.Count;
            }
            ReleaseLock();
        }

        public int DequeueMultiple(List<TListType> items, int maxItems)
        {
            int dequeued = 0;

            AquireLock();
            {
                while (_count > 0 && dequeued < maxItems)
                {
                    TListType item = _queue.Dequeue();
                    items.Add(item);
                    _count--;
                    dequeued++;
                }
            }
            ReleaseLock();

            return dequeued;
        }

        public int DequeueMultiple(TListType[] items, int maxItems)
        {
            int dequeued = 0;

            AquireLock();
            {
                while (_count > 0 && dequeued < maxItems)
                {
                    TListType item = _queue.Dequeue();
                    items[dequeued] = item;
                    dequeued++;
                    _count--;
                }
            }
            ReleaseLock();

            return dequeued;
        }


        public bool Dequeue(out TListType item)
        {
            item = null;

            // We need to be sure that no other threads simultaneously modify the shared _queue
            // object during our dequeue operation
            AquireLock();
            {
                if (_count > 0)
                {
                    item = _queue.Dequeue();
                    _count--;
                }
            }
            ReleaseLock();

            return (item != null);
        }

        public bool IsInList(TListType item)
        {
            bool found;

            AquireLock();
            {
                found = _queue.Contains(item);
            }
            ReleaseLock();

            return found;
        }

        public TListType[] ArrayOfItems
        {
            get
            {
                TListType[] list;

                AquireLock();
                {
                    list = _queue.ToArray();
                }
                ReleaseLock();

                return list;
            }
        }

        public virtual void Clear()
        {
            AquireLock();
            {
                _queue.Clear();
                _count = 0;
            }
            ReleaseLock();
        }
    }
}