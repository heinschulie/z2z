using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class LanguageKey : Zephob
    {
         #region Fields

        private int _lanKey;

        #endregion

        #region Properties

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
        ///   Initializes a new instance of the <see cref="LanguageKey"/> class.
        /// </summary>
        public LanguageKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="LanguageKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aLanKey">A LanguageType key.</param>
        /// <param name="aProKey">A Language key.</param>
        public LanguageKey( int aLanKey)
        {
            _lanKey = aLanKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for LanguageKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<LanguageKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aLanguageKey1">Key 1.</param>
            /// <param name="aLanguageKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(LanguageKey aLanguageKey1, LanguageKey aLanguageKey2)
            {
                return aLanguageKey1._lanKey == aLanguageKey2._lanKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aLanguageKey">A LanguageKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(LanguageKey aLanguageKey)
            {
                return Convert.ToInt32(aLanguageKey._lanKey);
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
            _lanKey = (int)aAlternateSource.GetType().GetProperty("LanKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Language"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is LanguageKey))
            {
                throw new ArgumentException("Invalid assignment source", "LanguageKey");
            }
            _lanKey = (aSource as LanguageKey)._lanKey;
        }

        #endregion
    }
}
