using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class DocumentKey : Zephob
    {
        #region Fields
        
        private int _clnKey;
        private int _docKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Client"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Client"/> key.
        /// </value>
        public int ClnKey
        {
            get { return _clnKey; }
            set { _clnKey = value; }
        }
        
        /// <summary>
        ///   Gets or sets the <see cref="Document"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Client"/> key.
        /// </value>
        public int DocKey
        {
            get { return _docKey; }
            set { _docKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ClientKey"/> class.
        /// </summary>
        public DocumentKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="DocumentKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aClnKey">A Client key.</param>
        /// <param name="aDocKey">A Document key.</param>
        public DocumentKey(int aClnKey, int aDocKey)
        {
            _clnKey = aClnKey;
            _docKey = aDocKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ClientKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<DocumentKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aClientKey1">Key 1.</param>
            /// <param name="aClientKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(DocumentKey aDocumentKey1, DocumentKey aDocumentKey2)
            {
                return aDocumentKey1._clnKey == aDocumentKey2._clnKey &&
                       aDocumentKey1._docKey == aDocumentKey2._docKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aDocumentKey">A DocumentKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(DocumentKey aDocumentKey)
            {
                return Convert.ToInt32(aDocumentKey._clnKey) ^
                       Convert.ToInt32(aDocumentKey._docKey);
            }
        }

        #endregion

        #region AssignFromAlternateSource

        public void AssignFromAlternateSource(object aAlternateSource, List<Type> aAlternateTypeDescriptorList)
        {
            if (!(aAlternateTypeDescriptorList.Contains(aAlternateSource.GetType())))
            {
                throw new ArgumentException("Invalid assignment source", string.Format("{0}", aAlternateSource.GetType()));
            }
            _clnKey = (int)aAlternateSource.GetType().GetProperty("ClnKey").GetValue(aAlternateSource, null);
            _docKey = (int)aAlternateSource.GetType().GetProperty("DocKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Client"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is DocumentKey))
            {
                throw new ArgumentException("Invalid assignment source", "DocumentKey");
            }
            _clnKey = (aSource as DocumentKey)._clnKey;
            _docKey = (aSource as DocumentKey)._docKey;
        }

        #endregion
    }
}
