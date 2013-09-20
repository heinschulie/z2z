using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class JobCollection : Zephob
    {

        #region Fields

        private JobFilter _jobFilter = new JobFilter();
        private List<Job> _jobList = new List<Job>();

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the Job filter.
        /// </summary>
        /// <value>
        /// The Job filter.
        /// </value>
        public JobFilter JobFilter
        {
            get { return _jobFilter; }
            set { _jobFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="Job"/> list.
        /// </summary>
        /// <value>
        /// The Job list.
        /// </value>
        public List<Job> JobList
        {
            get { return _jobList; }
            set { _jobList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ProviderCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is JobCollection))
            {
                throw new ArgumentException("Invalid assignment source", "JobCollection");
            }

            _jobFilter.AssignFromSource((aSource as JobCollection)._jobFilter);
            _jobList.Clear();
            (aSource as JobCollection)._jobList.ForEach(vJobSource =>
            {
                Job vJobTarget = new Job();
                vJobTarget.AssignFromSource(vJobSource);
                _jobList.Add(vJobTarget);
            });
        }

        #endregion
    }
}
