using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class ContributorLanguageCollection : Zephob
    {
        #region Fields

        private ContributorLanguageFilter _contributorLanguageFilter = new ContributorLanguageFilter();
        private List<ContributorLanguage> _contributorLanguageList = new List<ContributorLanguage>();

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the provider filter.
        /// </summary>
        /// <value>
        /// The provider filter.
        /// </value>
        public ContributorLanguageFilter ContributorLanguageFilter
        {
            get { return _contributorLanguageFilter; }
            set { _contributorLanguageFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="Provider"/> list.
        /// </summary>
        /// <value>
        /// The Provider list.
        /// </value>
        public List<ContributorLanguage> ContributorLanguageList
        {
            get { return _contributorLanguageList; }
            set { _contributorLanguageList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ContributorLanguageCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ContributorLanguageCollection))
            {
                throw new ArgumentException("Invalid assignment source", "ContributorLanguageCollection");
            }

            _contributorLanguageFilter.AssignFromSource((aSource as ContributorLanguageCollection)._contributorLanguageFilter);
            _contributorLanguageList.Clear();
            (aSource as ContributorLanguageCollection)._contributorLanguageList.ForEach(vContributorLanguageSource =>
            {
                ContributorLanguage vContributorLanguageTarget = new ContributorLanguage();
                vContributorLanguageTarget.AssignFromSource(vContributorLanguageSource);
                _contributorLanguageList.Add(vContributorLanguageTarget);
            });
        }

        #endregion
    }
}
