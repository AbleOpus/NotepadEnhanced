using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NotepadEnhanced
{
    /// <summary>
    /// Represents a generic recent items list. Which discards data
    /// at the beginning of the list when the list is overflown.
    /// </summary>
    [Serializable]
    public class RecentCollection<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();
        /// <summary>
        /// Gets or sets the items for this list. The capacity will be 
        /// automatically adjusted to the size of the set array.
        /// </summary>
        public T[] Items
        {
            get { return items.ToArray(); }
            set
            {
                Capacity = value.Length;
                items = new List<T>(value);
            }
        }

        // Indexer for this collection type
        public T this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }

        private int capacity = 10;
        /// <summary>
        /// Gets or sets the number of elements this instance can contain.
        /// </summary>
        public int Capacity
        {
            get { return capacity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), value, "Value cannot be less than or equal to 0");
                }

                capacity = value;

                while (items.Count > capacity)
                    items.RemoveAt(0);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecentCollection&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="capacity">The maximum amount of items the collection can hold.</param>
        public RecentCollection(int capacity)
        {
            Capacity = capacity;
        } 

        /// <summary>
        /// Pushes a range of items to the end of the list.
        /// </summary>
        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                if (this.items.Count + 1 > capacity)
                    this.items.RemoveAt(0);

                this.items.Add(item);
            }
        }

        /// <summary>
        /// Removes all items in the list.
        /// </summary>
        public void Clear()
        {
            items.Clear();
        }

        public override string ToString()
        {
            var SB = new StringBuilder();

            foreach (var item in items)
                SB.Append(item + ", ");

            return SB.ToString().TrimEnd(',', ' ');
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}