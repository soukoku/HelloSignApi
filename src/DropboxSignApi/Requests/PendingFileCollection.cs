//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;

//namespace DropboxSignApi.Requests
//{
//    /// <summary>
//    /// Container object for files to be uploaded.
//    /// </summary>
//    public class PendingFileCollection : IList<PendingFile>
//    {
//        List<PendingFile> _list = new List<PendingFile>();

//        private void VerifyTheSameSource(PendingFile item)
//        {
//            if (item.RemotePath == null)
//            {
//                if (_list.Any(f => f.RemotePath != null))
//                {
//                    throw new ArgumentException("File collection can only contain one type of file source (remote or local).");
//                }
//            }
//            else if (_list.Any(f => f.RemotePath == null))
//            {
//                throw new ArgumentException("File collection can only contain one type of file source. (remote or local)");
//            }
//        }

//        /// <summary>
//        /// Gets or sets the <see cref="PendingFile"/> at the specified index.
//        /// </summary>
//        /// <value>
//        /// The <see cref="PendingFile"/>.
//        /// </value>
//        /// <param name="index">The index.</param>
//        /// <returns></returns>
//        public PendingFile this[int index]
//        {
//            get { return _list[index]; }
//            set { _list[index] = value; }
//        }

//        /// <summary>
//        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1" />.
//        /// </summary>
//        public int Count { get { return _list.Count; } }

//        /// <summary>
//        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.
//        /// </summary>
//        public bool IsReadOnly { get { return false; } }

//        /// <summary>
//        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1" />.
//        /// </summary>
//        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
//        public void Add(PendingFile item)
//        {
//            VerifyTheSameSource(item);
//            _list.Add(item);
//        }

//        /// <summary>
//        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1" />.
//        /// </summary>
//        public void Clear()
//        {
//            _list.Clear();
//        }

//        /// <summary>
//        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1" /> contains a specific value.
//        /// </summary>
//        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
//        /// <returns>
//        /// true if <paramref name="item" /> is found in the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false.
//        /// </returns>
//        public bool Contains(PendingFile item)
//        {
//            return _list.Contains(item);
//        }

//        /// <summary>
//        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1" /> to an <see cref="T:System.Array" />, starting at a particular <see cref="T:System.Array" /> index.
//        /// </summary>
//        /// <param name="array">The one-dimensional <see cref="T:System.Array" /> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1" />. The <see cref="T:System.Array" /> must have zero-based indexing.</param>
//        /// <param name="arrayIndex">The zero-based index in <paramref name="array" /> at which copying begins.</param>
//        public void CopyTo(PendingFile[] array, int arrayIndex)
//        {
//            _list.CopyTo(array, arrayIndex);
//        }

//        /// <summary>
//        /// Returns an enumerator that iterates through the collection.
//        /// </summary>
//        /// <returns>
//        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
//        /// </returns>
//        public IEnumerator<PendingFile> GetEnumerator()
//        {
//            return _list.GetEnumerator();
//        }

//        /// <summary>
//        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1" />.
//        /// </summary>
//        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1" />.</param>
//        /// <returns>
//        /// The index of <paramref name="item" /> if found in the list; otherwise, -1.
//        /// </returns>
//        public int IndexOf(PendingFile item)
//        {
//            return _list.IndexOf(item);
//        }

//        /// <summary>
//        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1" /> at the specified index.
//        /// </summary>
//        /// <param name="index">The zero-based index at which <paramref name="item" /> should be inserted.</param>
//        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1" />.</param>
//        public void Insert(int index, PendingFile item)
//        {
//            VerifyTheSameSource(item);
//            _list.Insert(index, item);
//        }

//        /// <summary>
//        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
//        /// </summary>
//        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
//        /// <returns>
//        /// true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
//        /// </returns>
//        public bool Remove(PendingFile item)
//        {
//            return _list.Remove(item);
//        }

//        /// <summary>
//        /// Removes the <see cref="T:System.Collections.Generic.IList`1" /> item at the specified index.
//        /// </summary>
//        /// <param name="index">The zero-based index of the item to remove.</param>
//        public void RemoveAt(int index)
//        {
//            _list.RemoveAt(index);
//        }

//        /// <summary>
//        /// Returns an enumerator that iterates through a collection.
//        /// </summary>
//        /// <returns>
//        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
//        /// </returns>
//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return _list.GetEnumerator();
//        }

//        /// <summary>
//        /// Returns a <see cref="System.String" /> that represents this instance.
//        /// </summary>
//        /// <returns>
//        /// A <see cref="System.String" /> that represents this instance.
//        /// </returns>
//        public override string ToString()
//        {
//            return _list.ToString();
//        }
//    }
//}
