using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ContributorLanguageKey : Zephob
    {
        #region Fields

        private int _conKey;
        private int _lanKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="ContributorLanguage"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="ContributorLanguage"/> key.
        /// </value>
        public int ConKey
        {
            get { return _conKey; }
            set { _conKey = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="Language"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Language"/> key.
        /// </value>
        public int LanKey
        {
            get { return _lanKey; }
            set { _lanKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ContributorLanguageKey"/> class.
        /// </summary>
        public ContributorLanguageKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ContributorLanguageKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aConKey">A ContributorLanguageType key.</param>
        /// <param name="aProKey">A ContributorLanguage key.</param>
        public ContributorLanguageKey( int aConKey, int aLanKey)
        {
            _conKey = aConKey;
            _lanKey = aLanKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ContributorLanguageKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<ContributorLanguageKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aContributorLanguageKey1">Key 1.</param>
            /// <param name="aContributorLanguageKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(ContributorLanguageKey aContributorLanguageKey1, ContributorLanguageKey aContributorLanguageKey2)
            {
                return aContributorLanguageKey1._conKey == aContributorLanguageKey2._conKey &&
                       aContributorLanguageKey1._lanKey == aContributorLanguageKey2._lanKey ;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aContributorLanguageKey">A ContributorLanguageKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(ContributorLanguageKey aContributorLanguageKey)
            {
                return Convert.ToInt32(aContributorLanguageKey._conKey) ^
                       Convert.ToInt32(aContributorLanguageKey._lanKey);
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
            _lanKey = (int)aAlternateSource.GetType().GetProperty("LanKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="ContributorLanguage"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ContributorLanguageKey))
            {
                throw new ArgumentException("Invalid assignment source", "ContributorLanguageKey");
            }
            _conKey = (aSource as ContributorLanguageKey)._conKey;
            _lanKey = (aSource as ContributorLanguageKey)._lanKey;
        }

        #endregion
    }
}
