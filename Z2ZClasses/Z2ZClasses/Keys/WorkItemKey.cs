using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class WorkItemKey : Zephob
    {
        #region Fields
        
        private int _clnKey;
        private int _jobKey;
        private int _jbtKey; 
        private int _wrkKey;

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
        public int JobKey
        {
            get { return _jobKey; }
            set { _jobKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Jbt"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Jbt"/> key.
        /// </value>
        public int JbtKey
        {
            get { return _jbtKey; }
            set { _jbtKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Wrk"/> key.
        /// </summary>
        /// <value>
        ///   The <see cref="Wrk"/> key.
        /// </value>
        public int WrkKey
        {
            get { return _wrkKey; }
            set { _wrkKey = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///   Initializes a new instance of the <see cref="WorkItemKey"/> class.
        /// </summary>
        public WorkItemKey() { }

        /// <summary>
        ///   Initializes a new instance of the <see cref="WorkItemKey"/> class. Set private fields to constructor arguments.
        /// </summary>
        /// <param name="aClnKey">A Client key.</param>
        /// <param name="aJobKey">A Job key.</param>
        /// <param name="aJobKey">A Wrk key.</param>
        public WorkItemKey(int aClnKey, int aJobKey, int aJbtKey, int aWrkKey)
        {
            _clnKey = aClnKey;
            _jobKey = aJobKey;
            _jbtKey = aJbtKey;
            _wrkKey = aWrkKey; 
        }

        #endregion

        #region Comparer

        /// <summary>
        ///   The Comparer class for ClientKey.
        /// </summary>
        public class EqualityComparer : IEqualityComparer<WorkItemKey>
        {
            /// <summary>
            ///   Tests equality of Key1 and Key2.
            /// </summary>
            /// <param name="aClientKey1">Key 1.</param>
            /// <param name="aClientKey2">Key 2.</param>
            /// <returns>True if the composite keys are equal, else false.</returns>
            public bool Equals(WorkItemKey aWorkItemKey1, WorkItemKey aWorkItemKey2)
            {
                return aWorkItemKey1._clnKey == aWorkItemKey2._clnKey &&
                       aWorkItemKey1._jobKey == aWorkItemKey2._jobKey &&
                       aWorkItemKey1._jbtKey == aWorkItemKey2._jbtKey &&
                       aWorkItemKey1._wrkKey == aWorkItemKey2._wrkKey;
            }

            /// <summary>
            ///   Returns a hash code for this instance.
            /// </summary>
            /// <param name="aWorkItemKey">A WorkItemKey.</param>
            /// <returns>
            ///   A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
            /// </returns>
            public int GetHashCode(WorkItemKey aWorkItemKey)
            {
                return Convert.ToInt32(aWorkItemKey._clnKey) ^
                       Convert.ToInt32(aWorkItemKey._jobKey) ^
                       Convert.ToInt32(aWorkItemKey._jbtKey) ^
                       Convert.ToInt32(aWorkItemKey._wrkKey);
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
            _wrkKey = (int)aAlternateSource.GetType().GetProperty("JbtKey").GetValue(aAlternateSource, null);
            _wrkKey = (int)aAlternateSource.GetType().GetProperty("WrkKey").GetValue(aAlternateSource, null);
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="WorkItemKey"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is WorkItemKey))
            {
                throw new ArgumentException("Invalid assignment source", "WorkItemKey");
            }
            _clnKey = (aSource as WorkItemKey)._clnKey;
            _jobKey = (aSource as WorkItemKey)._jobKey;
            _wrkKey = (aSource as WorkItemKey)._jbtKey;
            _wrkKey = (aSource as WorkItemKey)._wrkKey;
        }

        #endregion
    }
}
