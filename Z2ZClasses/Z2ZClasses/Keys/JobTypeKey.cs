using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class JobTypeKey : Zephob
    {
        #region Fields

        private int _jbtKey;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="JobType"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="JobType"/> key.
        /// </value>
        public int JbtKey
        {
            get { return _jbtKey; }
            set { _jbtKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="JobTypeKey"/> class.
        /// </summary>
        public JobTypeKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="JobTypeKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aJbtKey">A JobTypeType key.</param>
        /// <param name="aProKey">A JobType key.</param>
        public JobTypeKey( int aJbtKey)
        {
            _jbtKey = aJbtKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for JobTypeKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<JobTypeKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aJobTypeKey1">Key 1.</param>
            /// <param name="aJobTypeKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(JobTypeKey aJobTypeKey1, JobTypeKey aJobTypeKey2)
            {
                return aJobTypeKey1._jbtKey == aJobTypeKey2._jbtKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aJobTypeKey">A JobTypeKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(JobTypeKey aJobTypeKey)
            {
                return Convert.ToInt32(aJobTypeKey._jbtKey);
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
            _jbtKey = (int)aAlternateSource.GetType().GetProperty("JbtKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="JobType"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is JobTypeKey))
            {
                throw new ArgumentException("Invalid assignment source", "JobTypeKey");
            }
            _jbtKey = (aSource as JobTypeKey)._jbtKey;
        }

        #endregion
    }
}
