using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ContributorFilter : Zephob
    {
        #region Fields

        private bool _isFiltered;
        private int _languageFilter;
        private int _ratingFilter;

        #endregion

        #region  Properties

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public int LanguageFilter
        {
            get { return _languageFilter; }
            set { _languageFilter = value; }
        }


        public int RatingFilter
        {
            get { return _ratingFilter; }
            set { _ratingFilter = value; }
        }

        #endregion

        #region Methods

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ContributorFilter))
            {
                throw new ArgumentException("Invalid assignment source", "ContributorFilter");
            }

            _isFiltered = (aSource as ContributorFilter)._isFiltered;
            _languageFilter = (aSource as ContributorFilter)._languageFilter;
            _ratingFilter = (aSource as ContributorFilter)._ratingFilter;
        }

        #endregion
    }
}
