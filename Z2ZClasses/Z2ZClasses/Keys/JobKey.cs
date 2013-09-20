using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class JobKey : Zephob
    {
        #region Fields
        
        private int _clnKey;
        private int _jobKey;

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
        ///   Gets or sets the <see cref="Job"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Job"/> key.
        /// </value>
        public int JobbKey
        {
            get { return _jobKey; }
            set { _jobKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="ClientKey"/> class.
        /// </summary>
        public JobKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="JobKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aClnKey">A Client key.</param>
        /// <param name="aJobKey">A Job key.</param>
        public JobKey(int aClnKey, int aJobKey)
        {
            _clnKey = aClnKey;
            _jobKey = aJobKey;
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ClientKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<JobKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aClientKey1">Key 1.</param>
            /// <param name="aClientKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(JobKey aJobKey1, JobKey aJobKey2)
            {
                return aJobKey1._clnKey == aJobKey2._clnKey &&
                       aJobKey1._jobKey == aJobKey2._jobKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aJobKey">A JobKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(JobKey aJobKey)
            {
                return Convert.ToInt32(aJobKey._clnKey) ^
                       Convert.ToInt32(aJobKey._jobKey);
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
            _jobKey = (int)aAlternateSource.GetType().GetProperty("JobKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Client"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is JobKey))
            {
                throw new ArgumentException("Invalid assignment source", "JobKey");
            }
            _clnKey = (aSource as JobKey)._clnKey;
            _jobKey = (aSource as JobKey)._jobKey;
        }

        #endregion
    }
}
