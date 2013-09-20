using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class JobTypeCollection : Zephob
    {
        #region Fields

        private List<JobType> _jobTypeList = new List<JobType>();

        #endregion

        #region  Properties


        /// <summary>
        /// Gets or sets the <see cref="JobType"/> list.
        /// </summary>
        /// <value>
        /// The JobType list.
        /// </value>
        public List<JobType> JobTypeList
        {
            get { return _jobTypeList; }
            set { _jobTypeList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="JobTypeCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is JobTypeCollection))
            {
                throw new ArgumentException("Invalid assignment source", "JobTypeCollection");
            }

            _jobTypeList.Clear();
            (aSource as JobTypeCollection)._jobTypeList.ForEach(vJobTypeSource =>
            {
                JobType vJobTypeTarget = new JobType();
                vJobTypeTarget.AssignFromSource(vJobTypeSource);
                _jobTypeList.Add(vJobTypeTarget);
            });
        }

        #endregion
    }
}
