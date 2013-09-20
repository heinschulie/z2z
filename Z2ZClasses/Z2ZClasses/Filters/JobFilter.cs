using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class JobFilter : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private string _jobNameFilter;
        private int _clientKeyFilter;
        private int _jobTypeFilter; 

        #endregion

        #region  Properties

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public string JobNameFilter
        {
            get { return _jobNameFilter; }
            set { _jobNameFilter = value; }
        }

        public int ClientKeyFilter
        {
            get { return _clientKeyFilter; }
            set { _clientKeyFilter = value; }
        }

        public int JobTypeFilter
        {
            get { return _jobTypeFilter; }
            set { _jobTypeFilter = value; }
        }

        #endregion

        #region Methods

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is JobFilter))
            {
                throw new ArgumentException("Invalid assignment source", "JobFilter");
            }

            _isFiltered = (aSource as JobFilter)._isFiltered;
            _jobNameFilter = (aSource as JobFilter)._jobNameFilter;
            _clientKeyFilter = (aSource as JobFilter)._clientKeyFilter;
            _jobTypeFilter = (aSource as JobFilter)._jobTypeFilter;
        }

        #endregion
    }
}
