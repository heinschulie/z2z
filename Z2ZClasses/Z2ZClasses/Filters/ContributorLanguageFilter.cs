using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ContributorLanguageFilter : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private int _languageKeyFilter;
        private int _contributorKeyFilter;

        #endregion

        #region  Properties

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public int LanguageKeyFilter
        {
            get { return _languageKeyFilter; }
            set { _languageKeyFilter = value; }
        }

        public int ContributorKeyFilter
        {
            get { return _contributorKeyFilter; }
            set { _contributorKeyFilter = value; }
        }

        #endregion

        #region Methods

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ContributorLanguageFilter))
            {
                throw new ArgumentException("Invalid assignment source", "ContributorFilter");
            }

            _isFiltered = (aSource as ContributorLanguageFilter)._isFiltered;
            _contributorKeyFilter = (aSource as ContributorLanguageFilter)._contributorKeyFilter;
            _languageKeyFilter = (aSource as ContributorLanguageFilter)._languageKeyFilter;
        }

        #endregion
    }
}
