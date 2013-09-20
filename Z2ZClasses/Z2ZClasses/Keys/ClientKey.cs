using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ClientKey : Zephob
    {
        #region Fields

        private int _clnKey;

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

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ClientKey"/> class.
        /// </summary>
        public ClientKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ClientKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aClnKey">A ClientType key.</param>
        /// <param name="aProKey">A Client key.</param>
        public ClientKey( int aClnKey)
        {
            _clnKey = aClnKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ClientKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<ClientKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aClientKey1">Key 1.</param>
            /// <param name="aClientKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(ClientKey aClientKey1, ClientKey aClientKey2)
            {
                return aClientKey1._clnKey == aClientKey2._clnKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aClientKey">A ClientKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(ClientKey aClientKey)
            {
                return Convert.ToInt32(aClientKey._clnKey);
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
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Client"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ClientKey))
            {
                throw new ArgumentException("Invalid assignment source", "ClientKey");
            }
            _clnKey = (aSource as ClientKey)._clnKey;
        }

        #endregion
    }
}
