using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class WorkItemFilter : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private int _jobKeyFilter;
        private int _jobTypeKeyFilter;
        private int _conKeyFilter;
        private int _clientKeyFilter;

        #endregion

        #region  Properties

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public int JobKeyFilter
        {
            get { return _jobTypeKeyFilter; }
            set { _jobTypeKeyFilter = value; }
        }
        public int ConKeyFilter
        {
            get { return _conKeyFilter; }
            set { _conKeyFilter = value; }
        }
        public int JobTypeKeyFilter
        {
            get { return _jobKeyFilter; }
            set { _jobKeyFilter = value; }
        }
        public int ClientKeyFilter
        {
            get { return _clientKeyFilter; }
            set { _clientKeyFilter = value; }
        }

        #endregion

        #region Methods

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is WorkItemFilter))
            {
                throw new ArgumentException("Invalid assignment source", "WorkItemFilter");
            }

            _isFiltered = (aSource as WorkItemFilter)._isFiltered;
            _jobKeyFilter = (aSource as WorkItemFilter)._jobKeyFilter;
            _jobTypeKeyFilter = (aSource as WorkItemFilter)._jobTypeKeyFilter;
            _conKeyFilter = (aSource as WorkItemFilter)._conKeyFilter;
            _clientKeyFilter = (aSource as WorkItemFilter)._clientKeyFilter;
        }

        #endregion
    }
}
