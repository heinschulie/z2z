using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ContributorKey : Zephob
    {
        #region Fields

        private int _conKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="Contributor"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Contributor"/> key.
        /// </value>
        public int ConKey
        {
            get { return _conKey; }
            set { _conKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ContributorKey"/> class.
        /// </summary>
        public ContributorKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ContributorKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aConKey">A ContributorType key.</param>
        /// <param name="aProKey">A Contributor key.</param>
        public ContributorKey( int aConKey)
        {
            _conKey = aConKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ContributorKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<ContributorKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aContributorKey1">Key 1.</param>
            /// <param name="aContributorKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(ContributorKey aContributorKey1, ContributorKey aContributorKey2)
            {
                return aContributorKey1._conKey == aContributorKey2._conKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aContributorKey">A ContributorKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(ContributorKey aContributorKey)
            {
                return Convert.ToInt32(aContributorKey._conKey);
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
            _conKey = (int)aAlternateSource.GetType().GetProperty("ConKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Contributor"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ContributorKey))
            {
                throw new ArgumentException("Invalid assignment source", "ContributorKey");
            }
            _conKey = (aSource as ContributorKey)._conKey;
        }

        #endregion
    }
}
