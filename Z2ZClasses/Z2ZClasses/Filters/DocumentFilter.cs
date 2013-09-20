using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class DocumentFilter : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private string _documentNameFilter;
        private int _documentClientKeyFilter;

        #endregion

        #region  Properties

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public string DocumentNameFilter
        {
            get { return _documentNameFilter; }
            set { _documentNameFilter = value; }
        }

        public int DocumentClientKeyFilter
        {
            get { return _documentClientKeyFilter; }
            set { _documentClientKeyFilter = value; }
        }

        #endregion

        #region Methods

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is DocumentFilter))
            {
                throw new ArgumentException("Invalid assignment source", "DocumentFilter");
            }

            _isFiltered = (aSource as DocumentFilter)._isFiltered;
            _documentNameFilter = (aSource as DocumentFilter)._documentNameFilter;
            _documentClientKeyFilter = (aSource as DocumentFilter)._documentClientKeyFilter;
        }

        #endregion
    }
}
